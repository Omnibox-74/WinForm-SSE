using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForm_SSE_Capture
{
    public partial class Form1 : Form
    {
        // Read this: https://grantwinney.com/using-async-await-and-task-to-keep-the-winforms-ui-more-responsive/
        // thread safe: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-make-thread-safe-calls
        // threat map: https://threatmap.checkpoint.com/


        static bool listen = false;
        int baseAttackCount;
        int individualAttacksSinceBaseSync;

        public Form1()
        {
            InitializeComponent();
        }

        private async void StartTask()
        {
            await SSElistenAsync();
        }

        public void UpdateAttackLabel(String lblText)
        {
            lblAttackCount.Text = lblText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                Console.WriteLine("Started!");
                button1.Text = "Stop";

                // zero any previous accack counts
                baseAttackCount = 0;
                individualAttacksSinceBaseSync = 0;

                //start listening to the SSE
                listen = true;
                StartTask();
            }
            else
            {
                //stop listening to the SSE and initiate termination of Task. 
                button1.Text = "Start";
                listen = false;
            }



        }

        
        public void WriteTextSafe(string text)
        {
            if (lblAttackCount.InvokeRequired)
            {
                // Call this method to sefely update the WinForm Attack Count Label.
                Action safeWrite = delegate { WriteTextSafe($"{text}"); };
                lblAttackCount.Invoke(safeWrite);
            }
            else
                lblAttackCount.Text = text;
        }

        public void WriteCounterMemoSafe(string text)
        {
            if (rtbCounterUpdates.InvokeRequired)
            {
                // Call this method to sefely update the WinForm Memo that contains the base attack count synchrnisation..
                Action safeWrite = delegate { WriteCounterMemoSafe($"{text}"); };
                rtbCounterUpdates.Invoke(safeWrite);
            }
            else
                rtbCounterUpdates.AppendText(text + '\n');
                //rtbCounterUpdates.Append(text);
        }


        async Task SSElistenAsync()
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(5);
            string url = $"https://threatmap-api.checkpoint.com/ThreatMap/api/feed";

            await Task.Run(async () =>
            {

                while (listen)
                {
                    try
                    {
                        Console.WriteLine("Establishing connection to Threatmap API...");
                        using (var streamReader = new StreamReader(await await Task.Run(() => Task.FromResult(client.GetStreamAsync(url)))))
                        {
                            string messageState = "waiting";
                            int attacksToday = 0;

                            while ((!streamReader.EndOfStream) && (listen == true))
                            {
                                var message = await streamReader.ReadLineAsync();

                                int oldAttacksValue = attacksToday;

                                if (message == "event:attack")
                                {
                                    messageState = "attack";
                                }
                                else if (message == "event:counter")
                                {
                                    messageState = "counter";
                                }
                                else if (message.StartsWith("data:{") && messageState != "waiting")
                                { 
                                    if(messageState == "attack" )
                                    {
                                        //increment indivdual attacks - we have encountered one discrete attack here
                                        // if cbox is checked, consider the value of "a_c" to be a count value for the gievn message

                                        if (cboxAddMultiAttack.Checked)
                                        {
                                            //extract the value of a_c and it this instaed.
                                            dynamic threatData = JsonConvert.DeserializeObject<dynamic>(message.Substring(5));
                                            individualAttacksSinceBaseSync += (int)threatData.a_c;
                                            Console.WriteLine("a_c" + threatData.a_c);
                                        }
                                        else
                                        {
                                            individualAttacksSinceBaseSync++;
                                        }                                        
                                        

                                        
                                        
                                        //attacksToday++;
                                    } else if (messageState == "counter")
                                    {
                                        //this message is a sync of main base attack count. extract it and check if it has changed since last base sync.
                                        //typically this message doesn't change the base count for 4-5 updates.  The base value appears at the end of message
                                        //and is formatted:... "today":<BaseCount>}
                                        string subPortion = "";
                                        subPortion = message.Substring(message.IndexOf("today")+7, (message.Length - 1)-(message.IndexOf("today") + 7));
                                        Console.WriteLine(subPortion);
                                        
                                        //update base attack count if it has changed since last sync
                                        if (baseAttackCount != Int32.Parse(subPortion))
                                        {
                                            baseAttackCount = Int32.Parse(subPortion);
                                            individualAttacksSinceBaseSync = 0;
                                        }

                                        //attacksToday = baseAttackCount + individualAttacksSinceBaseSync;

                                        // update the memo with what we just received as the counter
                                        var threadParametersMemo = new System.Threading.ThreadStart(delegate { WriteCounterMemoSafe("Counter Update: " + subPortion); });
                                        var threadCounterMemo = new System.Threading.Thread(threadParametersMemo);
                                        threadCounterMemo.Start();
                                    }
                                } else
                                {
                                    messageState = "waiting";
                                }

                                //message is processed.  update usewr notificaitons
                                attacksToday = baseAttackCount + individualAttacksSinceBaseSync;

                                Console.WriteLine("Attack Today: " + attacksToday);
                                Console.WriteLine(messageState);
                                Console.WriteLine($"Received update: {message}");

                                if(attacksToday != oldAttacksValue)
                                {
                                    //lblAttackCount.Text = "changed"; // attacksToday.ToString() + " Attacks Today";
                                    //UpdateAttackLabel(attacksToday.ToString() + " Attacks Today");
                                    //Invoke(UpdateAttackLabel(attacksToday.ToString() + " Attacks Today");

                                    var threadParameters = new System.Threading.ThreadStart(delegate { WriteTextSafe(attacksToday.ToString() + " Attacks Today"); });
                                    var thread2 = new System.Threading.Thread(threadParameters);
                                    thread2.Start();

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        Console.WriteLine("Retrying in 5 seconds...");
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                }
            });
            Console.WriteLine("Task ended");

        }


    }





}

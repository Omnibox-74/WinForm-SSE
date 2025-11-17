namespace WinForm_SSE_Capture
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lblAttackCount = new System.Windows.Forms.Label();
            this.cboxAddMultiAttack = new System.Windows.Forms.CheckBox();
            this.rtbCounterUpdates = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblAttackCount
            // 
            this.lblAttackCount.AutoSize = true;
            this.lblAttackCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttackCount.Location = new System.Drawing.Point(12, 150);
            this.lblAttackCount.Name = "lblAttackCount";
            this.lblAttackCount.Size = new System.Drawing.Size(309, 51);
            this.lblAttackCount.TabIndex = 1;
            this.lblAttackCount.Text = "Attacks Today";
            // 
            // cboxAddMultiAttack
            // 
            this.cboxAddMultiAttack.AutoSize = true;
            this.cboxAddMultiAttack.Checked = true;
            this.cboxAddMultiAttack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxAddMultiAttack.Location = new System.Drawing.Point(205, 21);
            this.cboxAddMultiAttack.Name = "cboxAddMultiAttack";
            this.cboxAddMultiAttack.Size = new System.Drawing.Size(221, 17);
            this.cboxAddMultiAttack.TabIndex = 2;
            this.cboxAddMultiAttack.Text = "Include Multi-Attacks (a_c in SSE stream)";
            this.cboxAddMultiAttack.UseVisualStyleBackColor = true;
            // 
            // rtbCounterUpdates
            // 
            this.rtbCounterUpdates.Location = new System.Drawing.Point(12, 354);
            this.rtbCounterUpdates.Name = "rtbCounterUpdates";
            this.rtbCounterUpdates.Size = new System.Drawing.Size(251, 133);
            this.rtbCounterUpdates.TabIndex = 3;
            this.rtbCounterUpdates.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Main Attack Count Sync";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 232);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(518, 88);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Live SSE Events";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Discrete Attacks Since Last Sync";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(279, 354);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(251, 133);
            this.richTextBox2.TabIndex = 8;
            this.richTextBox2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 501);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbCounterUpdates);
            this.Controls.Add(this.cboxAddMultiAttack);
            this.Controls.Add(this.lblAttackCount);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Threat Counter Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblAttackCount;
        private System.Windows.Forms.CheckBox cboxAddMultiAttack;
        private System.Windows.Forms.RichTextBox rtbCounterUpdates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}


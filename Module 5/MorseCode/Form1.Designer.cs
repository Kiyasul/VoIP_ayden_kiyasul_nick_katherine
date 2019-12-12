namespace GPIOTest
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
            this.pnlINPUTS = new System.Windows.Forms.Panel();
            this.rbIN1 = new System.Windows.Forms.RadioButton();
            this.lblINPUTS = new System.Windows.Forms.Label();
            this.tmrPOLL = new System.Windows.Forms.Timer();
            this.morseCodeBox = new System.Windows.Forms.TextBox();
            this.textCodeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlINPUTS.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlINPUTS
            // 
            this.pnlINPUTS.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlINPUTS.Controls.Add(this.label2);
            this.pnlINPUTS.Controls.Add(this.label1);
            this.pnlINPUTS.Controls.Add(this.morseCodeBox);
            this.pnlINPUTS.Controls.Add(this.textCodeBox);
            this.pnlINPUTS.Controls.Add(this.rbIN1);
            this.pnlINPUTS.Controls.Add(this.lblINPUTS);
            this.pnlINPUTS.Location = new System.Drawing.Point(21, 21);
            this.pnlINPUTS.Name = "pnlINPUTS";
            this.pnlINPUTS.Size = new System.Drawing.Size(708, 245);
            // 
            // rbIN1
            // 
            this.rbIN1.Location = new System.Drawing.Point(342, 194);
            this.rbIN1.Name = "rbIN1";
            this.rbIN1.Size = new System.Drawing.Size(23, 29);
            this.rbIN1.TabIndex = 1;
            // 
            // lblINPUTS
            // 
            this.lblINPUTS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblINPUTS.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lblINPUTS.Location = new System.Drawing.Point(3, 3);
            this.lblINPUTS.Name = "lblINPUTS";
            this.lblINPUTS.Size = new System.Drawing.Size(702, 32);
            this.lblINPUTS.Text = "INCOMING MESSAGE";
            this.lblINPUTS.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmrPOLL
            // 
            this.tmrPOLL.Tick += new System.EventHandler(this.tmrPOLL_Tick);
            // 
            // morseCodeBox
            // 
            this.morseCodeBox.Location = new System.Drawing.Point(7, 165);
            this.morseCodeBox.Name = "morseCodeBox";
            this.morseCodeBox.Size = new System.Drawing.Size(694, 23);
            this.morseCodeBox.TabIndex = 2;
            this.morseCodeBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textCodeBox
            // 
            this.textCodeBox.Location = new System.Drawing.Point(7, 82);
            this.textCodeBox.Name = "textCodeBox";
            this.textCodeBox.Size = new System.Drawing.Size(694, 23);
            this.textCodeBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(7, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(694, 20);
            this.label1.Text = "TEXT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(7, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(694, 20);
            this.label2.Text = "MORSE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(748, 289);
            this.Controls.Add(this.pnlINPUTS);
            this.Name = "Form1";
            this.Text = "GPIO Test ";
            this.pnlINPUTS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlINPUTS;
        private System.Windows.Forms.RadioButton rbIN1;
        private System.Windows.Forms.Label lblINPUTS;
        private System.Windows.Forms.Timer tmrPOLL;
        private System.Windows.Forms.TextBox morseCodeBox;
        private System.Windows.Forms.TextBox textCodeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


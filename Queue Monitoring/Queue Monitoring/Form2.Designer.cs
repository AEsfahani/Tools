namespace Queue_Monitoring
{
    partial class Form2
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
            this.TextBox8 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBox8
            // 
            this.TextBox8.Location = new System.Drawing.Point(0, 1);
            this.TextBox8.Multiline = true;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.ReadOnly = true;
            this.TextBox8.Size = new System.Drawing.Size(305, 249);
            this.TextBox8.TabIndex = 39;
            this.TextBox8.Text = "10/3/2013 Added About page \r\n10/3/2013 Added Change Log\r\n01/8/2014 Removed Yannic" +
    "k from Ready numbers\r\n";
            this.TextBox8.TextChanged += new System.EventHandler(this.TextBox8_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 262);
            this.Controls.Add(this.TextBox8);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TextBox8;
    }
}
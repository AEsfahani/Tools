namespace Queue_Monitoring
{
    partial class FullSchedule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullSchedule));
            this.ExcelSchedule = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // ExcelSchedule
            // 
            this.ExcelSchedule.AllowUserToAddRows = false;
            this.ExcelSchedule.AllowUserToDeleteRows = false;
            this.ExcelSchedule.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelSchedule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ExcelSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ExcelSchedule.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ExcelSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExcelSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExcelSchedule.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ExcelSchedule.Location = new System.Drawing.Point(0, 0);
            this.ExcelSchedule.Name = "ExcelSchedule";
            this.ExcelSchedule.ReadOnly = true;
            this.ExcelSchedule.Size = new System.Drawing.Size(661, 320);
            this.ExcelSchedule.TabIndex = 0;
            // 
            // FullSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 320);
            this.Controls.Add(this.ExcelSchedule);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FullSchedule";
            this.Text = "FullSchedule";
            this.Load += new System.EventHandler(this.FullSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExcelSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ExcelSchedule;
    }
}
namespace WindowsFormsAppSchedule
{
    partial class AdminWindows
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
            this.HomeWork = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HomeWork
            // 
            this.HomeWork.FormattingEnabled = true;
            this.HomeWork.Location = new System.Drawing.Point(12, 44);
            this.HomeWork.Name = "HomeWork";
            this.HomeWork.Size = new System.Drawing.Size(303, 108);
            this.HomeWork.TabIndex = 0;
            this.HomeWork.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Домашнее задание:";
            // 
            // AdminWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 194);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HomeWork);
            this.Name = "AdminWindows";
            this.Text = "AdminWindows";
            this.Load += new System.EventHandler(this.AdminWindows_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox HomeWork;
        private System.Windows.Forms.Label label1;
    }
}
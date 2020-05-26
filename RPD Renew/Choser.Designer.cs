namespace RPD_Renew
{
    partial class Choser
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
            this.TreeList = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // TreeList
            // 
            this.TreeList.Location = new System.Drawing.Point(12, 12);
            this.TreeList.Name = "TreeList";
            this.TreeList.Size = new System.Drawing.Size(776, 426);
            this.TreeList.TabIndex = 0;
            // 
            // Choser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TreeList);
            this.Name = "Choser";
            this.Text = "Choser";
            this.Load += new System.EventHandler(this.Choser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeList;
    }
}
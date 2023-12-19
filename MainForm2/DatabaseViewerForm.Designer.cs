
namespace MainForm2
{
    partial class DatabaseViewerForm
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
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(2119, 923);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(149, 55);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // DatabaseViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 528);
            this.Controls.Add(this.RefreshButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DatabaseViewerForm";
            this.Text = "DatabaseViewerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RefreshButton;
    }
}
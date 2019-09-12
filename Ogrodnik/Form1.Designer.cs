namespace Ogrodnik
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
            this.pictureBoxOgrod = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOgrod)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOgrod
            // 
            this.pictureBoxOgrod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxOgrod.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxOgrod.Name = "pictureBoxOgrod";
            this.pictureBoxOgrod.Size = new System.Drawing.Size(667, 540);
            this.pictureBoxOgrod.TabIndex = 0;
            this.pictureBoxOgrod.TabStop = false;
            this.pictureBoxOgrod.SizeChanged += new System.EventHandler(this.pictureBoxOgrod_SizeChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 540);
            this.Controls.Add(this.pictureBoxOgrod);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOgrod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOgrod;
    }
}


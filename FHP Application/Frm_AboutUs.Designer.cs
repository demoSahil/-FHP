namespace FHP_Application
{
    partial class Frm_AboutUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AboutUs));
            this.lbl_aboutUs = new System.Windows.Forms.Label();
            this.lbl_OurBusiness = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_aboutUs
            // 
            this.lbl_aboutUs.AutoSize = true;
            this.lbl_aboutUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aboutUs.Location = new System.Drawing.Point(34, 40);
            this.lbl_aboutUs.Name = "lbl_aboutUs";
            this.lbl_aboutUs.Size = new System.Drawing.Size(70, 16);
            this.lbl_aboutUs.TabIndex = 3;
            this.lbl_aboutUs.Text = "About Us";
            // 
            // lbl_OurBusiness
            // 
            this.lbl_OurBusiness.AutoSize = true;
            this.lbl_OurBusiness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OurBusiness.Location = new System.Drawing.Point(34, 149);
            this.lbl_OurBusiness.Name = "lbl_OurBusiness";
            this.lbl_OurBusiness.Size = new System.Drawing.Size(115, 16);
            this.lbl_OurBusiness.TabIndex = 4;
            this.lbl_OurBusiness.Text = "Our Businesses";
            // 
            // Frm_AboutUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 342);
            this.Controls.Add(this.lbl_OurBusiness);
            this.Controls.Add(this.lbl_aboutUs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_AboutUs";
            this.Text = "About Us";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_aboutUs;
        private System.Windows.Forms.Label lbl_OurBusiness;
    }
}
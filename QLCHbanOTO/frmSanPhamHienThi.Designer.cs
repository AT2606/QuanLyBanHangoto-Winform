namespace QLCHbanOTO
{
    partial class frmSanPhamHienThi
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
            this.lb_TenSanPham = new System.Windows.Forms.Label();
            this.ptHinhAnh = new System.Windows.Forms.PictureBox();
            this.btnXemThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_TenSanPham
            // 
            this.lb_TenSanPham.AutoSize = true;
            this.lb_TenSanPham.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenSanPham.Location = new System.Drawing.Point(142, 174);
            this.lb_TenSanPham.Name = "lb_TenSanPham";
            this.lb_TenSanPham.Size = new System.Drawing.Size(67, 26);
            this.lb_TenSanPham.TabIndex = 0;
            this.lb_TenSanPham.Text = "label1";
            // 
            // ptHinhAnh
            // 
            this.ptHinhAnh.Image = global::QLCHbanOTO.Properties.Resources.a35_4matic;
            this.ptHinhAnh.Location = new System.Drawing.Point(65, 12);
            this.ptHinhAnh.Name = "ptHinhAnh";
            this.ptHinhAnh.Size = new System.Drawing.Size(238, 159);
            this.ptHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptHinhAnh.TabIndex = 23;
            this.ptHinhAnh.TabStop = false;
            // 
            // btnXemThem
            // 
            this.btnXemThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemThem.Location = new System.Drawing.Point(112, 194);
            this.btnXemThem.Name = "btnXemThem";
            this.btnXemThem.Size = new System.Drawing.Size(112, 39);
            this.btnXemThem.TabIndex = 33;
            this.btnXemThem.Text = "Xem Thêm";
            this.btnXemThem.UseVisualStyleBackColor = true;
            // 
            // frmSanPhamHienThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 291);
            this.Controls.Add(this.btnXemThem);
            this.Controls.Add(this.ptHinhAnh);
            this.Controls.Add(this.lb_TenSanPham);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSanPhamHienThi";
            this.Text = "frmSanPhamHienThi";
            ((System.ComponentModel.ISupportInitialize)(this.ptHinhAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_TenSanPham;
        private System.Windows.Forms.PictureBox ptHinhAnh;
        private System.Windows.Forms.Button btnXemThem;
    }
}
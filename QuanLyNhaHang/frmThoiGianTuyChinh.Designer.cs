namespace QuanLyNhaHang
{
    partial class frmThoiGianTuyChinh
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
            this.customCalendar1 = new CustomControlThongKe.MyCustomCalendar();
            this.lbl_ngaykt = new System.Windows.Forms.Label();
            this.lbl_ngaybd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customCalendar1
            // 
            this.customCalendar1.Location = new System.Drawing.Point(0, 0);
            this.customCalendar1.Name = "customCalendar1";
            this.customCalendar1.Size = new System.Drawing.Size(596, 373);
            this.customCalendar1.TabIndex = 0;
            // 
            // lbl_ngaykt
            // 
            this.lbl_ngaykt.AutoSize = true;
            this.lbl_ngaykt.Location = new System.Drawing.Point(619, 387);
            this.lbl_ngaykt.Name = "lbl_ngaykt";
            this.lbl_ngaykt.Size = new System.Drawing.Size(46, 17);
            this.lbl_ngaykt.TabIndex = 1;
            this.lbl_ngaykt.Text = "label1";
            // 
            // lbl_ngaybd
            // 
            this.lbl_ngaybd.AutoSize = true;
            this.lbl_ngaybd.Location = new System.Drawing.Point(521, 387);
            this.lbl_ngaybd.Name = "lbl_ngaybd";
            this.lbl_ngaybd.Size = new System.Drawing.Size(46, 17);
            this.lbl_ngaybd.TabIndex = 2;
            this.lbl_ngaybd.Text = "label2";
            // 
            // frmThoiGianTuyChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 423);
            this.Controls.Add(this.lbl_ngaybd);
            this.Controls.Add(this.lbl_ngaykt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThoiGianTuyChinh";
            this.Text = "frmThoiGianTuyChinh";

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControlThongKe.MyCustomCalendar customCalendar1;
        private System.Windows.Forms.Label lbl_ngaykt;
        private System.Windows.Forms.Label lbl_ngaybd;
    }
}
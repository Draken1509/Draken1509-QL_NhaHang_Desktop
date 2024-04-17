using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
using System.IO;
namespace QuanLyNhaHang
{
    public partial class frmThemMenu : Form
    {
        MonAnDAL monandal = new MonAnDAL();
        LoaiDAL loaiDal = new LoaiDAL();
        int id = 0;
        string PATH = "";
        public frmThemMenu()
        {
            InitializeComponent();
        
            lbl_idmon.Text = id.ToString().Trim();
            id = monandal.getMaxID() + 1;
            loadComBoBox();
            loadThongtin();
            lbl_idmon.Visible = false;
            txt_anh.Visible = false;



            //string thuMucHienTai = AppDomain.CurrentDomain.BaseDirectory;
            //string destinationPath = @"D:\HK7\PTUDTM\DOAN_PTUDTM\QL_NhaHang\CustomControlThongKe\CommonImage";
            //string duongDantuyetdoi = Path.GetFullPath(destinationPath);
            //Uri thuMucHienTaiUri = new Uri(thuMucHienTai);
            //Uri duongDantuyetdoiUri = new Uri(duongDantuyetdoi);
            //string duongDanTuongDoi = Uri.UnescapeDataString(thuMucHienTaiUri.MakeRelativeUri(duongDantuyetdoiUri).ToString());
            //string path = @"../../../DAL/CommonImage";
            //if (Directory.Exists(path))
            //{
            //    Console.WriteLine("Thư mục tồn tại.");
            //}

        }


        public void loadComBoBox()
        {
            cbo_loai.DataSource = loaiDal.getLoai();
            cbo_loai.DisplayMember = "tenloai";
            cbo_loai.ValueMember = "id_loai";
        }
        public void loadThongtin()
        {
            List<MonAn> menuItems = monandal.getThongTinMonAnTheoMaMon(id);
            if (menuItems.Count > 0)
            {
                MonAn firstMenuItem = menuItems.First(); // Lấy một mục đầu tiên từ danh sách

                txt_tenSP.Text = firstMenuItem.Tenmon.ToString();
                cbo_loai.SelectedValue = firstMenuItem.Id_loai;
                txt_giaBan.Text = firstMenuItem.Giaban.ToString();
                txt_ghichu.Text = firstMenuItem.Ghichu;
                txt_anh.Text = firstMenuItem.Hinh;
                string hinh = txt_anh.Text;

                string imagePath = @"../../../DAL/CommonImage/" + hinh;
                //--------------------------------------------------Load Anh
                if (File.Exists(imagePath))
                {
                    using (FileStream fileStream = File.Open(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        Image myImage = Image.FromStream(fileStream);

                        // Gán ảnh cho PictureBox hoặc nơi cần sử dụng
                        btn_Anh.BackgroundImageLayout = ImageLayout.Stretch;
                        btn_Anh.BackgroundImage = myImage;
                    }

                }

                else
                {
                    MessageBox.Show("Không tìm thấy tệp hình ảnh!");
                }

                //--------------------------------------------------Load Anh

                // int dotIndex = hinh.LastIndexOf('.');
                // string result = "_" + hinh.Substring(0, dotIndex);
                // Object rm = Properties.Resources.ResourceManager.GetObject(result);

                //    if (rm != null)
                //    {
                //        Bitmap myImage = (Bitmap)rm;
                //        btn_Anh.BackgroundImageLayout = ImageLayout.Stretch;
                //        btn_Anh.BackgroundImage = myImage;
                //    }

            }
            //  MessageBox.Show("ma mon la:" + cbo_loai.SelectedValue.ToString());

        }
        private void cbo_loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("ma mon la:" + cbo_loai.SelectedValue.ToString());
        }

        private void btn_Anh_Click(object sender, EventArgs e)
        {

            Object rm = Properties.Resources.ResourceManager.GetObject("Upload");
            Bitmap myImage = (Bitmap)rm;
            btn_Anh.BackgroundImage = myImage;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính của OpenFileDialog
            openFileDialog.Title = "Chọn ảnh"; // Tiêu đề của hộp thoại
            openFileDialog.Filter = "Ảnh files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png|Tất cả files (*.*)|*.*"; // Bộ lọc định dạng file
            openFileDialog.Multiselect = false; // Cho phép chọn nhiều file hay không

            // Kiểm tra xem người dùng đã chọn file hay không
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của file ảnh được chọn
                string filePath = openFileDialog.FileName;

                // Hiển thị đường dẫn hoặc thực hiện các thao tác khác với đường dẫn ảnh
                txt_capnhatduongdan.Text = filePath;
                string img = filePath;
                PATH = img;

                //------------------------------------------------------------------------------------------




                // Thực hiện các thao tác khác với đường dẫn ảnh ở đây
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Object rm = Properties.Resources.ResourceManager.GetObject("Upload");
            Bitmap myImage = (Bitmap)rm;
            btn_Anh.BackgroundImage = myImage;


            //string imagePath = @"D:\HK7\PTUDTM\DOAN_PTUDTM\QL_NhaHang\CustomControlThongKe\CommonImage\anh1.jpg"; // Đường dẫn thực tế đến ảnh của bạn
            //if (File.Exists(imagePath))
            //{
            //    // Load ảnh từ file
            //    Image myImage = Image.FromFile(imagePath);

            //    // Sử dụng ảnh tùy ý, ví dụ, gán nó cho PictureBox
            //    pictureBox1.Image = myImage;
            //}
            //else
            //{
            //    MessageBox.Show("Không tìm thấy tệp hình ảnh!");
            //}

            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính của OpenFileDialog
            openFileDialog.Title = "Chọn ảnh"; // Tiêu đề của hộp thoại
            openFileDialog.Filter = "Ảnh files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png|Tất cả files (*.*)|*.*"; // Bộ lọc định dạng file
            openFileDialog.Multiselect = false; // Cho phép chọn nhiều file hay không            
            // Kiểm tra xem người dùng đã chọn file hay không
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của file ảnh được chọn
                string filePath = openFileDialog.FileName;
                // Hiển thị đường dẫn hoặc thực hiện các thao tác khác với đường dẫn ảnh
                txt_capnhatduongdan.Text = filePath;

                // Thực hiện các thao tác khác với đường dẫn ảnh ở đây



                //string imagePath = @"D:\OneDrive\Pictures\Documents\anh\Chill-PC-Wallpapers.jpg"; // Đường dẫn thực tế đến ảnh của bạn
                //if (File.Exists(imagePath))
                //{
                //    // Load ảnh từ file
                //    Image myImage1 = Image.FromFile(imagePath);

                //    // Sử dụng ảnh tùy ý, ví dụ, gán nó cho PictureBox
                //    btn_Anh.BackgroundImageLayout = ImageLayout.Stretch;
                //    btn_Anh.BackgroundImage = myImage1;
                //}
                //else
                //{
                //    MessageBox.Show("Không tìm thấy tệp hình ảnh!");
                //}
            }




        }

        private void gunaButton1_Click(object sender, EventArgs e)// button cập nhâtk
        {


            if (txt_giaBan.Text != "" && txt_tenSP.Text != "")
            {
                if (txt_capnhatduongdan.Text != "")
                {
                   
                    string duongDanAnhSauKhiDoi = txt_capnhatduongdan.Text;
                    string sourcePath = @duongDanAnhSauKhiDoi; // Đường dẫn tới ảnh nguồn 
                    string destinationFolder = @"../../../DAL/CommonImage/"; // Đường dẫn đến thư mục đích
                    string newFileName = id + ".jpg"; // Tên anh

                
                    string tenTepKhongMoRong = Path.GetFileNameWithoutExtension(newFileName);
                    string chuoiSauDauGachCuoiCung = tenTepKhongMoRong.Substring(tenTepKhongMoRong.LastIndexOf("\\") + 1) + ".jpg";
                    Console.WriteLine(chuoiSauDauGachCuoiCung);
                    string destinationPath = destinationFolder + chuoiSauDauGachCuoiCung;

                    try
                    {                    
                        using (FileStream sourceStream = File.Open(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            File.Copy(sourcePath, destinationPath, true);
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi copy tệp:" + ex.Message);
                    }

                }

             
                int idLoai = int.Parse(cbo_loai.SelectedValue.ToString());
                int giaBan = int.Parse(txt_giaBan.Text.Trim()) / 1000;
                string ghichu = txt_ghichu.Text.Trim();
                string tenMon = txt_tenSP.Text.Trim();
                string tenhinh = id + ".jpg";
                int kt = monandal.themMonAn(id,idLoai, tenMon, giaBan, ghichu, tenhinh);
                if (kt == 1)
                {
                    MessageBox.Show("Thêm thành công");
                    Application.OpenForms["frmMainThemMenu"].Close();

                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }

        }
          
        private void txt_giaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_giaBan_Leave(object sender, EventArgs e)
        {
            int value; // Khai báo biến value trước khi sử dụng
            if (!IsValidNumber(txt_giaBan.Text, out value))
            {
                // Nếu giá trị không hợp lệ, đặt lại giá trị mặc định
                txt_giaBan.Text = "";
            }
        }

        private bool IsValidNumber(string input, out int value)
        {
            int tempValue;
            bool isValid = int.TryParse(input, out tempValue);
            if (isValid)
            {
                // Kiểm tra giá trị nằm trong miền giá trị từ 1000 đến 1000000
                if (tempValue < 1000 || tempValue > 1000000)
                {
                    MessageBox.Show("Giá trị không hợp lệ. Vui lòng nhập giá trị trong khoảng từ 1000 đến 1000000.");
                    value = 1000; // hoặc giá trị mặc định khác
                    return false;
                }
                value = tempValue;
                return true;
            }
            else
            {
                MessageBox.Show("Vui lòng chỉ nhập số.");
                value = 1000; // hoặc giá trị mặc định khác
                return false;
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Application.OpenForms["frmMainThemMenu"].Close();
        }

    }
}

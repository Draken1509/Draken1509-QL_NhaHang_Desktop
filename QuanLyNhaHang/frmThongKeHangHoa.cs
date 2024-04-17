using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DAL;
using DTO;
using CustomControlThongKe;
namespace QuanLyNhaHang
{
    public partial class frmThongKeHangHoa : Form
    {
        SanPhamDAL sanphamdal = new SanPhamDAL();
        DateTime bd = DateTime.Now;
        DateTime kt = DateTime.Now;
        public frmThongKeHangHoa()
        {
            InitializeComponent();

            cbo_nhom.SelectedIndex = 0;
            cbo_thonngke.SelectedIndex = 1;
            cbo_sapXep.SelectedIndex = 0;

            this.Load += frmThongKeHangHoa_Load;
            lbl_ngatbatdau.Visible = false;
            //LoadDataToDataGridView();

          
        }

        private void CalendarUserControl_DateSelected(string selectedDate)
        {
            // Xử lý ngày đã chọn từ UserControl (Bộ lịch)

            lbl_ngatbatdau.Text = selectedDate;
            string input = selectedDate;

            // Tách chuỗi theo dấu gạch ngang
            string[] parts = input.Split('-');

            if (parts.Length >= 2)
            {
                // Lấy phần bắt đầu và kết thúc
                string startDateString = parts[0].Trim();
                string endDateString = parts[1].Trim();

                DateTime ngayDaChuyen_batdau = DateTime.ParseExact(startDateString, "dd/MM/yyyy", null);
                DateTime ngayDaChuyen_kethuc = DateTime.ParseExact(endDateString, "dd/MM/yyyy", null);

                string ngayDaChuyen_batdau_format = ngayDaChuyen_batdau.ToString("yyyy/MM/dd");
                string ngayDaChuyen_kethuc_format = ngayDaChuyen_kethuc.ToString("yyyy/MM/dd");

                DateTime ngayDaChuyen_batdau_cpt = DateTime.ParseExact(ngayDaChuyen_batdau_format, "yyyy/MM/dd", null);
                DateTime ngayDaChuyen_kethuc_cpt = DateTime.ParseExact(ngayDaChuyen_kethuc_format, "yyyy/MM/dd", null);

                bd = ngayDaChuyen_batdau_cpt;
                kt = ngayDaChuyen_kethuc_cpt;
            }
            else
            {
                Console.WriteLine("Chuỗi không hợp lệ");
            }
        }
        private void LoadDataToDataGridView(List<SanPham> danhSachSanPham)
        {
           
            dtgv_sanpham.DataSource = danhSachSanPham;

            dtgv_sanpham.Columns["Id"].HeaderText = "Mã món";
            dtgv_sanpham.Columns["Tensp"].HeaderText = "Tên Món";
            dtgv_sanpham.Columns["Soluong"].HeaderText = "Số Lượng";
            dtgv_sanpham.Columns["Doanhthu"].HeaderText = "Doanh Thu";                   
            dtgv_sanpham.Refresh();
        }
        private void LoadDataToDataGridView_NhomHangHoa(List<SanPham> danhSachSanPham)
        {

            dtgv_sanpham.DataSource = danhSachSanPham;

            dtgv_sanpham.Columns["Id"].HeaderText = "Mã nhóm món ăn";
            dtgv_sanpham.Columns["Tensp"].HeaderText = "Tên nhóm món ăn";
            dtgv_sanpham.Columns["Soluong"].HeaderText = "Số Lượng";
            dtgv_sanpham.Columns["Doanhthu"].HeaderText = "Doanh Thu";
            dtgv_sanpham.Refresh();
        }



        public void tao_pieChartTheoDoanhThu_HangHoa(List<SanPham> danhSachSanPham)
        {
            piechart.Series["Doanhthu"].Points.Clear();

            decimal totalDoanhThu = danhSachSanPham.Sum(x => x.Doanhthu);
            //if (totalDoanhThu == 0)
            //    totalDoanhThu = 1;
            foreach (var item in danhSachSanPham)
            {              
                double percentage = Math.Round((double)(item.Doanhthu / totalDoanhThu) * 100, 2); // Làm tròn đến 2 chữ số thập phân
                DataPoint point = new DataPoint();
                point.AxisLabel = item.Tensp;
                point.YValues = new double[] { percentage };
                point.Tag = item.Tensp; // Lưu tên món vào Tag của DataPoint
                piechart.Series["Doanhthu"].Points.Add(point);

            }
            piechart.Series["Doanhthu"].IsValueShownAsLabel = true;
            AttachMouseHoverEvent(piechart);
        }

        public  void load_pieChart()
        {
            if(cbo_thonngke.SelectedIndex == 1 )  // tất cả
            {
                lbl_ngatbatdau.Text = "Tất cả";
                lbl_ngatbatdau.Visible = true;
                if(cbo_sapXep.SelectedIndex==0)  // theo doanh thu
                {
                    
                    if(cbo_nhom.SelectedIndex==0)   // theo hang hoa
                    {
                          var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay();
                          tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                          LoadDataToDataGridView(danhSachSanPham);
                         
                    }                      
                    else    // theo nhóm hàng hóa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                     
                    }
                }
                else  // Theo số lượng
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_TheoSoLuong();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                       
                    }
                    else // theo nhóm hàng hóa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                        
                    }

                }
               
            }
            else if(cbo_thonngke.SelectedIndex== 2) // hom nay
            {
                lbl_ngatbatdau.Text = sanphamdal.layNgayHomNay().ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;
                if (cbo_sapXep.SelectedIndex == 0)  // theo doanh thu
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_HomNay();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                      
                      //  MessageBox.Show("chon vao 2");
                    }                      
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_HomNay();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                       
                    }
                }
                else
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_HomNay_TheoSoLuong();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                       
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_HomNay();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                      
                    }
                }
            }
            else if (cbo_thonngke.SelectedIndex == 3) // hom qua
            {
                lbl_ngatbatdau.Text = sanphamdal.layNgayHomQua().ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;
                if (cbo_sapXep.SelectedIndex == 0)  // theo doanh thu
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_HomQua();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                       
                        //  MessageBox.Show("chon vao 2");
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_HomQua();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                   
                       
                    }
                }
                else
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_HomQua_TheoSoluong();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                       
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_HomQua();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                      
                    }
                }
            }

            else if (cbo_thonngke.SelectedIndex == 4) //  bayngayqua
            {
                DateTime ngayhomnay = DateTime.Now;               
                lbl_ngatbatdau.Text = sanphamdal.layNNgayQua(7).ToString("dd/MM/yyyy")
                    + " - " + ngayhomnay.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;
                if (cbo_sapXep.SelectedIndex == 0)  // theo doanh thu
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_NNgayQua(7);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                       
                        //  MessageBox.Show("chon vao 2");
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_NNgayQua(7);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                       
                    }
                }
                else
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_NNgayQua_TheoSoLuong(7);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                      
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_NNgayQua(7);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                      
                    }
                }
            }
            else if (cbo_thonngke.SelectedIndex == 5) //  14 ngayqua
            {
                DateTime ngayhomnay = DateTime.Now;
                lbl_ngatbatdau.Text = sanphamdal.layNNgayQua(14).ToString("dd/MM/yyyy")
                    + " - " + ngayhomnay.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;
                if (cbo_sapXep.SelectedIndex == 0)  // theo doanh thu
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_NNgayQua(14);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                       
                        //  MessageBox.Show("chon vao 2");
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_NNgayQua(14);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                       
                    }
                }
                else
                {
                     if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                        {
                            var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_NNgayQua_TheoSoLuong(14);
                            tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                            LoadDataToDataGridView(danhSachSanPham);
                            
                        }
                        else
                        {
                            var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_NNgayQua(14);
                            tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                            LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                          
                        }
                }
            }
            else if (cbo_thonngke.SelectedIndex == 6) //   bao muoi ngay qua
            {
                DateTime ngayhomnay = DateTime.Now;
                lbl_ngatbatdau.Text = sanphamdal.layNNgayQua(30).ToString("dd/MM/yyyy")
                    + " - " + ngayhomnay.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;
                if (cbo_sapXep.SelectedIndex == 0)  // theo doanh thu
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_NNgayQua(30);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                        //  MessageBox.Show("chon vao 2");
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_NNgayQua(14);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                       
                    }
                }
                else
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_NNgayQua_TheoSoLuong(30);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                        lbl_ngatbatdau.Visible = true;
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_NNgayQua(30);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                        lbl_ngatbatdau.Visible = true;
                    }
                }
            }

            else if (cbo_thonngke.SelectedIndex == 7) //  tuan nay
            {
                KhoangThoiGian tg = sanphamdal.layTuanNay();
                lbl_ngatbatdau.Text = tg.NgayBatDau.ToString("dd/MM/yyyy") +
                    " - " + tg.NgayKetThuc.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;
                if (cbo_sapXep.SelectedIndex == 0)  // theo doanh thu
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_TuanNay();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                     
                        //  MessageBox.Show("chon vao 2");
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_TuanNay();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                      
                    }
                }
                else
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_TuanNay_TheoSoLuong();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                        
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_TuanNay();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                        
                    }
                }
            }
            else if (cbo_thonngke.SelectedIndex == 8) //  thang nay
            {
                KhoangThoiGian tg = sanphamdal.layThangNay();
                lbl_ngatbatdau.Text = tg.NgayBatDau.ToString("dd/MM/yyyy") +
                    " - " + tg.NgayKetThuc.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;
                if (cbo_sapXep.SelectedIndex == 0)  // theo doanh thu
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_ThangNay();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                       
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_ThangNay();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                       
                    }
                }
                else
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_ThangNay_TheoSoLuong();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                       
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_ThangNay();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                       
                    }
                }
            }
            else if (cbo_thonngke.SelectedIndex == 9) //  tuantruoc
            {
                KhoangThoiGian tg = sanphamdal.layTuanTruoc();
                lbl_ngatbatdau.Text = tg.NgayBatDau.ToString("dd/MM/yy") +
                    " - " + tg.NgayKetThuc.ToString("dd/MM/yy");
                lbl_ngatbatdau.Visible = true;
                if (cbo_sapXep.SelectedIndex == 0)  // theo doanh thu
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_TuanTruoc();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                       
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_TuanTruoc();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                       
                    }
                }
                else
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_TuanTruoc_TheoSoLuong();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                      
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_TuanTruoc();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                       
                    }
                }
            }
            else if (cbo_thonngke.SelectedIndex == 10) //  thang truoc
            {
                KhoangThoiGian tg = sanphamdal.layThangTruoc();
                lbl_ngatbatdau.Text = tg.NgayBatDau.ToString("dd/MM/yyyy") +
                    " - " + tg.NgayKetThuc.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;

                if (cbo_sapXep.SelectedIndex == 0)  // theo doanh thu
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_ThangTruoc();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                      
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_ThangTruoc();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                       
                    }
                }
                else
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_ThangTruoc_TheoSoLuong();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                       
                    }
                    else
                    {
                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_ThangTruoc();
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                       
                    }
                }
            }
            else if(cbo_thonngke.SelectedIndex==0)
            {
                if (cbo_sapXep.SelectedIndex == 0)  // theo doanh thu
                {
                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        MyCustomCalendar calendarUserControl = new MyCustomCalendar();
                        calendarUserControl.DateSelected += CalendarUserControl_DateSelected;
                        // Hiển thị UserControl trong một Form mới
                        using (var calendarForm = new Form())
                        {
                            calendarForm.Controls.Add(calendarUserControl);
                            calendarForm.StartPosition = FormStartPosition.Manual;
                            calendarForm.Location = new Point(
                                this.Location.X + (this.Width - calendarForm.Width) / 2,
                                this.Location.Y + (this.Height - calendarForm.Height) / 2
                            );

                            // Thiết lập kích thước (ví dụ: 300x200)
                            calendarForm.Size = new Size(700, 460);


                            calendarForm.ShowDialog();  // Chờ đến khi Form con đóng
                        }

                       var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_KhoangThoiGian(bd,kt);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                        lbl_ngatbatdau.Visible = true;
                    }
                    else
                    {

                        MyCustomCalendar calendarUserControl = new MyCustomCalendar();
                        calendarUserControl.DateSelected += CalendarUserControl_DateSelected;
                        // Hiển thị UserControl trong một Form mới
                        using (var calendarForm = new Form())
                        {
                            calendarForm.Controls.Add(calendarUserControl);
                            calendarForm.StartPosition = FormStartPosition.Manual;
                            calendarForm.Location = new Point(
                                this.Location.X + (this.Width - calendarForm.Width) / 2,
                                this.Location.Y + (this.Height - calendarForm.Height) / 2
                            );

                            // Thiết lập kích thước (ví dụ: 300x200)
                            calendarForm.Size = new Size(700, 460);


                            calendarForm.ShowDialog();  // Chờ đến khi Form con đóng
                        }

                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_DoanhThu_NhomHangHoa_KhoangThoiGian(bd, kt);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                        lbl_ngatbatdau.Visible = true;

                    }
                }
                else
                {

                    if (cbo_nhom.SelectedIndex == 0)   // theo hang hoa
                    {
                        MyCustomCalendar calendarUserControl = new MyCustomCalendar();
                        calendarUserControl.DateSelected += CalendarUserControl_DateSelected;
                        // Hiển thị UserControl trong một Form mới
                        using (var calendarForm = new Form())
                        {
                            calendarForm.Controls.Add(calendarUserControl);
                            calendarForm.StartPosition = FormStartPosition.Manual;
                            calendarForm.Location = new Point(
                                this.Location.X + (this.Width - calendarForm.Width) / 2,
                                this.Location.Y + (this.Height - calendarForm.Height) / 2
                            );

                            // Thiết lập kích thước (ví dụ: 300x200)
                            calendarForm.Size = new Size(700, 460);


                            calendarForm.ShowDialog();  // Chờ đến khi Form con đóng
                        }

                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_KhoangThoiGian_TheoSoLuong(bd, kt);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView(danhSachSanPham);
                        lbl_ngatbatdau.Visible = true;
                    }
                    else
                    {
                        MyCustomCalendar calendarUserControl = new MyCustomCalendar();
                        calendarUserControl.DateSelected += CalendarUserControl_DateSelected;
                        // Hiển thị UserControl trong một Form mới
                        using (var calendarForm = new Form())
                        {
                            calendarForm.Controls.Add(calendarUserControl);
                            calendarForm.StartPosition = FormStartPosition.Manual;
                            calendarForm.Location = new Point(
                                this.Location.X + (this.Width - calendarForm.Width) / 2,
                                this.Location.Y + (this.Height - calendarForm.Height) / 2
                            );

                            // Thiết lập kích thước (ví dụ: 300x200)
                            calendarForm.Size = new Size(700, 460);


                            calendarForm.ShowDialog();  // Chờ đến khi Form con đóng
                        }

                        var danhSachSanPham = sanphamdal.getThongTinCacSanPhamBanChay_SoLuong_NhomHangHoa_KhoangThoiGian(bd, kt);
                        tao_pieChartTheoDoanhThu_HangHoa(danhSachSanPham);
                        LoadDataToDataGridView_NhomHangHoa(danhSachSanPham);
                        lbl_ngatbatdau.Visible = true;
                    }

                   

                }
            }

            
           
        }
        void frmThongKeHangHoa_Load(object sender, EventArgs e)
        {
            load_pieChart();
        }
        private void AttachMouseHoverEvent(Chart chart)
        {
            chart.Series["Doanhthu"].Points.ToList().ForEach(point =>
            {
                point.ToolTip = point.Tag.ToString();
            });
            chart.GetToolTipText += (sender, e) =>
            {
                if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    var dataPoint = chart.Series["Doanhthu"].Points[e.HitTestResult.PointIndex];
                    e.Text = dataPoint.Tag.ToString();
                }
            };
        }

        private void cbo_thonngke_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_thonngke.SelectedIndex == 0)
            {
                load_pieChart();  
            }
            else if (cbo_thonngke.SelectedIndex == 1 || cbo_thonngke.SelectedIndex == 2 ||                
                     cbo_thonngke.SelectedIndex == 3 || cbo_thonngke.SelectedIndex == 4 ||
                     cbo_thonngke.SelectedIndex == 5 || cbo_thonngke.SelectedIndex ==  6||
                cbo_thonngke.SelectedIndex == 7 || cbo_thonngke.SelectedIndex == 8  ||
                cbo_thonngke.SelectedIndex == 9 || cbo_thonngke.SelectedIndex == 10 
                )            
                load_pieChart();                               
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbo_sapXep_SelectedIndexChanged(object sender, EventArgs e)
        { 
                load_pieChart();  
        }

        private void cbo_nhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_pieChart();
            if(cbo_nhom.SelectedIndex==1)
            {
                lbl_top10.Text = "Top 10 loại món ăn bán chạy";
                lbl_top10.ForeColor = Color.BlueViolet;
            }                
            else
            {
                lbl_top10.ForeColor = Color.Black;
                lbl_top10.Text = "Top 10  món ăn bán chạy";
            }
                
            
           // 
        }

        private void gunaImageButton3_Click(object sender, EventArgs e)
        {
            DataTable dtb = new DataTable();
            DataColumn col1 = new DataColumn("Id");
            DataColumn col2 = new DataColumn("Tenmon");
            DataColumn col3 = new DataColumn("Soluong");
            DataColumn col4 = new DataColumn("Doanhthu");

            dtb.Columns.Add(col1);
            dtb.Columns.Add(col2);
            dtb.Columns.Add(col3);
            dtb.Columns.Add(col4);

            foreach(DataGridViewRow dtgvrow in dtgv_sanpham.Rows)
            {
                DataRow datarow = dtb.NewRow();
                datarow[0] = dtgvrow.Cells[0].Value;
                datarow[1] = dtgvrow.Cells[1].Value;
                datarow[2] = dtgvrow.Cells[2].Value;
                datarow[3] = dtgvrow.Cells[3].Value;

                dtb.Rows.Add(datarow);
            }

            ExportFile a = new ExportFile();
            string loai=cbo_sapXep.SelectedItem.ToString()+ " - "+ cbo_nhom.SelectedItem.ToString();
            string title = "Top 10 sản phẩm bán chạy";
            a.ExportFile_10MonAn(dtb, "Danhsach", title, lbl_ngatbatdau.Text,loai);
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CustomControlThongKe
{
    public partial class MyCustomCalendar : UserControl
    {
        private DateTime startDate;
        private DateTime endDate;
        private bool selectingStartDate = true;
        string ngaybd = "";
        string ngaykt = "";
        string tongsongay = "";
        public event Action<string> DateSelected;

        public MyCustomCalendar()
        {
            InitializeComponent();
            lbl_ngayBatDau.Visible = false;
            lblTongSoNgay.Visible = false;
            lbl_ngayKetThuc.Visible = false;


        }
        public string getNgayBD()
        {
            return ngaybd;
        }
        public string getNgayKT()
        {
            return ngaykt;
        }

        private void CustomCalendar_Load(object sender, EventArgs e)
        {
            // Khởi tạo màu cho khoảng thời gian
            myMonthCalendar.SelectionStart = startDate = DateTime.Today;
            myMonthCalendar.SelectionEnd = endDate = DateTime.Today;

            // Đặt sự kiện DateSelected cho MonthCalendar
            myMonthCalendar.DateSelected += Calendar_DateSelected;

            // Tô màu khoảng thời gian mặc định
            HighlightDateRange(startDate, endDate);
        }

        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (selectingStartDate)
            {
                startDate = e.Start;
                selectingStartDate = false;
            }
            else
            {
                endDate = e.Start;
                selectingStartDate = true;
            }


            // Tô màu khoảng thời gian đã chọn
            HighlightDateRange(startDate, endDate);

            // Hiển thị thông tin về khoảng thời gian đã chọn
            ShowDateRangeInfo(startDate, endDate);

        }
        private void HighlightDateRange(DateTime start, DateTime end)
        {
            myMonthCalendar.RemoveAllBoldedDates();

            // Thêm ngày bắt đầu và kết thúc vào danh sách để tô màu
            while (start <= end || start <= end)
            {
                myMonthCalendar.AddBoldedDate(start);
                start = start.AddDays(1);
            }
            myMonthCalendar.UpdateBoldedDates();
        }

        private void ShowDateRangeInfo(DateTime start, DateTime end)
        {
            string formattedDateStart = start.ToString("dd/MM/yyyy");
            string formattedDateEnd = end.ToString("dd/MM/yyyy");

            lbl_ngayBatDau.Text = formattedDateStart;
            lbl_ngayKetThuc.Text = formattedDateEnd;

            ngaybd = formattedDateStart;
            ngaykt = formattedDateEnd;


            int tsn = Math.Abs((end - start).Days + 1);
            lblTongSoNgay.Text = tsn.ToString();
            tongsongay = tsn.ToString();
            lbl_ngayBatDau.Visible = true;
            lblTongSoNgay.Visible = true;
            lbl_ngayKetThuc.Visible = true;



            /*   MessageBox.Show($"Ngày bắt đầu: {start.ToShortDateString()}\n" +
                               $"Ngày kết thúc: {end.ToShortDateString()}\n" +
                               $"Số ngày trong khoảng: {(end - start).Days + 1} ngày",
                               "Thông tin khoảng thời gian",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);*/
        }






        private void btn_huy_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            // Đóng Form nếu tìm thấy
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string selectedDate = ngaybd + " - " + ngaykt + " - " + tongsongay + " ngày";
            if (DateSelected != null)
            {
                DateSelected.Invoke(selectedDate);
            }

            Form parentForm = this.FindForm();

            // Đóng Form nếu tìm thấy
            if (parentForm != null)
            {
                parentForm.Close();
            }


        }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DieuCheHoaHoc
{
    public partial class TroGiupForm : Form
    {
        public TroGiupForm() {
            InitializeComponent();
        }

        private void TroGiupForm_Load(object sender, EventArgs e) {
            lblAboutUs.Text = "Phần mềm được viết bởi Nhóm 19 - CNTT1." +
                "\nPhần mềm là sản phẩm bài tập lớn của bộ môn Hệ chuyên gia." +
                "\nGVHD: ThS Lê Thị Thuỷ";
            lblHuongDanSuDung.Text = "Cần chọn tệp văn bản chứa tri thức để làm việc!" +
                "\n\nKhi muốn điều chế: " +
                "\n\n1. Chọn chất hóa học đang từ cột bên trái" +
                ", bấm thêm để làm chất hiện có, các chất sau đó sẽ được hiển thị bên cạnh." +
                "\n2. Có thể tìm kiếm chất hóa học trong ô tìm kiếm." +
                "\n3. Chọn chất hóa học cần điều chế bằng cách tương tự." +
                "\n4. Bấm điều chế để tiến hành điều chế!" +
                "\n\n\nKhi muốn thêm hoặc sửa tri thức: " +
                "\n\n----Thêm----" +
                "\n1. Điền các chất vế trái" +
                "\n2. Điền các chất vế phải" +
                "\n3. Điền điều kiện xảy ra phản ứng" +
                "\n4. Bấm vào vị trí ô xem trước để xem trước phản ứng" +
                "\n5. Bấm thêm tri thức để thêm!" +
                "\n\n----Xóa----" +
                "\n1. Chọn phản ứng cần xóa" +
                "\n2. Bấm nút xóa" +
                "\n\n----Lưu ý----" +
                "\nĐể phần mềm chạy tốt nhất vui lòng nhập các chất theo đúng chuẩn.";
        }
    }
}
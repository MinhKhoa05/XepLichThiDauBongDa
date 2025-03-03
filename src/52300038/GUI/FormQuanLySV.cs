using System;
using System.Data;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class FormQuanLySV : Form
    {
        private readonly BUS_SinhVien _busSinhVien = new BUS_SinhVien();
        private bool _luuThem; // Cờ cho biết đang ở chế độ thêm hay sửa

        public FormQuanLySV()
        {
            InitializeComponent();
        }

        private void FormQuanLySV_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadComboBoxQueQuan();
            ClearFields();
            SetButtonState(false, false, false);
            grpThongTinSV.Enabled = false;
        }

        // Load dữ liệu lên DataGridView
        private void LoadData()
        {
            dgvSinhVien.DataSource = _busSinhVien.SelectSinhVien();
        }

        // Load danh sách quê quán lên ComboBox
        private void LoadComboBoxQueQuan()
        {
            cboQueQuan.DataSource = _busSinhVien.SelectQueQuan();
            cboQueQuan.DisplayMember = "QueQuan";
            cboQueQuan.ValueMember = "QueQuan";
        }

        // Làm sạch các textBox
        private void ClearFields()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtHocLuc.Clear();
            cboQueQuan.SelectedIndex = -1;
            dtNgaySinh.Value = DateTime.Today;
        }

        // Đặt trạng thái các nút
        private void SetButtonState(bool sua, bool xoa, bool luu)
        {
            btnSua.Enabled = sua;
            btnXoa.Enabled = xoa;
            btnLuu.Enabled = luu;
        }

        // Xử lý khi nhấn nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            grpThongTinSV.Enabled = true;
            ClearFields();
            txtMaSV.Enabled = true;
            txtMaSV.Focus();

            SetButtonState(false, false, true);
            _luuThem = true;
        }

        // Xử lý khi nhất nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            InitializeForm();
        }

        // Xử lý khi chọn 1 hàng trong DataGridView
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            SetSinhVienData(dgvSinhVien.Rows[e.RowIndex]);
            grpThongTinSV.Enabled = false;
            SetButtonState(true, true, false);
            _luuThem = false;
        }

        // Gán dữ liệu từ DataGridView lên grp_ThongTinSV
        private void SetSinhVienData(DataGridViewRow row)
        {
            txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            txtHocLuc.Text = row.Cells["HocLuc"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaySinh))
            {
                dtNgaySinh.Value = ngaySinh;
            }

            string queQuan = row.Cells["QueQuan"].Value?.ToString();
            cboQueQuan.SelectedIndex = cboQueQuan.FindStringExact(queQuan) >= 0 ? cboQueQuan.FindStringExact(queQuan) : -1;
        }

        // Xử lý khi nhấn nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _busSinhVien.DeleteSinhVien(txtMaSV.Text);
                    ShowMessage("Xóa sinh viên thành công!", MessageBoxIcon.Information);
                    LoadData();
                    InitializeForm();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, MessageBoxIcon.Error);
                }
            }
        }

        // Xử lý khi nhấn nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            grpThongTinSV.Enabled = true;
            txtMaSV.Enabled = false;
            SetButtonState(false, false, true);
            txtHoTen.Focus();

            _luuThem = false;
        }

        // Xử lý khi nhấn nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateSinhVien(out string maSV, out string hoTen, out string queQuan, out DateTime ngaySinh, out decimal hocLuc))
            {
                HandleLuuSinhVien(maSV, hoTen, queQuan, ngaySinh, hocLuc);
            }
        }

        // Xử lý lưu sinh viên
        private void HandleLuuSinhVien(string maSV, string hoTen, string queQuan, DateTime ngaySinh, decimal hocLuc)
        {
            try
            {
                if (_luuThem)
                {
                    _busSinhVien.AddSinhVien(maSV, hoTen, queQuan, ngaySinh, hocLuc);
                    ShowMessage("Thêm sinh viên thành công", MessageBoxIcon.Information);
                }
                else
                {
                    _busSinhVien.UpdateSinhVien(maSV, hoTen, queQuan, ngaySinh, hocLuc);
                    ShowMessage($"Đã cập nhật thông tin cho sinh viên {maSV}", MessageBoxIcon.Information);
                }

                LoadData();
                InitializeForm();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageBoxIcon.Error);
            }
        }

        // Xử lý chỉ cho nhập chữ số và dấu . vào txbHocLuc
        private void txtHocLuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        // Kiểm tra thông tin hợp lệ
        private bool ValidateSinhVien(out string maSV, out string hoTen, out string queQuan, out DateTime ngaySinh, out decimal hocLuc)
        {
            maSV = txtMaSV.Text.Trim();
            hoTen = txtHoTen.Text.Trim();
            queQuan = cboQueQuan.Text.Trim();
            ngaySinh = dtNgaySinh.Value;
            hocLuc = 0;

            // Kiểm tra MaSV
            if (string.IsNullOrWhiteSpace(maSV) || maSV.Length > 4 || !maSV.StartsWith("SV"))
            {
                ShowMessage("Mã sinh viên không hợp lệ! (Bắt đầu bằng 'SV', tối đa 4 ký tự)", MessageBoxIcon.Error);
                txtMaSV.Focus();
                return false;
            }

            // Kiểm tra HoTen
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                ShowMessage("Họ tên không được để trống!", MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }

            // Kiểm tra quê Quán
            if (string.IsNullOrWhiteSpace(queQuan))
            {
                ShowMessage("Quê quán không được để trống!", MessageBoxIcon.Error);
                cboQueQuan.Focus();
                return false;
            }

            // Kiểm tra ngày sinh
            if (ngaySinh >= DateTime.Now)
            {
                ShowMessage("Ngày sinh phải ở trong quá khứ!", MessageBoxIcon.Error);
                dtNgaySinh.Focus();
                return false;
            }

            // Kiểm tra Học lục
            if (!decimal.TryParse(txtHocLuc.Text.Trim(), out hocLuc) || hocLuc > 10.0m || hocLuc < 0.0m)
            {
                ShowMessage("Học lực phải là số từ 0.0 đến 10.0!", MessageBoxIcon.Error);
                txtHocLuc.Focus();
                return false;
            }

            return true;
        }

        // Show Message Box
        private void ShowMessage(string message, MessageBoxIcon icon)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, icon);
        }
    }
}

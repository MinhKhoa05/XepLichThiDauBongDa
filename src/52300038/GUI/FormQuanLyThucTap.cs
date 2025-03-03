using System;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class FormQuanLyThucTap : Form
    {
        private readonly BUS_SinhVien _busSinhVien = new BUS_SinhVien();
        private readonly BUS_DeTai _busDeTai = new BUS_DeTai();
        private readonly BUS_SinhVienDeTai _busSinhVienDeTai = new BUS_SinhVienDeTai();

        private bool _luuThem; // Cờ cho biết đang ở chế độ thêm hay sửa

        public FormQuanLyThucTap()
        {
            InitializeComponent();
        }

        private void FormQuanLyThucTap_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadComboBoxSinhVien();
            LoadComboBoxDeTai();
            LoadComboBoxNoiThucTap();
            ClearFields();
            SetButtonState(false, false, false);
            grpThongTinTT.Enabled = false;
        }

        // Load dữ liệu lên DataGridView
        private void LoadData()
        {
            dgvKetQuaThucTap.DataSource = _busSinhVienDeTai.SelectSinhVienDeTai();

            // Ẩn các cột không muốn hiển thị
            dgvKetQuaThucTap.Columns["MaSV"].Visible = false;
            dgvKetQuaThucTap.Columns["MaDT"].Visible = false;
        }

        // Load danh sách Tên sinh viên lên ComboBox
        private void LoadComboBoxSinhVien()
        {
            cboSinhVien.DataSource = _busSinhVien.SelectMaVaTenSinhVien();
            cboSinhVien.DisplayMember = "HoTen";
            cboSinhVien.ValueMember = "MaSV";
        }

        // Load danh sách tên đề tài lên ComboBox
        private void LoadComboBoxDeTai()
        {
            cboDeTai.DataSource = _busDeTai.SelectMaVaTenDeTai();
            cboDeTai.DisplayMember = "TenDT";
            cboDeTai.ValueMember = "MaDT";
        }

        // Load danh sách nơi thực tập lên ComboBox
        private void LoadComboBoxNoiThucTap()
        {
            cboNoiThucTap.DataSource = _busSinhVienDeTai.SelectNoiThucTap();
            cboNoiThucTap.DisplayMember = "NoiThucTap";
            cboNoiThucTap.ValueMember = "NoiThucTap";
        }

        // Làm sạch các textBox
        private void ClearFields()
        {
            cboSinhVien.SelectedIndex = -1;
            cboDeTai.SelectedIndex = -1;
            cboNoiThucTap.SelectedIndex = -1;

            txtQuangDuong.Clear();
            txtKetQua.Clear();
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
            grpThongTinTT.Enabled = true;
            ClearFields();
            cboSinhVien.Enabled = true;
            cboDeTai.Enabled = true;
            cboSinhVien.Focus();

            SetButtonState(false, false, true);
            _luuThem = true;
        }

        // Xử lý khi nhất nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            InitializeForm();
        }

        // Xử lý khi chọn 1 hàng trong DataGridView
        private void dgvKetQuaThucTap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            SetThucTapData(dgvKetQuaThucTap.Rows[e.RowIndex]);
            grpThongTinTT.Enabled = false;
            SetButtonState(true, true, false);
            _luuThem = false;
        }

        // Gán dữ liệu từ DataGridView lên grp_ThongTinTT
        private void SetThucTapData(DataGridViewRow row)
        {
            cboSinhVien.SelectedValue = row.Cells["MaSV"].Value?.ToString();
            cboDeTai.SelectedValue = row.Cells["MaDT"].Value?.ToString();

            txtKetQua.Text = row.Cells["KetQua"].Value?.ToString();
            txtQuangDuong.Text = row.Cells["QuangDuong"].Value?.ToString();

            string noiThucTap = row.Cells["NoiThucTap"].Value?.ToString();
            cboNoiThucTap.SelectedIndex = cboNoiThucTap.FindStringExact(noiThucTap) >= 0 ? cboNoiThucTap.FindStringExact(noiThucTap) : -1;
        }

        // Xử lý khi nhấn nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string maSV = cboSinhVien.SelectedValue?.ToString();
                    string maDT = cboDeTai.SelectedValue?.ToString();

                    _busSinhVienDeTai.DeleteSinhVienDeTai(maSV, maDT);
                    ShowMessage("Xóa kết quả thực tập thành công!", MessageBoxIcon.Information);
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
            grpThongTinTT.Enabled = true;
            cboSinhVien.Enabled = false;
            cboDeTai.Enabled = false;

            SetButtonState(false, false, true);
            cboNoiThucTap.Focus();

            _luuThem = false;
        }

        // Xử lý khi nhấn nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateSinhVienDeTai(out string maSV, out string maDT, out string noiThucTap, out int quangDuong, out decimal ketQua))
            {
                HandleLuuSinhVienDeTai(maSV, maDT, noiThucTap, quangDuong, ketQua);
            }
        }

        // Xử lý lưu kết quả thực tập
        private void HandleLuuSinhVienDeTai(string maSV, string maDT, string noiThucTap, int quangDuong, decimal ketQua)
        {
            try
            {
                if (_luuThem)
                {
                    _busSinhVienDeTai.AddSinhVienDeTai(maSV, maDT, noiThucTap, quangDuong, ketQua);
                    ShowMessage("Thêm kết quả thực tập thành công", MessageBoxIcon.Information);
                }
                else
                {
                    _busSinhVienDeTai.UpdateSinhVienDeTai(maSV, maDT, noiThucTap, quangDuong, ketQua);
                    ShowMessage($"Đã cập nhật kết quả thực tập thành công!", MessageBoxIcon.Information);
                }

                LoadData();
                InitializeForm();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageBoxIcon.Error);
            }
        }

        // Xử lý chỉ cho nhập chữ số vào txbQuangDuong
        private void txtQuangDuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        // Xử lý chỉ cho nhập chữ số và dấu . vào txbKetQua

        private void txtKetQua_KeyPress(object sender, KeyPressEventArgs e)
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
        private bool ValidateSinhVienDeTai(out string maSV, out string maDT, out string noiThucTap, out int quangDuong, out decimal ketQua)
        {
            maSV = cboSinhVien.SelectedValue?.ToString();
            maDT = cboDeTai.SelectedValue?.ToString();

            noiThucTap = cboNoiThucTap.Text.Trim();
            quangDuong = 0;
            ketQua = 0;

            // Kiểm tra Sinh Vien
            if (string.IsNullOrWhiteSpace(maSV))
            {
                ShowMessage("Sinh viên không được để trống", MessageBoxIcon.Error);
                cboSinhVien.Focus();
                return false;
            }

            // Kiểm tra Đề tài
            if (string.IsNullOrWhiteSpace(maDT))
            {
                ShowMessage("Đề tài không được để trống", MessageBoxIcon.Error);
                cboDeTai.Focus();
                return false;
            }


            // Kiểm tra nơi thực tập
            if (string.IsNullOrWhiteSpace(noiThucTap))
            {
                ShowMessage("Nơi thực tập không được để trống!", MessageBoxIcon.Error);
                cboNoiThucTap.Focus();
                return false;
            }

            // Kiểm tra quảng đượng
            if (!int.TryParse(txtQuangDuong.Text.Trim(), out quangDuong) || quangDuong < 0)
            {
                ShowMessage("Quảng đường phải là một số nguyên không âm!", MessageBoxIcon.Error);
                txtQuangDuong.Focus();
                return false;
            }

            // Kiểm tra Kết quả
            if (!decimal.TryParse(txtKetQua.Text.Trim(), out ketQua) || ketQua > 10.0m || ketQua < 0.0m)
            {
                ShowMessage("Kết quả phải là số từ 0.0 đến 10.0!", MessageBoxIcon.Error);
                txtKetQua.Focus();
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


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class FormQuanLyDeTai : Form
    {
        private readonly BUS_DeTai _busDeTai = new BUS_DeTai();
        private bool _luuThem; // Cờ cho biết đang ở chế độ thêm hay sửa

        public FormQuanLyDeTai()
        {
            InitializeComponent();
        }

        private void FormQuanLyDeTai_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadComboBoxChuNhiem();
            ClearFields();
            SetButtonState(false, false, false);
            grpThongTinDT.Enabled = false;
        }

        // Load dữ liệu lên DataGridView
        private void LoadData()
        {
            dgvDeTai.DataSource = _busDeTai.SelectDeTai();
        }

        // Load danh sách chủ nhiệm lên ComboBox
        private void LoadComboBoxChuNhiem()
        {
            cboChuNhiem.DataSource = _busDeTai.SelectChuNhiem();
            cboChuNhiem.DisplayMember = "ChuNhiem";
            cboChuNhiem.ValueMember = "ChuNhiem";
        }

        // Làm sạch các textBox
        private void ClearFields()
        {
            txtMaDT.Clear();
            txtTenDT.Clear();
            txtKinhPhi.Clear();
            cboChuNhiem.SelectedIndex = -1;
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
            grpThongTinDT.Enabled = true;
            ClearFields();
            txtMaDT.Enabled = true;
            txtMaDT.Focus();

            SetButtonState(false, false, true);
            _luuThem = true;
        }

        // Xử lý khi nhất nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            InitializeForm();
        }

        // Xử lý khi chọn 1 hàng trong DataGridView
        private void dgvDeTai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            SetDeTaiData(dgvDeTai.Rows[e.RowIndex]);
            grpThongTinDT.Enabled = false;
            SetButtonState(true, true, false);
            _luuThem = false;
        }

        // Gán dữ liệu từ DataGridView lên grp_ThongTinSV
        private void SetDeTaiData(DataGridViewRow row)
        {
            txtMaDT.Text = row.Cells["MaDT"].Value?.ToString();
            txtTenDT.Text = row.Cells["TenDT"].Value?.ToString();
            txtKinhPhi.Text = row.Cells["KinhPhi"].Value?.ToString();


            string chuNhiem = row.Cells["ChuNhiem"].Value?.ToString();
            cboChuNhiem.SelectedIndex = cboChuNhiem.FindStringExact(chuNhiem) >= 0 ? cboChuNhiem.FindStringExact(chuNhiem) : -1;
        }

        // Xử lý khi nhấn nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _busDeTai.DeleteDeTai(txtMaDT.Text);
                    ShowMessage("Xóa đề tài thành công!", MessageBoxIcon.Information);
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
            grpThongTinDT.Enabled = true;
            txtMaDT.Enabled = false;
            SetButtonState(false, false, true);
            txtTenDT.Focus();

            _luuThem = false;
        }

        // Xử lý khi nhấn nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateDeTai(out string maDT, out string tenDT, out string chuNhiem, out int kinhPhi))
            {
                HandleLuuSinhVien(maDT, tenDT, chuNhiem, kinhPhi);
            }
        }

        // Xử lý lưu sinh viên
        private void HandleLuuSinhVien(string maDT, string tenDT, string chuNhiem, int kinhPhi)
        {
            try
            {
                if (_luuThem)
                {
                    _busDeTai.AddDeTai(maDT, tenDT, chuNhiem, kinhPhi);
                    ShowMessage("Thêm sinh viên thành công", MessageBoxIcon.Information);
                }
                else
                {
                    _busDeTai.UpdateDeTai(maDT, tenDT, chuNhiem, kinhPhi);
                    ShowMessage($"Đã cập nhật thông tin cho sinh viên {maDT}", MessageBoxIcon.Information);
                }

                LoadData();
                InitializeForm();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MessageBoxIcon.Error);
            }
        }

        // Xử lý chỉ cho nhập chữ số vào ô txtKinhPhi
        private void txtKinhPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Kiểm tra thông tin hợp lệ
        private bool ValidateDeTai(out string maDT, out string tenDT, out string chuNhiem, out int kinhPhi)
        {
            maDT = txtMaDT.Text.Trim();
            tenDT = txtTenDT.Text.Trim();
            chuNhiem = cboChuNhiem.Text.Trim();
            kinhPhi = 0;

            // Kiểm tra MaDT
            if (string.IsNullOrWhiteSpace(maDT) || maDT.Length > 4 || !maDT.StartsWith("DT"))
            {
                ShowMessage("Mã đề tài không hợp lệ! (Bắt đầu bằng 'DT', tối đa 4 ký tự)", MessageBoxIcon.Error);
                txtMaDT.Focus();
                return false;
            }

            // Kiểm tra TenDT
            if (string.IsNullOrWhiteSpace(tenDT))
            {
                ShowMessage("Tên đề tài không được để trống!", MessageBoxIcon.Error);
                txtTenDT.Focus();
                return false;
            }

            // Kiểm tra chủ nhiệm
            if (string.IsNullOrWhiteSpace(chuNhiem))
            {
                ShowMessage("Chủ nhiệm không được để trống!", MessageBoxIcon.Error);
                cboChuNhiem.Focus();
                return false;
            }

            // Kiểm tra Kinh phí
            if (!int.TryParse(txtKinhPhi.Text.Trim(), out kinhPhi) || kinhPhi < 0)
            {
                ShowMessage("Kinh phí phải là số nguyên không âm.", MessageBoxIcon.Error);
                txtKinhPhi.Focus();
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
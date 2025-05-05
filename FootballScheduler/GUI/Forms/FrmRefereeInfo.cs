using System;
using System.Windows.Forms;
using DTO;
using GUI.Helpers;

namespace GUI.Forms
{
    public partial class FrmRefereeInfo : Form
    {
        private readonly RefereeDTO _originalReferee;

        public FrmRefereeInfo(RefereeDTO referee = null)
        {
            InitializeComponent();
            _originalReferee = referee;
        }

        private void FrmRefereeInfo_Load(object sender, EventArgs e)
        {
            if (_originalReferee != null)
                DisplayRefereeInfo(_originalReferee);
            else
                dtpBirthDate.Value = DateTime.Today.AddYears(-20);  // mặc định là 20 tuổi
        }

        private void DisplayRefereeInfo(RefereeDTO referee)
        {
            txtRefereeName.Text = referee.RefereeName;
            txtEmail.Text = referee.Email;
            txtPhone.Text = referee.PhoneNumber;
            dtpBirthDate.Value = referee.BirthDate;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var updatedReferee = CreateRefereeDTO();

            if (!ValidateReferee(updatedReferee))
                return;

            this.Tag = updatedReferee;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private RefereeDTO CreateRefereeDTO()
        {
            return new RefereeDTO
            {
                RefereeID = _originalReferee?.RefereeID,
                RefereeName = txtRefereeName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                BirthDate = dtpBirthDate.Value.Date
            };
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtRefereeName.Text))
            {
                MyMessageBox.ShowWarning("Tên trọng tài không được để trống.");
                txtRefereeName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MyMessageBox.ShowWarning("Email không được để trống.");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MyMessageBox.ShowWarning("Số điện thoại không được để trống.");
                txtPhone.Focus();
                return false;
            }

            if (dtpBirthDate.Value.Date > DateTime.Today.AddYears(-18))
            {
                MyMessageBox.ShowWarning("Trọng tài phải từ 18 tuổi trở lên.");
                dtpBirthDate.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateReferee(RefereeDTO referee)
        {
            if (!ValidatorHelper.TryValidate(referee, out var error))
            {
                MyMessageBox.ShowError(error);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

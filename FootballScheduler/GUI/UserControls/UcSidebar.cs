using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GUI.CustomUI.Buttons;
using GUI.Helpers;

namespace GUI.UserControls
{
    /// <summary>
    /// Sidebar chứa các nút menu cho ứng dụng.
    /// </summary>
    public partial class UcSidebar : UserControl
    {
        private readonly Panel _pnlControl;   // Panel hiển thị UserControl

        public UcSidebar(Panel pnlControl)
        {
            InitializeComponent();
            _pnlControl = pnlControl;
            LoadEventHandlers();  // Đăng ký sự kiện cho các nút menu
        }

        // Tải menu khi UserControl được tải.
        private void UcSidebar_Load(object sender, EventArgs e) => LoadMenuItems();

        // Đăng ký các sự kiện click cho các nút menu chính và các mục con.
        private void LoadEventHandlers()
        {
            // Đăng ký sự kiện click cho các nút menu chính
            btnLeague.Click += (s, e) => ActivateMenuButton(btnLeague);
            btnTeam.Click += (s, e) => ActivateMenuButton(btnTeam);
            btnReferee.Click += (s, e) => ActivateMenuButton(btnReferee);
            AddMenuItemEvents();  // Đăng ký sự kiện cho các mục con
        }

        // Thêm các mục con vào các nút menu chính.
        private void LoadMenuItems()
        {
            btnTeam.AddItem(btnListTeam);  // Thêm mục "List Team" vào nút "Team"
            btnLeague.AddItems(new List<HBMenuItem> { btnListLeague, btnSchedule, btnStandings });  // Thêm các mục vào nút "League"
            btnReferee.AddItems(new List<HBMenuItem> { btnListReferee });  // Thêm các mục vào nút "Referee"
        }

        // Đăng ký sự kiện click cho các mục menu.
        private void AddMenuItemEvents()
        {
            btnListLeague.Click += (s, e) => OpenControls("League");
            btnSchedule.Click += (s, e) => OpenControls("Schedule");
            btnStandings.Click += (s, e) => OpenControls("Standings");
            btnListTeam.Click += (s, e) => OpenControls("Team");
            btnListReferee.Click += (s, e) => OpenControls("Referee");
        }

        // Kích hoạt một nút menu và vô hiệu hóa các nút còn lại.
        private void ActivateMenuButton(HighlightButton activeButton)
        {
            foreach (var button in new[] { btnTeam, btnLeague, btnReferee })
            {
                if (button != activeButton) button.Active = false;  // Vô hiệu hóa các nút không được chọn
            }
        }

        private void OpenControls(string type)
        {
            try
            {
                var control = UcFactory.CreateUserControl(type); // GỌI QUA FACTORY
                UserControlLoader.DisplayUserControl(_pnlControl, control);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowError(ex.Message);  // Hiển thị thông báo lỗi nếu có
            }
        }
    }
}

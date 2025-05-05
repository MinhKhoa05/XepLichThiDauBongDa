using System.Windows.Forms;
using GUI.Cruds;

namespace GUI.UserControls
{
    public partial class UcGridTools : UserControl
    {
        private readonly ICrud _crud;

        public UcGridTools(string type)
        {
            InitializeComponent();
            _crud = CrudFactory.CreateCrud(type, dgv);

            Load += (s, e) => _crud.LoadData();
            dgv.CellClick += (s, e) => UpdateButtonState();
            btnInsert.Click += (s, e) => _crud.Insert();
            btnEdit.Click += (s, e) => _crud.Update();
            btnDelete.Click += (s, e) => _crud.Delete();
            btnExport.Click += (s, e) => _crud.Export();

            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            btnEdit.Enabled = btnDelete.Enabled = dgv.CurrentRow != null;
        }
    }
}

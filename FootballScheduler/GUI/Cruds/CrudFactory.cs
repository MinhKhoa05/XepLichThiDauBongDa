using System;
using System.Windows.Forms;
using GUI.Curds;

namespace GUI.Cruds
{
    public static class CrudFactory
    {
        public static ICrud CreateCrud(string type, DataGridView dgv)
        {
            switch (type)
            {
                case "League":
                    return new LeagueCrud(dgv);
                case "Team":
                    return new TeamCrud(dgv);
                case "Referee":
                    return new RefereeCrud(dgv);
                default:
                    throw new ArgumentException("Invalid CRUD type");
            };
        }
    }
}

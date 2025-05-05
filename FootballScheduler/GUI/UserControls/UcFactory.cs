using System.Windows.Forms;
using System;

namespace GUI.UserControls
{
    public static class UcFactory
    {
        public static UserControl CreateUserControl(string type)
        {
            switch (type)
            {
                case "League":
                case "Team":
                case "Referee":
                    return new UcGridTools(type);
                case "Schedule":
                    return new UcSchedule();
                case "Standings":
                    return new UcStandings();
                default:
                    throw new InvalidOperationException($"Chức năng '{type}' chưa được hỗ trợ :(");
            }
        }
    }
}

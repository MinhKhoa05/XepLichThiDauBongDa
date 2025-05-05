using System;
using System.Windows.Forms;

namespace GUI.Commands
{
    public static class CommandFactory
    {
        public static ICurdCommand CreateCommand(string type, DataGridView dgv)
        {
            switch (type)
            {
                case "Team":
                    return new TeamCommand(dgv);
                case "League":
                    return new LeagueCommand(dgv);
                case "Referee":
                    return new RefereeCommand(dgv);
                default:
                    throw new InvalidOperationException($"Chức năng '{type}' chưa được hỗ trợ :((");
            }
        }
    }
}
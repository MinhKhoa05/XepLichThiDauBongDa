using System.Collections.Generic;
using DTO;

namespace BUS.Strategy
{
    public interface ISchedulerStrategy
    {
        List<MatchDTO> Generate(string leagueID, List<TeamDTO> teams);
    }
}

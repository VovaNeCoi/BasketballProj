using BasketballProj.Models.DB;

namespace BasketballProj.Data.Interfaces
{
    public interface ITeamsReportsManaging
    {
        IEnumerable<Team> teams { get; }
        //IEnumerable<Division> divisions { get; }
        //IEnumerable<Conference> conferences { get; }
    }
}

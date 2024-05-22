using BasketballProj.Data.Interfaces;
using BasketballProj.Models.DB;

namespace BasketballProj.Data.Mocks
{
    public class MockTeamReportsManaging : ITeamsReportsManaging
    {
        public IEnumerable<Team> teams {
            get
            {
                return new List<Team>();
            }
        }

        //public IEnumerable<Division> divisions{
        //    get
        //    {
        //        return new List<Division>();
        //    }
        //}

        //public IEnumerable<Conference> conferences
        //{
        //    get
        //    {
        //        return new List<Conference>();
        //    }
        //}
    }
}

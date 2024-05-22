using BasketballProj.Data.Interfaces;
using BasketballProj.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BasketballProj.Data.Repository
{
    public class TeamsReportsManagingRepository : ITeamsReportsManaging
    {
        private readonly NbaContext _context;
        public TeamsReportsManagingRepository(NbaContext context)
        {
            this._context = context;
        }

            public IEnumerable<Team> teams => _context.Teams;

        //public IEnumerable<Division> divisions => throw new NotImplementedException();

        //public IEnumerable<Conference> conferences => throw new NotImplementedException();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System_do_licencji.Models
{
    public class ClubRepository : IClubRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClubRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Club> GetAllClubs()
        {
            return _appDbContext.Clubs ;
        }

        public Club GetClubInfo(int clubId)
        {
            return _appDbContext.Clubs.FirstOrDefault(s => s.Id == clubId);
        }
    }
}

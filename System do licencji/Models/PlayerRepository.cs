using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System_do_licencji.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        public IEnumerable<Player> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer(int playerId)
        {
            throw new NotImplementedException();
        }
    }
}

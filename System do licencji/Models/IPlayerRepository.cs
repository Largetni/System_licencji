using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System_do_licencji.Models
{
    interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayer(int playerId);

    }
}

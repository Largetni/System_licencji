using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System_do_licencji.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _appDbContext;

        public PlayerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _appDbContext.Players;
        }

        public Player GetPlayer(string playerId)
        {
            return _appDbContext.Players.FirstOrDefault(s => s.Id == playerId);
        }

        public void EdytujSamochod(Player player)
        {
            _appDbContext.Players.Update(player);
            _appDbContext.SaveChanges();
        }
    }
}

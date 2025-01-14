using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameManagement.Entites;
using GameManagement.Entites.ReponseType;
using GameManagement.Entites.RequestFeatures;

namespace GameManagement.Contracts
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        PagedList<Player> GetPlayers(PlayerParameter playerParameter);
        Task<Player?> GetPlayerById(Guid playerId);
        Task<Player?> GetPlayerWithCharacters(Guid playerId);
        //void CreatePlayer(Player player);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameManagement.Contracts;
using GameManagement.Entites;
using GameManagement.Entites.ReponseType;
using GameManagement.Entites.RequestFeatures;
using GameManagement.EntityFramework.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GameManagement.EntityFramework.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(GameManagementDbContext GMDbContext) : base(GMDbContext) { }

        //public void CreatePlayer(Player player)
        //{
        //    Create(player);
        //}

        public PagedList<Player> GetPlayers(PlayerParameter playerParameter)
        {
            return FindByCondition(player => player.DateCreated.Date >= playerParameter.MinDateCreated && player.DateCreated <= playerParameter.MaxDateCreated)
                .SearchByAccount(playerParameter.Account).OrderByQuery(playerParameter.OrderBy).ToPagedList(playerParameter.PageNumber, playerParameter.PageSize);
        }

        public async Task<Player?> GetPlayerById(Guid playerId)
        {
            return await FindByCondition(p => p.Id == playerId).FirstOrDefaultAsync();
        }

        public async Task<Player?> GetPlayerWithCharacters(Guid playerId)
        {
            return await FindByCondition(p => p.Id == playerId).Include(p => p.Characters).FirstOrDefaultAsync();
            //return await FindByCondition(p => p.Id == playerId).FirstOrDefaultAsync();这个返回的值中，characs是null
        }
    }
}

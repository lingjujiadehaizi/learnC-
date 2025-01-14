using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameManagement.Entites;

namespace GameManagement.EntityFramework.Repositories.Extensions
{
    public static class PlayerRepositoryExtensions
    {
        public static IQueryable<Player> SearchByAccount(this IQueryable<Player> players, string account)
        {
            if (string.IsNullOrWhiteSpace(account))
            {
                return players;
            }
            return players.Where(p => p.Account.ToLower().Contains(account.Trim().ToLower()));
        }
    }
}

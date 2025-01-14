using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameManagement.Contracts;
using GameManagement.Entites;

namespace GameManagement.EntityFramework.Repositories
{
    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(GameManagementDbContext GMDbcontext) : base(GMDbcontext) { }
    }
}

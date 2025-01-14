using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameManagement.Contracts;
using GameManagement.EntityFramework.Repositories;

namespace GameManagement.EntityFramework
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly GameManagementDbContext _gameDbContext;
        private IPlayerRepository _player;
        private ICharacterRepository _character;
        public RepositoryWrapper(GameManagementDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }
        public IPlayerRepository Player
        {
            get { return _player ??= new PlayerRepository(_gameDbContext); }
        }

        public ICharacterRepository Game
        {
            get { return _character ??= new CharacterRepository(_gameDbContext); }
        }

        public Task<int> Save()
        {
            return _gameDbContext.SaveChangesAsync();
        }
    }
}

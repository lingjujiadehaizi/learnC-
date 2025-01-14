using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagement.Contracts
{
    public interface IRepositoryWrapper
    {
        IPlayerRepository Player { get; }
        ICharacterRepository Game { get; }
        Task<int> Save();
    }
}

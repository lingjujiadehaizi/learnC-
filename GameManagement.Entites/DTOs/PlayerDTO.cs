using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagement.Entites.DTOs
{
    public class PlayerDTO
    {
        public Guid Id { get; set; }
        public string Account { get; set; }
        public string AccountType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

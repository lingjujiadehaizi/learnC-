using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagement.Entites.RequestFeatures
{
    public class PlayerParameter : QueryStringParameters
    {
        public PlayerParameter()
        {
            OrderBy = "account";
        }
        public DateTime MinDateCreated { get; set; }
        public DateTime MaxDateCreated { get; set; } = DateTime.Now;

        public bool ValidDateCreatedRange => MaxDateCreated > MinDateCreated;
        public string? Account {  get; set; }
    }
}

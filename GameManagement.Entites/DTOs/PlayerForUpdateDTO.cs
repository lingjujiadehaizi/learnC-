using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagement.Entites.DTOs
{
    public class PlayerForUpdateDTO
    {
        [Required(ErrorMessage = "账号类型不能为空")]
        [StringLength(10, ErrorMessage = "账号类型不能大于10")]
        public string AccountType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManagement.Entites.DTOs
{
    public class PlayerForCreationDTO
    {
        [Required(ErrorMessage = "账号不能为空")]
        [StringLength(20, ErrorMessage = "账号成都不能大于20")]
        public string Account { get; set; }

        [Required(ErrorMessage = "账号类型不能为空")]
        [StringLength(10, ErrorMessage = "账号类型不能大于10")]
        public string AccountType { get; set; }
    }
}

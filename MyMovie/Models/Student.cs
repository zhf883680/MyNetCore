using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int No { get; set; }


        [Display(Name="姓名")]  //for label  
       
        [Required(ErrorMessage = "此项不能为空")]
        [StringLength(100,ErrorMessage="长度不能超过100")]
        public string Name { get; set; }

        [Range(0,120,ErrorMessage = "超过大小")]
        public int Age { get; set; }
        public Gender Gender { get; set; }

        [DataType(DataType.DateTime,ErrorMessage = "请选择时间")]
        public DateTime RegTime { get; set; }


        [Required(ErrorMessage = "此项不能为空")]
        [DataType(DataType.Password)]//密码 type=password
        public string Password { get; set; }


        [Required(ErrorMessage = "此项不能为空")]
        [DataType(DataType.Password)]//密码 type=password
        [Compare("Password", ErrorMessage = "2次密码不一致")]
        public string ConfirmPassword { get; set; }
    }
}

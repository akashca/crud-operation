using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MvcCore.Models
{
    public class NewEmpClass
    {
        [Key]
        public int Empid { get; set; }

        [Required(ErrorMessage ="Enter employee Name")]
        [Display(Name ="Employee Name")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Enter employee Email")]
        [Display(Name = " Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter employee Age")]
        [Display(Name = " Age")]
        [Range(20,60)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter employee Salary")]
        [Display(Name = " Salary")]
        public int Salary { get; set; }

    }
}

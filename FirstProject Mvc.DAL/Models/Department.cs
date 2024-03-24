using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_Mvc.DAL.Models
{ // Model 
    public class Department
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Display(Name= "Date Of Creation")]
        public DateTime DateOfCreation{ get; set; }

    }
}

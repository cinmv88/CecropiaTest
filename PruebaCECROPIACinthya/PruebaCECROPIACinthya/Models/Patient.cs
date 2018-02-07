using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCECROPIACinthya.Models
{
    [Table("PatientTB")]
    public class Patient
    {
        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }
        [Key]
        public string ID { get; set; }
        public Nullable<System.DateTime> DateBirth { get; set; }
        public Nullable<int> Nationality { get; set; }
        public string Diseases { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> BloodType { get; set; }

      /*  public virtual BloodType BloodType1 { get; set; }
        public virtual Country Country { get; set; }*/

    }
}


    

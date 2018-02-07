//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public Nullable<System.DateTime> DateBirth { get; set; }
        public Nullable<int> Nationality { get; set; }
        public string Diseases { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> BloodType { get; set; }
    
        public virtual BloodType BloodType1 { get; set; }
        public virtual Country Country { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataEdmx
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public Users()
        {
            this.Doctors = new HashSet<Doctors>();
            this.Patient = new HashSet<Patient>();
            this.Staff = new HashSet<Staff>();
        }
    
        public int ID { get; set; }
        public string Password { get; set; }
        public System.DateTime Last_Login { get; set; }
        public int AccessLevel { get; set; }
    
        public virtual AccessLevel AccessLevel1 { get; set; }
        public virtual ICollection<Doctors> Doctors { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}

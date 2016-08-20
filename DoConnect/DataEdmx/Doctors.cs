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
    
    public partial class Doctors
    {
        public Doctors()
        {
            this.Appointments = new HashSet<Appointments>();
            this.Invoice = new HashSet<Invoice>();
            this.Patient = new HashSet<Patient>();
            this.Prescription = new HashSet<Prescription>();
        }
    
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Practice_ID { get; set; }
        public int User_ID { get; set; }
        public string Job_Title { get; set; }
    
        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual Practice Practice { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}

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
    
    public partial class Medical_Aid
    {
        public Medical_Aid()
        {
            this.Invoice = new HashSet<Invoice>();
            this.Patient = new HashSet<Patient>();
            this.Patient_Medical_Aid = new HashSet<Patient_Medical_Aid>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Cell_Number { get; set; }
        public string Fax_Number { get; set; }
        public string Email_Address { get; set; }
        public string Address { get; set; }
        public int User_ID { get; set; }
    
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Patient_Medical_Aid> Patient_Medical_Aid { get; set; }
    }
}

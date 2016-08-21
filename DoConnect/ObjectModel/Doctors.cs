using System;
using System.Collections.Generic;

namespace ObjectModel
{
    public class Doctor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public string Job_Title { get; set; }
        public int UserId { get; set; }
        public int PracticeId { get; set; }
    }

    public class DoctorProfile : BaseEntity
    {
        public Doctor Doc { get; set; }

        public DoctorProfile()
        {
            if (Doc == null)
            {
                Doc = new Doctor();
            }
        }
    }
}

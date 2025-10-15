using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class Medic : CommonData
    {
        public int MedicId { get; set; }

        public string PictureUrl { get; set; }

        //Relation    office <- 1:1 -> medic
        public int OfficeId { get; set; }
        public Office Office { get; set; }

        public int SpecialItyId { get; set; }
        public Speciality Speciality { get; set; }


        // Relation   medic <-  1:M  -> appointments, specialitys, schedules

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        //public ICollection<MedicSpeciality> MedicSpecialties { get; set; }




        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();




    }
}

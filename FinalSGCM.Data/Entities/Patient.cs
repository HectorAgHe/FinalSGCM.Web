using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class Patient : CommonData
    {

        public int PatientId { get; set; }

        public DateTime Date { get; set; }





        // Relation 1:1 with MedicalHistory
        public MedicalHistory MedicalHistory { get; set; }


        // patient <- 1 : M -> appointments, prescriptions
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();


    }
}

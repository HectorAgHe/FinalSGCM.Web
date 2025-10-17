using FinalSGCM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.DTOs
{
    public class PatientCreateDto : CommonDataDto
    {

        public int PatientId { get; set; }

        public DateTime Date { get; set; }







        //    // Relation 1:1 with MedicalHistory
        //    public MedicalHistory MedicalHistory { get; set; }


        //    // patient <- 1 : M -> appointments, prescriptions
        //    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        //    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

        //    public string appointmentId { get; set; } // puede ser null al crear

        //    public string PrescriptionId { get; set; }
       
       
    }
}

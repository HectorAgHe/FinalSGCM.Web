using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class MedicalHistory
    {
        public int MedicalHistoryId { get; set; }




        public DateTime CreatedDate { get; set; }

        // Diagnostics
        public string Diagnoses { get; set; }

        public string Allergies { get; set; }

        public string ChronicConditions { get; set; }

        // Cirugías previas
        public string Surgeries { get; set; }

        public string CurrentMedications { get; set; }


        public string Notes { get; set; }

        // Relación con el paciente
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        // Relación con recetas médicas

        public ICollection<Prescription> Prescriptions { get; set; }

        // Relación con citas médicas (opcional)
        public ICollection<Appointment> Appointments { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Notes { get; set; }





        // Relation Medic
        public int MedicId { get; set; }
        public Medic Medic { get; set; }

        // Relation with Paciente
        public int PatientId { get; set; }
        public Patient Patient { get; set; }


        // Relation M : M
        public ICollection<PrescriptionProduct> PrescriptionProducts { get; set; }
        public ICollection<MedicationProduct> MedicationProducts { get; set; }




    }
}

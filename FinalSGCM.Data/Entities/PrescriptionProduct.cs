using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class PrescriptionProduct
    {
        public int PrescriptionProductId { get; set; }

        // Campos adicionales por producto en la receta
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }


        // Forgein key
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }


        public int MedicationProductId { get; set; }
        public MedicationProduct MedicationProduct { get; set; }

    }
}

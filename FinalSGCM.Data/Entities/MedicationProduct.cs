using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class MedicationProduct
    {
        public int MedicationProductId { get; set; }

        public string ProductName { get; set; }
        public string Description { get; set; }



        public ICollection<PrescriptionProduct> PrescriptionProducts { get; set; }
    }
}

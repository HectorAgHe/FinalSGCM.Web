using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class MedicSpeciality
    {
        public int MedicSpecialityId { get; set; }
        public int MedicId { get; set; }
        public Medic Medic { get; set; }

        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class Speciality
    {
        public int SpecialityId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Medic> Medics { get; set; } = new List<Medic>();






    }
}

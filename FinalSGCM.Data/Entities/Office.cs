using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string Ubication { get; set; }

       public ICollection<Medic>Medics { get; set; } = new List<Medic>();

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

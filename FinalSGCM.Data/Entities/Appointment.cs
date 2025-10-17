using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Reason { get; set; } = string.Empty;

        public ICollection<Office> Offices { get; set; } = new List<Office>();

        public int MedicId { get; set; }
        public Medic Medic { get; set; }



    }
}

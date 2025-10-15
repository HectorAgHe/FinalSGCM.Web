using System;
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





        /*fk que apunta a la entidad llamada Pacient*/
        public int PatientId { get; set; }
        public Patient Patient { get; set; }


        public int MedicId { get; set; }
        public Medic Medic { get; set; }


    }
}

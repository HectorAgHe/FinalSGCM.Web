using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.DTOs
{
    public class AppointmentReadDto
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
         public string Reason { get;set }
        public int PatientId { get; set; }
        public int MedicId { get; set; }
    }
}

using FinalSGCM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.DTOs
{
    public class OfficeCreateDto
    {
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string Ubication { get; set; }

            
        // Relacion 1:1 with Medics
        public int MedicId { get; set; }


        // No se incluye si no se necesita
        //public ICollection<Appointment> Appointment { get; set; }
    }
}

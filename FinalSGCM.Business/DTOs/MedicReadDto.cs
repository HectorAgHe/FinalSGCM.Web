using FinalSGCM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.DTOs
{
    public class MedicReadDto : CommonDataDto
    {
        public int MedicId { get; set; }
        public string PictureUrl { get; set; }

        public string OfficeName { get; set; }
        //public string Ubication { get; set; }
        public string SpecialtyName { get; set; }
       
    }
}

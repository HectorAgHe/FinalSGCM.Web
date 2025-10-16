using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.DTOs
{
    public class MedicCreateDto : CommonDataDto
    {
        public int? MedicId { get; set; }
        public int? SpecialityId { get; set; }
        public int? OfficeId { get; set; }

        public string PictureUrl { get; set; }
    }
}

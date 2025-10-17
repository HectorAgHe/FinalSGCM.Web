using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.DTOs
{
    public class UserReadDto: CommonDataDto
    {

        public int UserId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string UserType { get;  set; }
    }
}

using Microsoft.AspNetCore.Http;
using SGCM.data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.DTOs
{
    public class UserCreateDto : CommonDataDto
    {
        public int UserId { get; set; }
        public string ImageUrl { get; set; }
        public UserType UserType { get; set; }

        //public IFormFile File { get; set; }


    }

}

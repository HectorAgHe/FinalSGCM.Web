using FinalSGCM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCM.data.Entitites
{

    public enum UserType
    {
        Administrator = 0,
        Medic = 1
    }

    public class User : CommonData
    {
        public int UserId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public UserType UserType { get; set; }

    }
}

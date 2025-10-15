using FinalSGCM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCM.data.Entitites
{
    public class User : CommonData
    {

        public int UserId { get; set; }

        // CommonData

        public enum TypeUser
        {
            Administrator,
            Medic,
        }

        public TypeUser TypesUser { get; set; }

    }
}

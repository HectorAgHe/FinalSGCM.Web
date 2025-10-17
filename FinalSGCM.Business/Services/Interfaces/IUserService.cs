using FinalSGCM.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.Services.Interfaces
{
    public interface IUserService : IGenericService< UserCreateDto, UserReadDto,UserCreateDto >
    {
        
    }
}

using FinalSGCM.Business.DTOs;
using SGCM.data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.Services.Interfaces
{
    public interface IGenericService<TCreateDto, TReadDto, TUpdateDto>
       where TCreateDto : class // Asi restringimos que deba ser una clase o una interfaz
        where TReadDto : class
        where TUpdateDto : class
    {

        ///


        Task<IEnumerable<TReadDto>> GetAllAsync();

        Task<TReadDto> GetByIdAsync(int UserId);

        Task AddAsync(TCreateDto productDTO);

        Task UpdateAsync(int UserId, TUpdateDto UpdateDto);
        Task DeleteAsync(int iUserIdd);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.Services.Interfaces
{
    public interface IGenericService<TReadDto,TCreateDto,TUpdateDto>
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<IEnumerable<TReadDto>> GetAllAsync();
        Task<TReadDto> GetByIdAsync(int id);
        Task AddAsync(TCreateDto dto);
        Task UpdateAsync(int id,TUpdateDto dto);
        Task DeleteAsync(int id);
    }
}

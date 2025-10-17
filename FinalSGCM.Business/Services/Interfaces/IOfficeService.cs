using FinalSGCM.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.Services.Interfaces
{
    public interface IOfficeService
    {
        Task<IEnumerable<OfficeReadDto>> GetAllAsync();

        Task<OfficeReadDto> GetByIdAsync(int OfficeId);

        Task AddAsync(OfficeCreateDto officeCreateDto);

        Task UpdateAsync(int OfficeId, OfficeCreateDto officeUpdateDto);

        Task DeleteAsync(int OfficeId);
    }
}

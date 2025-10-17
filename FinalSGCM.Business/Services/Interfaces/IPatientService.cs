using FinalSGCM.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientReadDto>> GetAllAsync();

        Task<PatientReadDto> GetByIdAsync(int PatientId);

        Task AddAsync(PatientCreateDto patientCreateDto);

        Task UpdateAsync(int PatientId, PatientCreateDto patientCreateDto);

        Task DeleteAsync(int PatientId);


    }
}

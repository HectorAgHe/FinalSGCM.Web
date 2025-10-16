using FinalSGCM.Business.DTOs;
using FinalSGCM.Business.Services.Interfaces;
using FinalSGCM.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.Services.Implementations
{
    public class PatientService : IPatientService
    {

        private readonly ApplicationDbContext _context;        
        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientReadDto>> GetAllAsync()
        {
            var patiens = await _context.Patients
                .Include(o => o.Prescriptions)
                .Include(o=> o.Prescriptions)
                .Select(p => new PatientReadDto
                {
                    PatientId = p.PatientId,
                    Name = p.Name,
                    LastName = p.LastName,
                    Email = p.Email,
                    Phone = p.Phone,
                    Date =p.Date,
                    
                    
                }).ToListAsync();
            return patiens;
        }


        







    }
}

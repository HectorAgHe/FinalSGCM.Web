using FinalSGCM.Business.DTOs;
using FinalSGCM.Business.Services.Interfaces;
using FinalSGCM.Data.Data;
using FinalSGCM.Data.Entities;
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


        public async Task<PatientReadDto> GetByIdAsync(int PatientId)
        {
            var patien = await _context.Patients
                
                .Where(p => p.PatientId == PatientId)
                .Select(p => new PatientReadDto
                {
                    PatientId = p.PatientId,
                    Name = p.Name,
                    LastName = p.LastName,
                    Email = p.Email,
                    Phone = p.Phone,
                    Date = p.Date,

                }).FirstOrDefaultAsync();
            return patien;
        }



        public async Task AddAsync(PatientCreateDto patientCreateDto)
        {

            // Here most Include Bussines Logic Please if you are Reading it
            var patient = new Patient
            {
                Name = patientCreateDto.Name,
                LastName = patientCreateDto.LastName,
                Date = patientCreateDto.Date,
                Email = patientCreateDto.Email,
                Phone = patientCreateDto.Phone,
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

        }


        public async Task UpdateAsync(int PatienId, PatientCreateDto patientCreateDto)
        {
            var patient = await _context.Patients
                .FindAsync(PatienId);

            if(patient == null)
            {
                throw new ApplicationException("Error al actualizar");
            }

            patient.Name = patientCreateDto.Name;
            patient.LastName = patientCreateDto.LastName;
            patient.Date = patientCreateDto.Date;
            patient.Email = patientCreateDto.Email;
            // Puedo agregar info de otraa entidades.


        }


        public async Task DeleteAsync(int PatientId)
        {
            var patient = await _context.Patients
                .FindAsync(PatientId);

            if(patient == null)
            {
                throw new ApplicationException($"Patient ${PatientId} not Found");
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

    }
}

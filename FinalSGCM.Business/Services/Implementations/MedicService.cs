using FinalSGCM.Business.DTOs;
using FinalSGCM.Business.Services.Interfaces;
using FinalSGCM.Data.Data;
using FinalSGCM.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.Services.Implementations
{
    public class MedicService : IMedicService
    {
        private readonly ApplicationDbContext _context;
        public MedicService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicReadDto>> GetAllAsync()
        {
            var medics = await _context.Doctors.Select(d => new MedicReadDto
            {
                MedicId = d.MedicId,
                Name = d.Name,
                LastName = d.LastName,
                Email = d.Email,
                Phone = d.Phone,
                PictureUrl = d.PictureUrl,
                OfficeName = d.Office.OfficeName,
                SpecialtyName = d.Speciality.Name
            }).ToListAsync();
            return medics;
        }
        public async Task<MedicReadDto> GetByIdAsync(int id)
        {
            var medic = await _context.Doctors.Where(d => d.MedicId == id)
                .Select(d => new MedicReadDto
                {
                    MedicId = d.MedicId,
                    Name = d.Name,
                    LastName = d.LastName,
                    Email = d.Email,
                    Phone = d.Phone,
                    PictureUrl = d.PictureUrl,
                    OfficeName = d.Office.OfficeName,
                    SpecialtyName = d.Speciality.Name
                }).FirstOrDefaultAsync();
            return medic;
        }
        public async Task  AddAsync(MedicCreateDto dto) {
            var medicsInOffice = await _context.Doctors.CountAsync(d => d.OfficeId == dto.OfficeId);
            if (dto.OfficeId == 0)
            {
                throw new ApplicationException("El medico requiere ser asignado a un consultorio");
            }
            if (dto.SpecialityId==0)
            {
                throw new ApplicationException("El medico requiere una especialidad");
            }
            if (medicsInOffice >= 3)
            {
                throw new ApplicationException("No se pueden asignar más de 3 medicos a un consultorio.");
            }

            var medic = new Medic
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                SpecialityId = dto.SpecialityId,
                OfficeId = dto.OfficeId,
                PictureUrl = dto.PictureUrl
            };
            await _context.AddAsync(medic);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, MedicCreateDto dto)
        {
            var medic =  await _context.Doctors.FindAsync(id);
            if(medic == null)
            {
                throw new ApplicationException(message : "el medico a actualizar no fue encontrado");
                return;
            }
            medic.Name = dto.Name;
            medic.LastName = dto.LastName;
            medic.Email = dto.Email;
            medic.Phone = dto.Phone;
            medic.SpecialityId = dto.SpecialityId;
            medic.OfficeId = dto.OfficeId;
            _context.Doctors.Update(medic);
            await _context.SaveChangesAsync();
             
        }
        public async Task DeleteAsync(int id)
        {
            var medic = _context.Doctors.Find(id);
            if(medic == null)
            {
                throw new ApplicationException(message: "El medico a eliminar no fue encontrado");
                return;
            }
            _context.Doctors.Remove(medic);
            _context.SaveChanges();
        }

    }
}

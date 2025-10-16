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
    public class SpecialityService : ISpecialityService 
    {
        private readonly ApplicationDbContext _context;
        public SpecialityService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SpecialityReadDto>> GetAllAsync()
        {
           var specialties = await _context.Specialties.Select(s=> new SpecialityReadDto
           {
               SpecialityId = s.SpecialityId,
               Name = s.Name,
               Description = s.Description,
           }).ToListAsync();
            return specialties;
        }
        public async Task<SpecialityReadDto> GetByIdAsync(int id)
        {
            var speciality = await _context.Specialties.Where(s => s.SpecialityId == id).Select(s => new SpecialityReadDto
            {
                SpecialityId = s.SpecialityId,
                Name = s.Name,
                Description = s.Description,
            }).FirstOrDefaultAsync();
            return speciality;
        }
        public async Task AddAsync(SpecialityCreateDto dto) {
            var speciality = new Speciality
            {
                SpecialityId = dto.SpecialityId,
                Name = dto.Name,
                Description = dto.Description,
            };
            _context.Specialties.Add(speciality);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, SpecialityCreateDto dto)
        {
            var speciality = await _context.Specialties.FindAsync(id);
            if (speciality == null) {
                throw new ApplicationException("No se encontro la especialidad a editar");
            }
            speciality.Name = dto.Name;
            speciality.Description = dto.Description;
            _context.Specialties.Update(speciality);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var speciality = await _context.Specialties.FindAsync(id);
            if (speciality == null) {
                throw new ApplicationException("No se encontro la especialidad a eliminar");
            }
            _context.Specialties.Remove(speciality);
            await _context.SaveChangesAsync();
        }
    }
}

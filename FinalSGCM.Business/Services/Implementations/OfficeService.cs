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
    public class OfficeService : IOfficeService
    {
        private readonly ApplicationDbContext _context;

        public OfficeService(ApplicationDbContext context)
        {
            _context = context;
        }
       public async Task<IEnumerable<OfficeReadDto>> GetAllAsync()
        {
            var offices = await _context.Offices.Select(o => new OfficeReadDto
            {
                OfficeId = o.OfficeId,
                OfficeName = o.OfficeName,
                Ubication = o.Ubication
            }).ToListAsync();
            return offices;
        }
       public async Task<OfficeReadDto> GetByIdAsync(int id)
        {
            var office = await _context.Offices.Where(o => o.OfficeId == id).Select(o => new OfficeReadDto
            {
                OfficeId = o.OfficeId,
                OfficeName = o.OfficeName,
                Ubication = o.Ubication
            }).FirstOrDefaultAsync();
            return office;
        }
        public async Task AddAsync(OfficeCreateDto dto)
        {
            var countOffices = _context.Offices.Count();
            if(countOffices >= 4)
            {
                throw new ApplicationException("no se pueden asignar mas de 4 consultorios");
            }
            var office = new Office
            {
                OfficeName = dto.OfficeName,
                Ubication = dto.Ubication
            };
            _context.Offices.Add(office);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, OfficeCreateDto dto)
        {
            var office = await _context.Offices.FindAsync(id);
            if (office == null) {
                throw new ApplicationException("No se encontro el consultorio a editar");
            }
            office.OfficeName = dto.OfficeName;
            office.Ubication = dto.Ubication;
            _context.Offices.Update(office);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var office = await _context.Offices.FindAsync(id);
            if(office == null)
            {
                throw new ApplicationException("No se encontro el consultorio a eliminar");
            }
            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();
        }
        
    }
}

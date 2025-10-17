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

        //1.instanciamos nuestro _context
        private readonly ApplicationDbContext _context;

        //2.Declaramos el constructor
        public OfficeService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<OfficeReadDto>> GetAllAsync()
        {
            var offices = await _context.Offices
                
                .Select(o => new OfficeReadDto
                {
                    OfficeId = o.OfficeId,
                    OfficeName = o.OfficeName,
                    Ubication = o.Ubication,
                    //Medic = o.Medic
                    //Medic = o.Medic,  // Duda
                    
                }).ToListAsync();
            return offices;
        }

        public async Task<OfficeReadDto> GetByIdAsync(int OfficeId)
        {
            var office = await _context.Offices
                //.Include(o => o.Medic) // Incluye los datos del médico relacionado
                .Where(o => o.OfficeId == OfficeId)
                .Select(o => new OfficeReadDto
                {
                    OfficeId = o.OfficeId,
                    OfficeName = o.OfficeName,
                    Ubication = o.Ubication,
                    //Medic = o.Medic
                    //Ubication = o.Ubication,
                    //MedicId = o.Medic.MedicId,
                    //MedicName = o.Medic.FullName,
                    //MedicSpecialty = o.Medic.Specialty
                })
                .FirstOrDefaultAsync();

            return office;
        }







        public async Task AddAsync(OfficeCreateDto officeCreateDto)
        {

            var countOffices = _context.Offices.Count();
            if (countOffices > 3)
            {
                throw new ApplicationException("No se puede asignar el consultorio a mas de 4");
            }
            var office = new Office
            {
                OfficeName = officeCreateDto.OfficeName,
                Ubication = officeCreateDto.Ubication,
                
                
                //You can add the medic which you want assign
            };
            _context.Offices.Add(office);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int OfficeId, OfficeCreateDto officeCreateDto)
        {
            var office = await _context.Offices
                .FindAsync(OfficeId);

            if (office == null)
            {
                throw new ApplicationException("Error al actualizar");
            }

            office.OfficeName = officeCreateDto.OfficeName;
            office.Ubication = officeCreateDto.Ubication;
            office.Medics = office.Medics;
            
            

            // Buscar el médico por ID
            //var medic = await _context.Doctors.FindAsync(officeCreateDto.MedicId);
            //if (medic == null)
            //{
            //    throw new ApplicationException($"Medic not found {officeCreateDto.MedicId}");
            //}

            //office.Medic = medic;

            _context.Offices.Update(office);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int OfficeId)
        {
            var office = await _context.Offices
                .FindAsync(OfficeId);

            if(office == null)
            {
                throw new ApplicationException($"Office with ID {OfficeId} not found."); // sustituir por exepciones personalizadas                                                                 
            }
            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();


        }



    }
}

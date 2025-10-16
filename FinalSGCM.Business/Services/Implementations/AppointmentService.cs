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
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        public AppointmentService(ApplicationDbContext context)
        {
            _context = context
        }

        public async Task<IEnumerable<AppointmentReadDto>> GetAllAsync()
        {
            var appointments = await _context.Appointments.Select(a => new AppointmentReadDto
            {
                AppointmentId = a.AppointmentId,
                Date = a.Date,
                Reason = a.Reason,
                PatientId = a.PatientId,
                MedicId = a.MedicId
            }).ToListAsync();
            return appointments;
        }
        public async Task<AppointmentReadDto> GetByIdAsync(int id)
        {
            var appointment = await _context.Appointments.Where(a => a.AppointmentId == id).Select(a => new AppointmentReadDto
            {
                AppointmentId = a.AppointmentId,
                Date = a.Date,
                Reason = a.Reason,
                PatientId = a.PatientId,
                MedicId = a.MedicId
            }).FirstOrDefaultAsync();
            return appointment;
        }
        public async Task AddAsync(AppointmentCreateDto dto) {
            var appointmentExists = _context.Appointments.Where(a => a.Date == dto.Date);
            if (appointmentExists.Any()) {
                throw new ApplicationException("Esta fecha y hora ya esta ocupada");
            }
            var appointment = new Appointment
            {
                Date = dto.Date,
                Reason = dto.Reason,
                PatientId = dto.PatientId,
                MedicId = dto.MedicId
            };
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, AppointmentCreateDto dto)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) {
                throw new ApplicationException("No se encontro la cita a editar");
            }
            appointment.Date = dto.Date;
            appointment.Reason = dto.Reason;
            appointment.PatientId = dto.PatientId;
            appointment.MedicId = dto.MedicId;
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        } 
        public async Task DeletAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if(appointment == null)
            {
                throw new ApplicationException("No se encontro la cita para eliminar");
            }
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    } 
}

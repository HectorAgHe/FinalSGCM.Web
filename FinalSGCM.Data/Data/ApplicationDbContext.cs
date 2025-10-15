using FinalSGCM.Data.Entities;
using Microsoft.EntityFrameworkCore;
using SGCM.data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medic> Doctors { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<MedicationProduct> MedicationProducts { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionProduct> PrescriptionProducts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Speciality> Specialties { get; set; }
        public DbSet<MedicSpeciality> MedicSpecialities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

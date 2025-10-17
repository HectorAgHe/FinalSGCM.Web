using FinalSGCM.Business.DTOs;
using FinalSGCM.Business.Services.Interfaces;
using FinalSGCM.Data.Data;
using FinalSGCM.Data.Entities;
using Microsoft.EntityFrameworkCore;
using SGCM.data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var users = await _context.Users
                .Select(u => new UserReadDto
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    LastName = u.LastName,
                    Email = u.Email,
                    Phone = u.Phone,
                    //ImageUrl = u.ImageUrl

                }).ToListAsync();
            return users;
        }


        public async Task<UserReadDto> GetByIdAsync(int UserId)
        {
            var user = await _context.Users
                .Where(u => u.UserId == UserId)
                .Select(u => new UserReadDto
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    LastName = u.LastName,
                    Email = u.Email,
                    Phone = u.Phone
                }).FirstOrDefaultAsync();

            return user;

        }

        public async Task AddAsync(UserCreateDto userCreateDto)
        {

            var countUsers = _context.Users.Count();
            if (countUsers > 3)
            {
                throw new ApplicationException("No se puede asignar el consultorio a mas de 4");
            }
            var user = new User
            {
                //AÑADIR IMAGEN
                UserId = userCreateDto.UserId,
                Name = userCreateDto.Name,
                LastName = userCreateDto.LastName,
                Email = userCreateDto.Email,
                Phone = userCreateDto.Phone,
                ImageUrl = userCreateDto.ImageUrl,
                UserType = userCreateDto.UserType,

                //You can add the medic which you want assign
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }




        public async Task UpdateAsync(int UserId, UserCreateDto userCreateDto)
        {
            var user = await _context.Users
                .FindAsync(UserId);

            if (user == null)
            {
                throw new ApplicationException("Error al actualizar");
            }

            user.Name = userCreateDto.Name;
            user.LastName = userCreateDto.LastName;
            user.Email = userCreateDto.Email;
            user.Phone = userCreateDto.Phone;
            user.UserType = userCreateDto.UserType;
            user.ImageUrl = userCreateDto.ImageUrl;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

        }


        public async Task DeleteAsync(int UserId)
        {
            var user = await _context.Users
                .FindAsync(UserId);
            if (user == null)
            {
                throw new ApplicationException($"User with ID{UserId}not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}

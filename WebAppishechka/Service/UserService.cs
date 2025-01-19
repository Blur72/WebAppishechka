﻿using Microsoft.AspNetCore.Mvc;
using WebAppishechka.DataBaseContext;
using WebAppishechka.Interfaces;
using WebAppishechka.Model;
using WebAppishechka.Requests;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace WebAppishechka.Service
{
    public class UserService : IUserService
    {
        private readonly ContextDB _context;
        public UserService(ContextDB context) 
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if (await _context.User.AnyAsync(u => u.Email == user.Email))
                return false;

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _context.User.FindAsync(user.Id);
            if (existingUser == null)
                return false;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Description = user.Description;
            existingUser.Password = user.Password;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
                return false;

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user;
        }
    }
}

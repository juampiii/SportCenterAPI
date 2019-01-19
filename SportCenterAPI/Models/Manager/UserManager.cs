using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Data;

namespace SportCenterAPI.Models.Manager
{
    /// <summary>
    /// Manager used to perform operations over the collection of <see cref="User"/> in the Sport Center
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly SportCenterDBContext _context;

        /// <summary>
        /// Create a new instance of the <see cref="UserManager"/>
        /// </summary>
        /// <param name="context">The context for performing operations in the database</param>
        public UserManager(SportCenterDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<User> Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public async Task<User> DeleteAsync(int id)
        {
            var entity = await _context.Users.SingleAsync(e => e.Id == id);

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public Task<bool> Exist(int id)
        {
            return _context.Users.AnyAsync(e => e.Id == id);
        }

        /// <inheritdoc />
        public async Task<User> Get(int id)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<User> Update(int id, User element)
        {
            var entity = await Get(id);

            entity.Name = element.Name;
            entity.Password = element.Password;

            _context.Users.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

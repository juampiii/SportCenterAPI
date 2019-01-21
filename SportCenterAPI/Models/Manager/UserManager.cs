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

        /// <inheritdoc />
        public async Task<User> RegisterAsync(string username, string password)
        {
            // Checks if the userName exists
            var result = await _context.Users
                .AnyAsync(x => x.Name == username);

            if (result)
            {
                return null;
            }

            // Creates the new User
            User user = new User()
            {
                Name = username,
                Password = password,
                CreatedDate = DateTime.Now
            };

            return await Add(user);
        }

        /// <inheritdoc />
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _context.Users.SingleOrDefaultAsync(x => x.Name == username && x.Password == password));

            // User not found
            if (user == null)
            {
                return null;
            }

            // Send back the user without the password
            user.Password = null;
            return user;
        }
    }
}

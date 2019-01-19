using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Data;

namespace SportCenterAPI.Models.Manager
{
    /// <summary>
    /// Manager used to perform operations over the collection of <see cref="Sport"/> in the Sport Center
    /// </summary>
    public class SportManager : ISportManager
    {
        private readonly SportCenterDBContext _context;

        /// <summary>
        /// Create a new instance of the <see cref="SportManager"/>
        /// </summary>
        /// <param name="context">The context for performing operations in the database</param>
        public SportManager(SportCenterDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Sport> Add(Sport entity)
        {
            await _context.Sports.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public async Task<Sport> DeleteAsync(int id)
        {
            var entity = await _context.Sports.SingleAsync(e => e.Id == id);

            _context.Sports.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public Task<bool> Exist(int id)
        {
            return _context.Sports.AnyAsync(e => e.Id == id);
        }

        /// <inheritdoc />
        public async Task<Sport> Get(int id)
        {
            var result = await _context.Sports
                .Include(c => c.Courts)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Sport>> GetAll()
        {
            return await _context.Sports.Include(c => c.Courts).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Sport> Update(int id, Sport element)
        {
            var entity = await Get(id);

            entity.Name = element.Name;

            _context.Sports.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

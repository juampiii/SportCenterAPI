using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Data;

namespace SportCenterAPI.Models.Manager
{
    /// <summary>
    /// Manager used to perform operations over the collection of <see cref="Court"/> in the Sport Center
    /// </summary>
    public class CourtManager : ICourtManager
    {
        private readonly SportCenterDBContext _context;

        /// <summary>
        /// Create a new instance of the <see cref="CourtManager"/>
        /// </summary>
        /// <param name="context">The context for performing operations in the database</param>
        public CourtManager(SportCenterDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Court> Add(Court entity)
        {
            await _context.Courts.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public async Task<Court> DeleteAsync(int id)
        {
            var entity = await _context.Courts.SingleAsync(e => e.Id == id);

            _context.Courts.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public Task<bool> Exist(int id)
        {
            return _context.Courts.AnyAsync(e => e.Id == id);
        }

        /// <inheritdoc />
        public async Task<Court> Get(int id)
        {
            var result = await _context.Courts
                .Include(s => s.Sport)
                .Include(b => b.Bookings)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Court>> GetAll()
        {
            return await _context.Courts.Include(s => s.Sport).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Court> Update(int id, Court element)
        {
            var entity = await Get(id);

            entity.Name = element.Name;
            entity.Sport = element.Sport;
            entity.SportForeignKey = element.SportForeignKey;

            _context.Courts.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public IEnumerable<Court> FindAvailableCourtsBySport(int sportId, DateTime dateTime)
        {
            var courts = _context.Courts
                .Include(s => s.Sport)
                .Where(c => c.SportForeignKey == sportId);

            var bookedCourts = _context.Bookings
                .Include(b => b.Court)
                .Where(b => b.BookingDate == dateTime)
                .Select(b => b.Court);

            return courts.Except(bookedCourts);
        }
    }
}

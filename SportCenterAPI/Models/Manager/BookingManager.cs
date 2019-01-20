using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Data;
using SportCenterAPI.Models.DTO;

namespace SportCenterAPI.Models.Manager
{
    /// <summary>
    /// Manager used to perform operations over the collection of <see cref="Booking"/> in the Sport Center
    /// </summary>
    public class BookingManager : IBookingManager
    {
        private readonly SportCenterDBContext _context;

        /// <summary>
        /// Create a new instance of the <see cref="BookingManager"/>
        /// </summary>
        /// <param name="context">The context for performing operations in the database</param>
        public BookingManager(SportCenterDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Booking> Add(Booking entity)
        {
            await _context.Bookings.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public async Task<Booking> AddBookingMemberAsync(BookingDTO bookingRequest)
        {
            Booking booking = new Booking()
            {
                BookingDate = bookingRequest.BookingDate,
                CourtForeignKey = bookingRequest.CourtId,
                MemberForeignKey = bookingRequest.MemberId,
                CreatedDate = DateTime.Now,
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        /// <inheritdoc />
        public async Task<Booking> DeleteAsync(int id)
        {
            var entity = await _context.Bookings.SingleAsync(e => e.Id == id);

            _context.Bookings.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public async Task<bool> Exist(int id)
        {
            return await _context.Bookings.AnyAsync(e => e.Id == id);
        }

        /// <inheritdoc />
        public async Task<Booking> Get(int id)
        {
            var result = await _context.Bookings
                .Include(c => c.Court)
                .Include(m => m.Member)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _context.Bookings
                .Include(c => c.Court)
                .Include(m => m.Member)
                .ToListAsync();
        }

        /// <inheritdoc />
        public IEnumerable<Booking> GetDailyBookings(DateTime dateTime)
        {
            return _context.Bookings
                            .Include(c => c.Court)
                                .ThenInclude(s => s.Sport)
                            .Include(m => m.Member)
                            .Where(b => b.BookingDate.Date == dateTime.Date)
                            .ToList();
        }

        /// <inheritdoc />
        public async Task<Booking> Update(int id, Booking element)
        {
            var entity = await Get(id);

            entity.BookingDate = element.BookingDate;
            entity.Court = element.Court;
            entity.CourtForeignKey = element.CourtForeignKey;
            entity.Member = element.Member;
            entity.MemberForeignKey = element.MemberForeignKey;

            _context.Bookings.Update(entity);

            _context.SaveChanges();

            return entity;
        }

        /// <inheritdoc />
        public bool BookingAlreadyExist(int courtId, DateTime dateTime)
        {
            return _context.Bookings
                .Include(b => b.Court)
                .Any(b => b.CourtForeignKey == courtId & b.BookingDate == dateTime);
        }

        /// <inheritdoc />
        public bool BookingMemberAllowed(int memberId, DateTime dateTime)
        {
            // Checks if the member exceeds the maximum number of daily bookings
            int maxDailyBookings = _context.Bookings
                .Include(b => b.Member)
                .Where(b => b.MemberForeignKey == memberId & b.BookingDate.Date == dateTime.Date)
                .Count();

            if (maxDailyBookings >= 3)
            {
                return false;
            }

            // Checks if the member already have booked a courts at the same day and hour
            bool bookingHour = _context.Bookings
                .Include(b => b.Member)
                .Where(b => b.MemberForeignKey == memberId & b.BookingDate == dateTime)
                .Any();

            if (bookingHour)
            {
                return false;
            }


            return true;
        }

    }
}

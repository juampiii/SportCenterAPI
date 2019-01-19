using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportCenterAPI.Data;

namespace SportCenterAPI.Models.Manager
{
    /// <summary>
    /// Manager used to perform operations over the collection of <see cref="Member"/> in the Sport Center
    /// </summary>
    public class MemberManager : IMemberManager
    {
        private readonly SportCenterDBContext _context;

        /// <summary>
        /// Create a new instance of the <see cref="MemberManager"/>
        /// </summary>
        /// <param name="context">The context for performing operations in the database</param>
        public MemberManager(SportCenterDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Member> Add(Member entity)
        {
            await _context.Members.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public async Task<Member> DeleteAsync(int id)
        {
            var entity = await _context.Members.SingleAsync(e => e.Id == id);

            _context.Members.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <inheritdoc />
        public Task<bool> Exist(int id)
        {
            return _context.Members.AnyAsync(e => e.Id == id);
        }

        /// <inheritdoc />
        public async Task<Member> Get(int id)
        {
            var result = await _context.Members
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _context.Members.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Member> Update(int id, Member element)
        {
            var entity = await Get(id);

            entity.Name = element.Name;
            entity.Password = element.Password;

            _context.Members.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

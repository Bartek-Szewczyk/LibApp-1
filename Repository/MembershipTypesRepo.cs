using System.Collections.Generic;
using System.Linq;
using LibApp.Models;

namespace LibApp.Data
{
    public class MembershipTypesRepo : IMembershipTypesRepo
    {
        private readonly ApplicationDbContext _context;
        
        public  MembershipTypesRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MembershipType> GetAllMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        public MembershipType GetMembershipTypeById(int id)
        {
            return _context.MembershipTypes.FirstOrDefault(m => m.Id == id);
        }
    }
}
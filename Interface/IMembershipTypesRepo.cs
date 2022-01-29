using System.Collections;
using System.Collections.Generic;
using LibApp.Models;

namespace LibApp.Data
{
    public interface IMembershipTypesRepo
    {
        IEnumerable<MembershipType> GetAllMembershipTypes();
        MembershipType GetMembershipTypeById(int id);
    }
}
using As1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As1.Interfaces
{
   public interface IPartiesService
    {
        Task<List<Party>> GetAllParties();

        Task<Party> GetById(int id);

        Task<Party> UpdateParty(int id, Party v);

        Task DeleteParty(int id);

        Task<Party> AddNewParty(Party v);
    }
}

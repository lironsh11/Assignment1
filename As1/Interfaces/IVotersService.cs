using As1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As1.Interfaces
{
   public interface IVotersService
    {
        Task<List<Voters>> GetAllVoters();

        Task<Voters> GetById(int id);

        Task<Voters> UpdateVoter(int id, Voters v);

        Task DeleteVoter(int id);

        Task<Voters> AddNewVoter(Voters v);

    }
}

using As1.Interfaces;
using As1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As1.Services
{
    public class MockVotersService: IVotersService
    {
        private static List<Voters> _list;

        public Task<List<Voters>> GetAllVoters()
        {
            return Task.FromResult(_list);
        }

        public Task<Voters> GetById(int id)
        {
            var item = _list.FirstOrDefault(x => x.ID == id);
            return Task.FromResult(item);
        }

        public Task<Voters> AddNewVoter(Voters v)
        {
            var lastId = _list.Select(x => x.ID).Last();
            v.ID = lastId + 1;
            _list.Add(v);
            return Task.FromResult(v);
        }

        public Task DeleteVoter(int id)
        {
            var item = _list.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                throw new InvalidOperationException("cannot delete Item with id " + id);
            }
            _list.Remove(item);
            return Task.CompletedTask;
        }



        public Task<Voters> UpdateVoter(int id, Voters v)
        {
            var item = _list.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                throw new InvalidOperationException("cannot update Item with id " + id);
            }

            item.Name = v.Name;
            return Task.FromResult(item);
        }

        static MockVotersService()
        {
            _list = new List<Voters>()
            {
                new Voters() {ID = 1, Tz = "12333333", Name = "Eyal", Gender = "Male" , Phone = "05412345678" ,  Email = "eyal@eyal.com",  City = "Tel-Aviv", IdExpDate = DateTime.Now.AddDays(15)},
                new Voters() {ID = 2, Tz = "12545555", Name = "Omer", Gender = "Male" , Phone = "0542134879" ,  Email = "omer@omer.com",  City = "Tel-Aviv", IdExpDate = DateTime.Now.AddDays(45)},
                new Voters() {ID = 3, Tz = "31542141", Name = "Eden", Gender = "Male" , Phone = "012345566" ,  Email = "eden@eden.com",  City = "Tel-Aviv", IdExpDate = DateTime.Now.AddDays(85)},
                new Voters() {ID = 4, Tz = "41254442", Name = "Zehava", Gender = "Male" , Phone = "0452314555" ,  Email = "zehava@zehave.com",  City = "Tel-Aviv", IdExpDate = DateTime.Now.AddDays(25)},
            };
        }
    }
}

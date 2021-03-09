using As1.Interfaces;
using As1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As1.Services
{
    public class MockPartiesService:IPartiesService
    {
        private static List<Party> _pList;

        public Task<List<Party>> GetAllParties()
        {
            return Task.FromResult(_pList);
        }

        public Task<Party> GetById(int id)
        {
            var item = _pList.FirstOrDefault(x => x.ID == id);
            return Task.FromResult(item);
        }

        public Task<Party> AddNewParty(Party p)
        {
            var lastId = _pList.Select(x => x.ID).Last();
            p.ID = lastId + 1;
            _pList.Add(p);
            return Task.FromResult(p);
        }

        public Task DeleteParty(int id)
        {
            var item = _pList.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                throw new InvalidOperationException("cannot delete Item with id " + id);
            }
            _pList.Remove(item);
            return Task.CompletedTask;
        }



        public Task<Party> UpdateParty(int id, Party v)
        {
            var item = _pList.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                throw new InvalidOperationException("cannot update Item with id " + id);
            }

            item.Name = v.Name;
            return Task.FromResult(item);
        }

        public MockPartiesService()
        {
            _pList = new List<Party>()
            {
                new Party() {ID = 1, Name = "Likud", Description = "Yamin"},
                new Party()  {ID = 2, Name = "Avuda", Description = "Smol"},
                new Party() {ID = 3, Name = "YeshAtid", Description = "Merkaz"},
                new Party() {ID = 4, Name = "Mafdal", Description = "Yamin"},
            };
        }

    }
}

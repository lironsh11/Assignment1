using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using As1.Interfaces;
using As1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace As1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartiesController : ControllerBase
    {


        private readonly IPartiesService _partiesService;

        public PartiesController(IPartiesService partiesService)
        {
            _partiesService = partiesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Party>>> GetAll()
        {
            var result = await _partiesService.GetAllParties();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Party>> GetById(int id)
        {
            var result = await _partiesService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost()]
        public async Task<ActionResult<Party>> AddNewParty(Party p)
        {
            var result = await _partiesService.AddNewParty(p);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Party>> DeleteParty(int id)
        {
            try
            {
                await _partiesService.DeleteParty(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Party>> UpdateParty(int id, Party p)
        {
            try
            {
                var partyrWithUpdates = await _partiesService.UpdateParty(id, p);
                return Ok(partyrWithUpdates);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
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
    public class VotersController : ControllerBase
    {

        private readonly IVotersService _votersService;

        public VotersController(IVotersService votersService)
        {
            _votersService = votersService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Voters>>> GetAll()
        {
            var result = await _votersService.GetAllVoters();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Voters>> GetById(int id)
        {
            var result = await _votersService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<Voters>> AddNewVoter(Voters v)
        {
            var result = await _votersService.AddNewVoter(v);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Voters>> DeleteVoter(int id)
        {
            try
            {
                await _votersService.DeleteVoter(id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Voters>> UpdateVoter(int id, Voters v)
        {
            try
            {
                var voterWithUpdates = await _votersService.UpdateVoter(id,v);
                return Ok(voterWithUpdates);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
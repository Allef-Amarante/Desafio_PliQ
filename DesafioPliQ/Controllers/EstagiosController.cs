using DesafioPliQ.Models;
using DesafioPliQ.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace DesafioPliQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstagiosController : ControllerBase
    {
        private readonly IEstagiosRepository _Repository;

        public EstagiosController(IEstagiosRepository repository)
        {
            _Repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstagiosCRM>> Get(int id)
        {
            try
            {
                return Ok(await _Repository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstagiosCRM>>> ListOrder()
        {
            try
            {
                return Ok(await _Repository.ListOrder());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<EstagiosCRM>> Create([FromBody] EstagiosCRM estagios)
        {

            try
            {
                await _Repository.Create(estagios);
                return CreatedAtAction(nameof(Get), new { id = estagios.Id }, estagios);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<EstagiosCRM>> Delete(int id)
        {
            try
            {
                return Ok(await _Repository.Delete(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPut]
        public async Task<ActionResult<EstagiosCRM>> Update(EstagiosCRM estagios)
        {
            return Ok(await _Repository.Update(estagios));
        }

    }
}

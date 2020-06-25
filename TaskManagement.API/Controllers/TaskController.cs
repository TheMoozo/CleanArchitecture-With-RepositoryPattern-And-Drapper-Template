using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Interfaces;
using TaskManagement.DapperInfrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public ITaskRepository Repo { get; set; }
        //have to use the Interface for the abstraction not the object other wise resolve dependency error will come
        public TaskController(ITaskRepository repo)
        {
            Repo = repo;
        }
        // GET: api/<TaskController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Repo.GetAll());
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int TaskId)
        {
            return Ok(await Repo.Get(TaskId));
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> Post(Core.Entities.Task Model)
        {
            return Ok(await Repo.Add(Model));
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int TaskId, Core.Entities.Task Model)
        {
            return Ok(await Repo.Update(Model));
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int TaskId)
        {
            return Ok(await Repo.Delete(TaskId));
        }
    }
}

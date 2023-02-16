using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lesson_1.Models;

namespace lesson_1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MyTasksController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MyTask> Get()
        {
            return TaskService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<MyTask> Get(int id)
        {
            var t=TaskService.Get(id);
            if(t == null)
                return NotFound();
            return t;
        }

        [HttpPost]
        public ActionResult Post(MyTask task)
        {
            TaskService.Add(task);
            return CreatedAtAction(nameof(Post), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public ActionResult put(int id,MyTask task)
        {
            if (!TaskService.Update(id,task))
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(!TaskService.Delete(id))
                return NotFound();
            return NoContent(); 
        }
    }
}
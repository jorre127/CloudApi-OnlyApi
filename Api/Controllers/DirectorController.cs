using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorController : ControllerBase
    {
        public List<MovieClass> arrayke = new List<MovieClass>();
        private MovieContext context;

        public DirectorController(MovieContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult get(){
            return new JsonResult( this.context.Director.ToList());
        }
        [HttpPost]
        [Route("")]
        public void post([FromBody]DirectorClass director){
            context.Director.Add(director);
            context.SaveChanges();
        }
        [HttpPut]
        [Route("")]
        public void put([FromBody]DirectorClass director){
            context.Director.Update(director);
            context.SaveChanges();
        }
        [HttpDelete]
        [Route("{id}")]
        public void delete(int id){
            context.Director.Remove(context.Director.SingleOrDefault(director => director.id == id));
            context.SaveChanges();
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using WebAPIDemoProject.Entities.ViewEntities;
using WebAPIDemoProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        TeacherService teacherService = new TeacherService();

        //// GET: api/<TeacherController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}



        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public TeacherView? Get(int id)
        {
            return teacherService.Get(id);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public TeacherView Add([FromBody] TeacherView teacher)
        {
            return teacherService.Add(teacher);
        }

        // PUT api/<TeacherController>/5
        [HttpPut]
        public void Update([FromBody] TeacherView teacher)
        {
            teacherService.Update(teacher);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            teacherService.Delete(id);
        }
    }
}

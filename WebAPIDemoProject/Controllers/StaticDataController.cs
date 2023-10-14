using Microsoft.AspNetCore.Mvc;
using WebAPIDemoProject.Entities;

namespace WebAPIDemoProject.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StaticDataController
    {        
        [HttpGet("subjects")]
        public string[] GetSubjects()
        {
            var subjects = Enum.GetNames<Subject>();
            return subjects;
        }

        [HttpGet("grades")]
        public string[] GetGrades()
        {
            var grades = Enum.GetNames<Grade>();
            return grades;
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySchool.Models;
using System.Diagnostics.Metrics;

namespace MySchool.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly MySchoolDbContext dbContext; 
        public StudentController(MySchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var testStudent = (from master in this.dbContext.Student_master
                              from details in this.dbContext.Student_details
                              where master.Id == details.Student_master_id
                              select new
                              {
                                  student_id = master.Id,
                                  name = master.Name,
                                  address = details.Address,
                                  phone = details.Phone,
                                  dob = details.Dob
                              }).ToList();


            return Ok(testStudent);
            //return testStudent;
        }

        [HttpPost]
        public IActionResult PostStudent([FromBody] Student studentPayload)
        {
            var studentMasterData = new StudentMaster
            {
                Name = studentPayload?.Name,
                Student_details = new StudentDetails
                {
                    Address = studentPayload?.Address,
                    Phone = studentPayload?.Phone,
                    Dob = studentPayload?.Dob
                }
        };

           
            this.dbContext.Add(studentMasterData);
            this.dbContext.SaveChanges();
            return Created("201", "creted");
        }

    }
}

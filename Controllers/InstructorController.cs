using Bernardino3ITE.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bernardino3ITE.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>
            {
                new Instructor()
                {
                    Id=1, FirstName ="Aria", LastName ="Stormrider", HiringDate = new DateTime(2020, 03, 20), IsTenured = true, Rank = Rank.Instructor
                },
                new Instructor()
                {
                    Id=2, FirstName ="John", LastName ="Smith", HiringDate = new DateTime(2021, 04, 30), IsTenured = false, Rank = Rank.AssociateProfessor
                }
            };
        public IActionResult Index()
        {

            return View(InstructorList);
        }

        public IActionResult ShowDetails(int id)
        {
            //Search for the student whose id matches the given id
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();
        }
        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructorChange)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == instructorChange.Id);

            if (instructor != null)
            {   
                instructor.Id = instructorChange.Id;
                instructor.FirstName = instructorChange.FirstName;
                instructor.LastName = instructorChange.LastName;
                instructor.IsTenured = instructorChange.IsTenured;
                instructor.Rank = instructorChange.Rank;
                instructor.HiringDate = instructorChange.HiringDate;
            }
                return View("Index", InstructorList);
        }
    }
    
}
using Bernardino3ITE.Data;
using Bernardino3ITE.Models;
using Bernardino3ITE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bernardino3ITE.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDBContext _dbContext;

        public InstructorController(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public IActionResult Index()
        {

            return View(_dbContext.Instructors);
        }

        public IActionResult ShowDetails(int id)
        {

            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
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
            _dbContext.Instructors.Add(newInstructor);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructorChange)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == instructorChange.Id);

            if (instructor != null)
            {
                instructor.Id = instructorChange.Id;
                instructor.FirstName = instructorChange.FirstName;
                instructor.LastName = instructorChange.LastName;
                instructor.IsTenured = instructorChange.IsTenured;
                instructor.Rank = instructorChange.Rank;
                instructor.HiringDate = instructorChange.HiringDate;
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteInstructor(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult deleteInstructor(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                _dbContext.Instructors.Remove(instructor);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }

}
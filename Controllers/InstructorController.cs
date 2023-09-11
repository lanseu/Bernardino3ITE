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
                    Id=1, FirstName ="Aria", LastName ="Stormrider", HiringDate = new DateTime(2020, 03, 20), IsTenured = true, Rank = "Instructor"
                },
                new Instructor()
                {
                    Id=2, FirstName ="John", LastName ="Smith", HiringDate = new DateTime(2021, 04, 30), IsTenured = false, Rank = "Assistant Professor"
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

    }
}
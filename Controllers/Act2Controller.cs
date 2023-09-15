using Microsoft.AspNetCore.Mvc;
using Bernardino3ITE.Models;

namespace Bernardino3ITE.Controllers
{
    public class Act2Controller : Controller 
    {
        List<Act2> PersonList = new List<Act2>
        {
            new Act2()
            {
               Id=1, FirstName = "Gabriel", LastName = "Montano", Birthday = DateTime.Parse("1994, 03, 20"), IsTenured = true, Email ="gdmontano@ust.edu.ph", SalaryPerHour = 150, PrelimGrade=69, FinalGrade=75
            },
            new Act2()
            {
               Id=2, FirstName = "Lance", LastName = "Bernardino", Birthday = DateTime.Parse("2001, 12, 25"), IsTenured = false, Email ="lance.bernardino.cics@ust.edu.ph", SalaryPerHour = 100, PrelimGrade=87, FinalGrade=99
            }
        };
        public IActionResult Index()
        {
            CalculateAges(); 
            return View(PersonList);
        }

        public IActionResult ShowDetails(int id)
        {
            // Search for the student whose id matches the given id
            Act2? person = PersonList.FirstOrDefault(st => st.Id == id);

            if (person != null)
            {
                CalculateAge(person);
                int SemGrade = getSemGrade(person.PrelimGrade, person.FinalGrade);
                person.SemGrade = SemGrade;
                return View(person);
            }

            return NotFound();
        }

        
        private void CalculateAges()
        {
            DateTime currentDate = DateTime.Now;

            foreach (var person in PersonList)
            {
                CalculateAge(person, currentDate);
            }
        }

        
        private void CalculateAge(Act2 person, DateTime? referenceDate = null)
        {
            DateTime currentDate = referenceDate ?? DateTime.Now;
            int age = get_age(person.Birthday);

            person.Age = age;
        }

        
        public int get_age(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }

        public int getSemGrade(int PrelimGrade, int FinalGrade)
        {
            int SemGrade = (PrelimGrade + FinalGrade) / 2;

            return SemGrade;
        }

    }
}

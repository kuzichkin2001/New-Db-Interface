using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class EmployeesView
    {
        public string Name { get; set; }

        public DateTime Hiring_Date { get; set; }

        public string Level { get; set; }

        public string Phone_Number { get; set; }

        public DateTime Birthdate { get; set; }
    }
}

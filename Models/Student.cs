using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace StudentApplication.Models
{
    public enum Gender
    {
        Female,Male
    }
    public class Student
    {
        public int Id { get; set; }
        // Or public int {Student}Id { get; set; }

        public string Name { get; set; }
        public University University { get; internal set; }

        //  public int UniversityId { get; set; }


    }
    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; internal set; }
    }
}

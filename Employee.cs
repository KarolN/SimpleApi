using System.ComponentModel.DataAnnotations;

namespace SimpleApi
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Pesel { get; set; }
        [Required]
        public int YearsInPgs { get; set; }
        public string Hobby { get; set; }
        [Required]
        public int OfficeId { get; set; }
    }
}
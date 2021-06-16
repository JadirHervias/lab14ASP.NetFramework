using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Student
    {
        [Key]
        public int studentID { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string studentLastName { get; set; }
        [Required]
        public string studentCode { get; set; }
        [Required]
        public string studentAddress { get; set; }
        [DataType(DataType.Date)]
        public string studentCreatedAt { get; set; }
        [Required]
        public string studentUpdatedAt { get; set; }
    }
}

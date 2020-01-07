
namespace DoggyDayCare.Data.Entities
{
    using System.Collections.Generic;
    public class Student
    {
        public string StudentId { get; set; }

        public string FirstName { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Status { get; set; }
    }
}

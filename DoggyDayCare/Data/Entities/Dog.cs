namespace DoggyDayCare.Data.Entities
{
    using System.Collections.Generic;
    public class Dog
    {
        public int DogId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string Notes { get; set; }

        public string OwnerId { get; set; }

        public virtual Student Owner { get; set; }

        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
    }
}

using System;

namespace CsvHelperDemo
{
    public class PersonV2
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsActive { get; set; }

        public void Print()
        {
            Console.WriteLine($"{FirstName} {LastName} is {Age} years old. Account is active: {IsActive}");
        }
    }
}

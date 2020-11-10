using System;

namespace MediatrTutorial.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public DateTime RegistrationDate { get; set; }
    }
}
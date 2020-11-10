namespace MediatrTutorial.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string RegistrationDate { get; set; } = default!;
    }
}
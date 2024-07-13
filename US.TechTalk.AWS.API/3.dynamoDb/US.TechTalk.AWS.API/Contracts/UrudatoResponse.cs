namespace US.TechTalk.AWS.API.Contracts
{
    public class UrudatoResponse
    {
        public Guid Id { get; set; } 

        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public DateTime DateOfBirth { get; set; } = default!;
    }
}

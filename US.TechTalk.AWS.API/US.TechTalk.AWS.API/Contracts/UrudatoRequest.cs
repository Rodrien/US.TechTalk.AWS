namespace US.TechTalk.AWS.API.Contracts
{
    public class UrudatoRequest
    {
        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public DateTime DateOfBirth { get; set; } = default!;
    }
}

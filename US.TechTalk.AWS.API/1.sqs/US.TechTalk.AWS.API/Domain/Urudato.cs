namespace US.TechTalk.AWS.API.Domain
{
    public class Urudato
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public DateTime DateOfBirth { get; set; } = default!;
    }
}

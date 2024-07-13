namespace US.TechTalk.AWS.API.Contracts
{
    public class UrudatoDeleted
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; } = default!;

        public required string Email { get; set; } = default!;

        public required DateTime DateOfBirth { get; set; } = default!;
    }
}

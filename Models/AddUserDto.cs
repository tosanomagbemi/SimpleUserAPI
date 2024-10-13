namespace SimpleUserAPI.Models
{
    public class AddUserDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }
    }
}

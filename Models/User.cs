using System.ComponentModel.DataAnnotations;

namespace SimpleUserAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}

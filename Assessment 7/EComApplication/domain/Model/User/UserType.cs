
using System.ComponentModel.DataAnnotations;

namespace domain.Model.User
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

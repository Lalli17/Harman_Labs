using System.ComponentModel.DataAnnotations;

namespace SecuredAPI.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        [EmailAddress]
        public string EmailId { get; set; } // as login id
        [MaxLength(50)]
        [MinLength(8)]
        public string Password { get; set; }

        // add any other properties of user
    }
}

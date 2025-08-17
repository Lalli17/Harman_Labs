using System.ComponentModel.DataAnnotations;

namespace SecurApi.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; } //loginId
        [MaxLength(50)]
        [MinLength(8)]
        //[RegularExpression("")] for password to be alpha numeric
        public string Password { get; set; }

        //add any properties of user

    }
}

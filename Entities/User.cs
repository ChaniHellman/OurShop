using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {

        #region props

        public int UserId { get; set; }
       
        [MaxLength(15, ErrorMessage = "name cannot be longer than 15 characters")]

        public string FullName { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [StringLength(maximumLength:20, ErrorMessage = "password must contain 8 characters"), Required]
        public string Password { get; set; }

        public string Phone { get; set; }

        #endregion








    }
}

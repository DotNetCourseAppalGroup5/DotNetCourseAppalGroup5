using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
    public class User
    {
        public User()
        {
            Albums = new List<Album>();
            Avatars = new List<Avatar>();
            Friends1 = new List<Friend>();
            Friends2 = new List<Friend>();
            Messages = new List<Message>();
            UserDialogs = new List<UserDialog>();
            TimeRegistration = DateTime.Now;  
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string Login { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime TimeRegistration { get; set; }
        public virtual List<Album> Albums { get; set; }
        public virtual List<Avatar> Avatars { get; set; }

        [ForeignKey("User1Id")]
        public virtual List<Friend> Friends1 { get; set; }

        [ForeignKey("User2Id")]
        public virtual List<Friend> Friends2 { get; set; }

        public virtual List<Message> Messages { get; set; }
        public virtual List<UserDialog> UserDialogs { get; set; }
    }
}

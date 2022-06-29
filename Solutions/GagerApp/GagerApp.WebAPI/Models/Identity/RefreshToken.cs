using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GagerApp.WebAPI.Models
{
    public class RefreshToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Token
        {
            get; set;
        }

        public string JwtId
        {
            get; set;
        }

        public DateTime CreationDate
        {
            get; set;
        }

        public DateTime ExpiryDate
        {
            get; set;
        }

        public long UserId
        {
            get; set;
        }

        public long WorkerId
        {
            get; set;
        }

        [ForeignKey("UserId,WorkerId")]
        public UserProfile User
        {
            get; set;
        }
    }
}

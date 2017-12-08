using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Data.Models
{
    public class Reputation
    {
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("sender")]
        public User Sender { get; set; }

        [Required]
        [Column("receiver")]
        public User Receiver { get; set; }

        [Required]
        [Column("amount")]
        public int Amount { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolloquium.Models.Entities
{
    public class Ticket
    {
        [Key]
        public Guid t_id { get; set; }
        public string t_seat { get; set; }


        [ForeignKey("m_id")]
        public int m_id { get; set; }

        [ForeignKey("c_id")]
        public int c_id { get; set; }

        
        public Movie Movie { get; set; }

        
        public Customer Customer { get; set; }
    }
}

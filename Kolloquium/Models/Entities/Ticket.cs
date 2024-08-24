using System.ComponentModel.DataAnnotations.Schema;

namespace Kolloquium.Models.Entities
{
    public class Ticket
    {
        public Guid t_id{ get; set; }
        public string t_seat { get; set; }


 
        public int m_id { get; set; }
        public int c_id { get; set; }

        [ForeignKey("m_id")]
        public Movie Movie { get; set; }

        [ForeignKey("c_id")]
        public Customer Customer { get; set; }
    }
}

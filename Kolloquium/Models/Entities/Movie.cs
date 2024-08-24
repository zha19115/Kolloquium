using System.ComponentModel.DataAnnotations;

namespace Kolloquium.Models.Entities
{
    public class Movie
    {
        [Key]
        public Guid m_id { get; set; }
        public string m_title { get; set; }
        public string m_genre { get; set; }
        public string m_description { get; set; }
        public DateOnly m_releaseDate { get; set; }
        public DateTime m_showTime { get; set; }



    }
}

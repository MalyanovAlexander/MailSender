using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailSender.ConsoleTest2.Data
{
    [Table("Track")]
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Length { get; set; }        

        //public int ArtistId { get; set; }

        //[ForeignKey(nameof(ArtistId))]
        public virtual Artist Artist { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailSender.ConsoleTest2.Data
{
    [Table("Track")]
    public class Track
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        public int Length { get; set; }
    }
}

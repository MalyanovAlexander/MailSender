using MailSender.lib.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailSender.lib.Entities
{
    public class RecipientsList : NamedEntity
    {
        [Required]
        public ICollection<Recipient> Recipients { get; set; }
    }
}

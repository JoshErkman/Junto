using Junto.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junto.Data
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public string Body { get; set; }

        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }

        public DateTime TimeStamp { get; set; }

        [ForeignKey(nameof(Channel))]
        public int ChannelId { get; set; }
        public virtual Channel Channel { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}

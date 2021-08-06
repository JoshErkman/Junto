using Junto.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ChannelId { get; set; }
        public virtual Channel Channel { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}

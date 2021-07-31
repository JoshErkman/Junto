using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junto.Models.Message
{
    public class MessageCreate
    {
        public string Author { get; set; }
        public string MessageBody { get; set; }
        public int ChannelId { get; set; }
        public Guid UserId { get; set; }
        public int TeamId { get; set; }
    }
}

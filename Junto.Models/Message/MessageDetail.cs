using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junto.Models.Message
{
    public class MessageDetail
    {
        public int MessageId { get; set; }
        public string MessageOwner { get; set; }
        public string ChannelName { get; set; }
        public string TeamName { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

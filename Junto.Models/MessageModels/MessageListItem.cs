using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junto.Models.MessageModels
{
    public class MessageListItem
    {
        public string MessageAuthor { get; set; }
        public string MessageBody { get; set; }
        public string ChannelName { get; set; }
        public string TeamName { get; set; }
        public DateTime MessageCreationTime { get; set; }
    }
}

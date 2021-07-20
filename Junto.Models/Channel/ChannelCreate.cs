using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junto.Models.Channel
{
    public class ChannelCreate
    {
        public string ChannelName { get; set; }

        public string ChannelTopic { get; set; }

        public int TeamId { get; set; }
    }
}

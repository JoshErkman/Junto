﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junto.Models.Channel
{
    public class ChannelEdit
    {
        public int ChannelId { get; set; }

        public string ChannelName { get; set; }

        public string ChannelTopic { get; set; }

        public int TeamId { get; set; }
    }
}

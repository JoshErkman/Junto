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
    public class Channel
    {
        [Key]
        public int ChannelId { get; set; }

        public string ChannelName { get; set; }

        public string ChannelTopic { get; set; }

        [ForeignKey (nameof(Team))]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        [ForeignKey (nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

using Junto.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junto.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public string UserId { get; set; }

        //public virtual List<Channel> Channels { get; set; }

       // public virtual List<ApplicationUser> Users { get; set; }
    }
}

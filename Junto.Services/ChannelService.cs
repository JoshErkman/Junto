using Junto.Data;
using Junto.Models.Channel;
using Junto.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junto.Services
{
    public class ChannelService
    {
        private readonly Guid _userId;
        public ChannelService(Guid userId)
        {
            _userId = userId;
        }

        // POST
        public bool CreateChannel(ChannelCreate model)
        {
            var entity =
                new Channel()
                {
                    TeamId = model.TeamId,
                    ChannelName = model.ChannelName,
                    ChannelTopic = model.ChannelTopic
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Channels.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET (all channels)
        public IEnumerable<ChannelListItem> GetAllChannels()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Channels
                        .Select(
                            e =>
                                new ChannelListItem
                                {
                                    ChannelId = e.ChannelId,
                                    ChannelName = e.ChannelName,
                                    ChannelTopic = e.ChannelTopic,
                                    TeamId = e.TeamId
                                }
                        );

                return query.ToArray();
            }
        }

        // GET (all channels for one Org)
        public IEnumerable<ChannelListItem> GetAllChannelsByOrgId(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Channels
                        .Where(e => e.TeamId == teamId)
                        .Select(
                            e =>
                                new ChannelListItem
                                {
                                    ChannelId = e.ChannelId,
                                    ChannelName = e.ChannelName,
                                    ChannelTopic = e.ChannelTopic,
                                    TeamId = e.TeamId
                                }
                        );

                return query.ToArray();
            }
        }

        // GET (channel by id)
        public ChannelDetail GetChannelById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Channels
                        .Single(e => e.ChannelId == id);
                return
                    new ChannelDetail
                    {
                        ChannelId = entity.ChannelId,
                        TeamId = entity.TeamId,
                        ChannelName = entity.ChannelName,
                        ChannelTopic = entity.ChannelTopic
                    };
            }
        }

        // PUT
        public bool UpdateChannel(ChannelEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Channels
                        .Single(e => e.ChannelId == model.ChannelId);

                entity.ChannelId = model.ChannelId;
                entity.TeamId = model.TeamId;
                entity.ChannelName = model.ChannelName;
                entity.ChannelTopic = model.ChannelTopic;

                return ctx.SaveChanges() == 1;
            }
        }

        // DELETE
        public bool DeleteChannel(int channelId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Channels
                        .Single(e => e.ChannelId == channelId);

                ctx.Channels.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

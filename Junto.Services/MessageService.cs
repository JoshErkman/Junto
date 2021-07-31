using Junto.Data;
using Junto.Models.Message;
using Junto.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junto.Services
{
    public class MessageService
    {
        private readonly Guid _userId;

        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(MessageCreate model)
        {
            var entity =
                new Message()
                {
                    Body = model.MessageBody,
                    TimeStamp = DateTime.Now,
                    UserId = _userId,
                    ChannelId = model.ChannelId,
                    TeamId = model.TeamId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MessageListItem> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                    .Messages
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new MessageListItem
                        {
                            MessageAuthor = e.User.DisplayName,
                            MessageBody = e.Body,
                            TeamName = ctx.Teams.Find(e.TeamId).TeamName,
                            ChannelName = ctx.Channels.Find(e.ChannelId).ChannelName,
                            MessageCreationTime = e.TimeStamp
                        });
                return query.ToArray();
            }
        }

        public MessageDetail GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Messages
                    .Where(e => e.UserId == _userId)
                    .Single(e => e.MessageId == id);
                return
                    new MessageDetail
                    {
                        MessageId = entity.MessageId,
                        MessageOwner = entity.User.DisplayName,
                        ChannelName = ctx.Channels.Find(entity.ChannelId).ChannelName,
                        TeamName = ctx.Teams.Find(entity.TeamId).TeamName
                    };
            }

        }

        public bool UpdateMessage(MessageEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Messages
                    .Single(e => e.MessageId == model.MessageId);

                entity.Body = model.EditedBody;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMessage(int messageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Messages
                    .Single(e => e.MessageId == messageId);
                ctx.Messages.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

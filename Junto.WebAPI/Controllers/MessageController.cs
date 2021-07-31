using Junto.Models.Message;
using Junto.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Junto.WebAPI.Controllers
{
    public class MessageController : ApiController
    {
        public MessageService CreateMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var messageservice = new MessageService(userId);
            return messageservice;
        }
        public IHttpActionResult Post(MessageCreate message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateMessageService();
            if (!service.CreateMessage(message))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            MessageService messageService = CreateMessageService();
            var message = messageService.GetMessageById(id);
            return Ok(message);
        }

        public IHttpActionResult Put(MessageEdit message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateMessageService();
            if (!service.UpdateMessage(message))
            {
                return InternalServerError();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMessageService();
            if (!service.DeleteMessage(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}

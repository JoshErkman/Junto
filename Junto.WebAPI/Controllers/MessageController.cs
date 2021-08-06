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
        private MessageService CreatedMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var messageservice = new MessageService(userId);
            return messageservice;
        }
        [HttpPost]
        public IHttpActionResult CreateMessage(MessageCreate message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatedMessageService();
            if (!service.CreateMessage(message))
                return InternalServerError();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetMessage(int id)
        {
            MessageService messageService = CreatedMessageService();
            var message = messageService.GetMessageById(id);
            return Ok(message);
        }
        [HttpPut]
        public IHttpActionResult EditMessage(MessageEdit message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatedMessageService();
            if (!service.UpdateMessage(message))
            {
                return InternalServerError();
            }
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteMessage(int id)
        {
            var service = CreatedMessageService();
            if (!service.DeleteMessage(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}

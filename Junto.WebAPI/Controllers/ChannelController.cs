using Junto.Data;
using Junto.Models.Channel;
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
    public class ChannelController : ApiController
    {
        // POST
        [HttpPost]
        public IHttpActionResult CreateChannel(ChannelCreate channel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ChannelService service = CreatedChannelService();

            service.CreateChannel(channel);

            return Ok();
        }

        // GET (all channels)
        [HttpGet]
        public IHttpActionResult GetAllChannels()
        {
            ChannelService service = CreatedChannelService();
            var channels = service.GetAllChannels();
            return Ok(channels);
        }

        // GET (all channels for one Org)
        [HttpGet]
        public IHttpActionResult GetAllChannelsByOrgId(int teamId)
        {
            ChannelService service = CreatedChannelService();
            Team team = new Team();
            var channels = service.GetAllChannelsByOrgId(teamId);
            return Ok(channels);
        }

        // GET (single channel by Id)
        [HttpGet]
        public IHttpActionResult GetChannelById(int id)
        {
            ChannelService service = CreatedChannelService();
            var channel = service.GetChannelById(id);
            return Ok(channel);
        }

        // PUT
        [HttpPut]
        public IHttpActionResult UpdateChannel(ChannelEdit channel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatedChannelService();

            if (!service.UpdateChannel(channel))
                return InternalServerError();

            return Ok();
        }

        // DELETE
        [HttpDelete]
        public IHttpActionResult DeleteChannel(int id)
        {
            var service = CreatedChannelService();

            if (!service.DeleteChannel(id))
                return InternalServerError();

            return Ok();
        }

        // HELPER METHOD
        private ChannelService CreatedChannelService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var channelService = new ChannelService(userId);
            return channelService;
        }
    }
}

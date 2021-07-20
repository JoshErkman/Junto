using Junto.Models.Team;
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
    public class TeamController : ApiController
    {
        public IHttpActionResult Post(TeamCreate team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTeamService();
            if (!service.CreateTeam(team))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            TeamService teamService = CreateTeamService();
            var team = teamService.GetTeamById(id);
            return Ok(team);
        }

        public IHttpActionResult Get()
        {
            TeamService teamService = CreateTeamService();
            var teams = teamService.GetTeams();
            return Ok(teams);
        }

        public IHttpActionResult Put(TeamEdit teams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTeamService();
            if (!service.UpdateTeam(teams))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTeamService();
            if (!service.DeleteTeam(id))
            {
                return InternalServerError();
            }
            return Ok();
        }

        private TeamService CreateTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var teamService = new TeamService(userId);
            return teamService;
        }
    }
}

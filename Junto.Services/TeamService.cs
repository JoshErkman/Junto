using Junto.Data;
using Junto.Models.Team;
using Junto.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junto.Services
{
    public class TeamService
    {

        private readonly Guid _userId;

        public TeamService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                new Team()
                {
                    UserId = _userId.ToString(),
                    TeamName = model.TeamName,
                    //Channels = model.Channels,
                    //Users = model.Users
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Teams
                    .Where(e => e.UserId == _userId.ToString())
                    .Select(
                        e =>
                        new TeamListItem
                        {
                            TeamName = e.TeamName,
                            TeamId = e.TeamId,
                          //  Channels = e.Channels,
                          //  Users = e.Users
                        }
                        );
                return query.ToArray();
            }
        }

        public TeamDetail GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Where(e => e.UserId == _userId.ToString())
                    .Single(e => e.TeamId == id);
                return
                    new TeamDetail
                    {
                        TeamId = entity.TeamId,
                        TeamName = entity.TeamName,
                      //  Channels = entity.Channels,
                     //   Users = entity.Users
                    };
            }
        }

        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == model.TeamId);

                entity.TeamId = entity.TeamId;
                entity.TeamName = model.TeamName;
               // entity.Channels = model.Channels;
               // entity.Users = model.Users;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == teamId);
                ctx.Teams.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

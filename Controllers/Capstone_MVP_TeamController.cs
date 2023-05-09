using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone_MVP.Model;
using Capstone_MVP.Data;
using Capstone_MVP.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Capstone_MVP.Controllers
{
    [Route("api")]
    [ApiController]
    public class Capstone_MVP_TeamController : Controller
    {
        private readonly ICapstone_MVPRepo _capstone_repo;

        public Capstone_MVP_TeamController(ICapstone_MVPRepo repository)
        {
            _capstone_repo = repository;
        }


        [HttpGet("ListStudents")]
        public ActionResult<IEnumerable<StudentOutDto>> ListStudents()
        {
            IEnumerable<Student> st = _capstone_repo.GetAllStudents();
            IEnumerable<StudentOutDto> s = st.Select(e => new StudentOutDto { Interest = e.Interest, FirstName = e.FirstName, LastName = e.LastName });
            return Ok(s);
        }


        [HttpGet("GetStudentByName{Name}")]
        public ActionResult<IEnumerable<StudentOutDto>> GetStudentbyName(string Name)
        {

            IEnumerable<Student> s = _capstone_repo.GetStudentByName(Name);

            IEnumerable<StudentOutDto> students = s.Select(e => new StudentOutDto { Interest = e.Interest, FirstName = e.FirstName, LastName = e.LastName });
            return Ok(students);
        }
        [HttpGet("GetTeamByName{Name}")]
        public ActionResult<IEnumerable<Team>> GetTeambyName(string Name)
        {

            IEnumerable<Team> s = _capstone_repo.GetTeamByTeamName(Name);

            
            return Ok(s);
        }



        [HttpPost("AddTeams")]
        public ActionResult<Team> AddTeams(Team t)
        {
            _capstone_repo.AddTeam(t);
            return Ok(t);
        }


        [HttpGet("ListTeams")]
        public ActionResult<IEnumerable<StudentOutDto>> ListTeams()
        {
            IEnumerable<Team> team = _capstone_repo.GetAllTeams();
            return Ok(team);

        }


        [HttpPost("JoinTeam")]
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "StudentOnly")]
        public ActionResult<string> JoinTeam(TeamInDto t)
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
            Claim user = ci.FindFirst("student");
            string name = user.Value;

            return _capstone_repo.JoinTeam(t, name);
        }


        [HttpDelete("DeleteTeam/{TeamName}")]
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult<string> DeleteTeam(string TeamName)
        {
            Team team = _capstone_repo.GetTeamByName(TeamName);
            if(team == null)
            {
                return "Not found";
            }
            _capstone_repo.RemoveTeam(TeamName);
            return "delete successfully";
        }
    }
}
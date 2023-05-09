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


namespace Capstone_MVP.Controllers
{
    [Route("api")]
    [ApiController]
    public class Capstone_MVP_ProjectController : Controller
    {
        private readonly ICapstone_MVPRepo _capstone_repo;

        public Capstone_MVP_ProjectController(ICapstone_MVPRepo repository)
        {
            _capstone_repo = repository;
        }
        [HttpPost("AddProjects")]
        public ActionResult<Project> AddProjects(ProjectInDtos pi)
        {
            Project p = new() { TeamName = pi.TeamName, ProjectName = pi.ProjectName, Skill = pi.Skill, Introduction = pi.Introduction, Approach = pi.Approach, Video = pi.Video, Img = pi.Img };
            _capstone_repo.AddProject(p);
            return Ok(p);
        }

        [HttpGet("ListProjects")]
        public ActionResult<IEnumerable<ProjectOutDto>> ListProjects()
        {
            IEnumerable<Project> project = _capstone_repo.GetProjects();
            IEnumerable<ProjectOutDto> i = project.Select(e => new ProjectOutDto { ProjectID = e.ProjectID, TeamName = e.TeamName, ProjectName = e.ProjectName, Semester = e.Semester, Introduction = e.Introduction, Skill = e.Skill, Approach = e.Approach, Img = e.Img, Video = e.Video, Likes = e.Likes, Comments = e.Comments });
            return Ok(i);
        }


        [HttpGet("GetProjects/{ProjectName}")]
        public ActionResult<IEnumerable<ProjectOutDto>> GetProjects(string ProjectName)
        {
            IEnumerable<Project> p = _capstone_repo.GetProjectByName(ProjectName);
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                IEnumerable<ProjectOutDto> pr = p.Select(e => new ProjectOutDto { ProjectID = e.ProjectID, TeamName = e.TeamName, ProjectName = e.ProjectName, Semester = e.Semester, Introduction = e.Introduction, Skill = e.Skill, Approach= e.Approach, Img = e.Img, Video = e.Video, Likes = e.Likes, Comments = e.Comments }); ;
                return Ok(pr);
            }
        }
        [HttpGet("GetProject/{ProjectName}")]
        public ActionResult<ProjectOutDto> GetProject(string ProjectName)
        {
            Project p = _capstone_repo.GetProjectByProjectName(ProjectName);
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                ProjectOutDto pr =  new ProjectOutDto { ProjectID = p.ProjectID, TeamName = p.TeamName, ProjectName = p.ProjectName, Semester = p.Semester, Introduction = p.Introduction, Skill = p.Skill, Approach = p.Approach, Img = p.Img, Video = p.Video, Likes = p.Likes, Comments = p.Comments };
                return Ok(pr);
            }
        }

        [HttpPost("Uploadimage")]
        
        public async Task<IActionResult> Uploadimage(IFormFile file)
        {
            var path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "img");

            var filePath = Path.Combine(imgDir, file.FileName);
            using var fileS = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileS);
            return Ok(file);

        }
        [HttpGet("ProjectPhoto/{Name}")]
        public ActionResult GetPhoto(string Name)
        {
            string path = Directory.GetCurrentDirectory();
            string iDir = Path.Combine(path, "img");
            string F1 = Path.Combine(iDir, Name + ".jpg");
            string F2 = Path.Combine(iDir, Name + ".gif");
            string F3 = Path.Combine(iDir, Name + ".png");
            string F4 = Path.Combine(iDir, Name + ".pdf");
            string respHeader = "";
            string FileName = "";
            if (System.IO.File.Exists(F1))
            {
                respHeader = "image/jpeg";
                FileName = F1;
            }
            else if (System.IO.File.Exists(F2))
            {
                respHeader = "image/gif";
                FileName = F2;
            }
            else if (System.IO.File.Exists(F3))
            {
                respHeader = "image/png";
                FileName = F3;
            }
            else
            {
                respHeader = "image/pdf";
                FileName = F3;
            }
            return PhysicalFile(FileName, respHeader);
        }
        [HttpPut("UpadateProject/{ProjectName}")]
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "StudentOnly")]
        public ActionResult<string> UpdateProject(string ProjectName, ProjectInDtos pi)
        {
            Project project = _capstone_repo.GetProjectByProjectName(ProjectName);
            if (project != null)
            {
                _capstone_repo.UpdateProject(project, pi);
                return Ok("Update Successfully");
            }
            return Ok("Not found");
        }


        [HttpDelete("DeleteProject/{ProjectName}")]
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult<string> DeleteTeam(string ProjectName)
        {
            Project project = _capstone_repo.GetProjectByProjectName(ProjectName);
            ;
            if (project != null)
            {
                _capstone_repo.RemoveProject(ProjectName);
                return "delete successfully";

            }
            return "Not found";

        }

        [HttpPost("RewardProject")]
        public ActionResult<string>RewardProject(AwardDto ad)
        {
            Project project = _capstone_repo.GetProjectByProjectName(ad.ProjectName);
            if (project == null)
            {
                return "Not found";
            }
            _capstone_repo.reward(ad, project);

            return "Reward Successfully";
            
        }

        [HttpGet("GetLikeCount/{ProjectID}")]
        public ActionResult<int> GetLikeCount(int ProjectID)
        {
            return Ok(_capstone_repo.GetLikeCount(ProjectID));
        }

        [HttpPost("UpdateLike")]
        public ActionResult<string> UpdateLike(int ProjectID, bool Plus)
        {
            return Ok(_capstone_repo.UpdateLike(ProjectID, Plus));
        }
    }
}
        



        //[Authorize(AuthenticationSchemes = "MyAuthentication")]
        //[Authorize(Policy = "StudentOnly")]
        //[HttpPost("UploadFiles")]
        //public ActionResult<string> UploadFile(string team_name, string project_name, IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //    {
        //        return BadRequest("No file was uploaded");
        //    }
        //    ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
        //    Claim user = ci.FindFirst("student");
        //    if (user != null && file != null)
        //    {
        //        string name = user.Value;
        //        _capstone_repo.UploadedFiles(team_name, project_name, file, name);
        //        return Ok("File uploaded successfully");
        //    }
        //    return "You have to Login first";
        //}


        //[Authorize(AuthenticationSchemes = "MyAuthentication")]
        //[Authorize(Policy = "StudentOnly")]
        //[HttpPost("UploadMultiFiles")]
        //public ActionResult<string> UploadMultiFile(string team_name, string project_name, List<IFormFile> files)
        //{
        //    ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
        //    Claim user = ci.FindFirst("student");
        //    string name = user.Value;
        //    try
        //    {
        //        foreach (IFormFile file in files)
        //        {
        //            if (file == null || file.Length == 0)
        //            {
        //                return BadRequest("One of your files is empty");
        //            }
        //            if (user != null && file != null)
        //            {
        //                _capstone_repo.UploadedFiles(team_name, project_name, file, name);
        //            }
        //        }
        //        return Ok("File uploaded successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    

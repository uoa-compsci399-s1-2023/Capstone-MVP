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
    public class Capstone_MVP_CommentController:Controller
	{
        private readonly ICapstone_MVPRepo _capstone_repo;

        public Capstone_MVP_CommentController(ICapstone_MVPRepo repository)
        {
            _capstone_repo = repository;
        }
        [HttpPost("WriteComment")]
        public ActionResult<Comment> WriteComment(CommentInDto ci)
        {
            Comment c = new() { Name = ci.Name, CommentText = ci.CommentText, ProjectID = ci.ProjectID };
            Comment comment = _capstone_repo.WriteComment(c);
            return Ok(comment);
        }

        [HttpGet("GetALLComments")]
        public ActionResult<IEnumerable<Comment>> GetALLComments()
        {

            IEnumerable<Comment> c = _capstone_repo.GetAllComments();
            return Ok(c);
        }
        [HttpGet("GetProjectCommentBYProjectID/{ProjectID}")]
        public ActionResult<IEnumerable<Comment>> GetProjectCommentBYProjectID(int ProjectID)
        {

            IEnumerable <Comment> comments = _capstone_repo.GetCommentByProjectID(ProjectID);
            return Ok(comments);
        }
        [HttpDelete("DeleteComment/{CommentID}")]
        
        public ActionResult<string> DeleteComment (int CommentID)
        {
            Comment c = _capstone_repo.GetCommentByID(CommentID);
            if (c == null)
            {
                return "Not found";
            }
            _capstone_repo.RemoveComment(CommentID);
            return "delete successfully";
        }
        

    }
}


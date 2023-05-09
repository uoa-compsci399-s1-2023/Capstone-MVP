using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone_MVP.Model;
using Capstone_MVP.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace Capstone_MVP.Data
{
    public interface ICapstone_MVPRepo
    {
        public bool StudentValidLogin(string email, string password);
        public bool VisitorValidLogin(string email, string password);
        public bool AdminValidLogin(string email, string password);
        public void SaveChanges();
        public void RegisterAdmin(Admin admin);
        public void RegisterStudent(Student s);
        public void RegisterVisitor(Visitor vi);
        public bool CheckAdminRegistration(string email);
        public string CheckStudentRegistration(string email);
        public string CheckVisitorRegistration(string email);
        public IEnumerable<Student> GetAllStudents();
        public IEnumerable<Student> GetStudentByName(string name);
        public IEnumerable<Project> GetProjects();
        public IEnumerable<Project> GetProjectByName(string projectname);
        //public void UploadedFiles(string team_name, string project_name, IFormFile file, string name);
        public Team AddTeam(Team t);
        public IEnumerable<Team> GetAllTeams();
        public Team GetTeamByName(string TeamName);
        public IEnumerable<Team> GetTeamByTeamName(string name);
        public string JoinTeam(TeamInDto t, string email);
        public void RemoveTeam(string TeamName);
        public Project AddProject(Project project);
        public Project GetProjectByProjectName(string ProjectName);
        public void RemoveProject(string ProjectName);
        public void UpdateProject(Project p, ProjectInDtos pi);
        public Comment WriteComment(Comment c);
        public IEnumerable<Comment> GetAllComments();
        public IEnumerable<Comment> GetCommentByProjectID(int ProjectID);
        public Comment GetCommentByID(int ProjectID);
        public void RemoveComment(int CommentID);
        public void reward(AwardDto ad, Project p);
        public int GetLikeCount(int ProjectID);
        public string UpdateLike(int ProjectID, bool Plus);

    }

}
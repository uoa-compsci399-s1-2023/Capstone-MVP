using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using Capstone_MVP.Model;
using Capstone_MVP.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Capstone_MVP.Data
{
    public class Capstone_MVPRepo : ICapstone_MVPRepo
    {
        private readonly Capstone_MVPDBContext DbContext;

        public Capstone_MVPRepo(Capstone_MVPDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public bool AdminValidLogin(string email, string password)
        {
            Admin ad = DbContext.Admins.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (ad == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool StudentValidLogin(string email, string password)
        {
            Student ad = DbContext.Students.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (ad == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool VisitorValidLogin(string email, string password)
        {
            Visitor ad = DbContext.Visitors.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (ad == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void RegisterAdmin(Admin admin)
        {
            Admin a = new Admin();
            a.Id = admin.Id;
            a.Email = admin.Email;
            a.FirstName = admin.FirstName;
            a.LastName = admin.LastName;
            a.Password = admin.Password;
            DbContext.Admins.Add(a);
            DbContext.SaveChanges();
        }
        public void RegisterStudent(Student s)
        {
            Student st = new Student();
            //st.Id = s.Id;
            st.Email = s.Email;
            st.FirstName = s.FirstName;
            st.LastName = s.LastName;
            st.Password = s.Password;
            st.Interest = s.Interest;
            DbContext.Students.Add(st);
            DbContext.SaveChanges();
        }
        public void RegisterVisitor(Visitor visitor)
        {
            Visitor V = new Visitor();
            //V.Id = visitor.Id;
            V.Email = visitor.Email;
            V.FirstName = visitor.FirstName;
            V.LastName = visitor.LastName;
            V.Password = visitor.Password;
            DbContext.Visitors.Add(V);
            DbContext.SaveChanges();
        }
        public bool CheckAdminRegistration(string email)
        {
            if (email == "admin@aucklanduni.ac.nz")
            {
                Admin a = DbContext.Admins.FirstOrDefault(e => e.Email == email);
                if (a == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return true;
            }
        }
        public string CheckStudentRegistration(string email)
        {
            if (email.EndsWith("@aucklanduni.ac.nz") && email != "admin@aucklanduni.ac.nz")
            {
                Student s = DbContext.Students.FirstOrDefault(e => e.Email == email);
                if (s == null)
                {
                    return "available";
                }
                else
                {
                    return "Not available";
                }

            }
            else
            {
                return "Not student email";
            }
        }
        public string CheckVisitorRegistration(string email)
        {
            if (email.EndsWith("@aucklanduni.ac.nz") == false && email != "admin@aucklanduni.ac.nz")
            {
                Visitor v = DbContext.Visitors.FirstOrDefault(e => e.Email == email);
                if (v == null)
                {
                    return "available";
                }
                else
                {
                    return "Not available";
                }

            }
            else
            {
                return "student email";
            }
        }

        public IEnumerable<Project> GetProjects()
        {
            IEnumerable<Project> i = DbContext.Projects.ToList<Project>();
            return i;
        }

        public IEnumerable<Project> GetProjectByName(string projectname)
        {
            IEnumerable<Project> project = DbContext.Projects.Where(e => e.ProjectName.ToLower().Contains(projectname.ToLower()));
            return project;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            IEnumerable<Student> s = DbContext.Students.ToList<Student>();
            return s;
        }
        public IEnumerable<Student> GetStudentByName(string name)
        {
            Console.WriteLine(name);
            List<Student> student = new List<Student>();
            foreach (Student s in DbContext.Students.ToList<Student>())
            {
                Console.WriteLine(s);
                string Name = s.FirstName + " " + s.LastName;
                if (Name.ToLower().Contains(name.ToLower()))
                {
                    student.Add(s);
                }
            }
            return student;
        }

        public IEnumerable<Team> GetTeamByTeamName(string name)
        {
            
            List<Team> team = new List<Team>();
            foreach (Team t in DbContext.Teams.ToList<Team>())
            {
               string Teamname = t.TeamName;
                if(Teamname.ToLower().Contains(name.ToLower()))
                {
                    team.Add(t);
                }
            }
            return team;
        }
        //public async void UploadedFiles(string team_name, string project_name, IFormFile file, string name)
        //{
        //    Student student = DbContext.Students.FirstOrDefault(e => e.Email == name);
        //    if (student != null)
        //    {
        //        var fileData = new byte[file.Length];
        //        using (var stream = file.OpenReadStream())
        //        {
        //            await stream.ReadAsync(fileData, 0, fileData.Length);
        //        }

        //        var fileInfo = new FileInfo(file.FileName);
        //        var fileType = fileInfo.Extension;

        //        var uploadedFile = new Project
        //        {
        //            StudentId = student.Id,
        //            TeamName = team_name,
        //            ProjectName = project_name,
        //            FileName = file.FileName,
        //            FileType = fileType,
        //            FileSize = file.Length,
        //            Data = fileData
        //        };

        //        DbContext.Projects.Add(uploadedFile);
        //    }
        //    await DbContext.SaveChangesAsync();
        //}
        public Team AddTeam(Team t)
        {
            Team team = new Team();
            team.TeamName = t.TeamName;
            team.Student1 = t.Student1;
            team.Student2 = t.Student2;
            team.Student3 = t.Student3;
            team.Student4 = t.Student4;
            team.Student5 = t.Student5;
            team.Student6 = t.Student6;
            DbContext.Teams.Add(team);
            DbContext.SaveChanges();
            return team;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            IEnumerable<Team> t = DbContext.Teams.ToList<Team>();
            return t;
        }

        public Team GetTeamByName(string TeamName)
        {
            Team t = DbContext.Teams.FirstOrDefault(e => e.TeamName == TeamName);
            return t;
        }


        public string JoinTeam(TeamInDto t, string email)
        {
            Student st = DbContext.Students.FirstOrDefault(e => e.Email == email);
            string name = st.FirstName + " " + st.LastName;
            Team team = DbContext.Teams.FirstOrDefault(e => e.TeamName == t.TeamName);

            if (team.Student1 == "")
            {
                team.Student1 = name;
                DbContext.SaveChanges();
                return team.Student1;
            }
            else if (team.Student2 == "")
            {
                team.Student2 = name;
                DbContext.SaveChanges();
                return team.Student2;
            }
            else if (team.Student3 == "")
            {
                team.Student3 = name;
                DbContext.SaveChanges();
                return team.Student3;
            }
            else if (team.Student4 == "")
            {
                team.Student4 = name;
                DbContext.SaveChanges();
                return team.Student4;
            }
            else if (team.Student5 == "")
            {
                team.Student5 = name;
                DbContext.SaveChanges();
                return team.Student5;
            }
            else if (team.Student6 == "")
            {
                team.Student6 = name;
                DbContext.SaveChanges();
                return team.Student6;
            }
            return "This team is full";

        }
        
        public void RemoveTeam(string TeamName)
        {
            IEnumerable<Team> teams = DbContext.Teams.ToList<Team>();
            Team team = teams.FirstOrDefault(e => e.TeamName == TeamName);
            if (team != null)
            {
                DbContext.Teams.Remove(team);
                DbContext.SaveChanges();
            }
        }
        public Project AddProject(Project project)
        {
            Project p  = new Project();
            p.ProjectID = project.ProjectID;
            p.TeamName = project.TeamName;
            p.ProjectName = project.ProjectName;
            p.Semester = project.Semester;
            p.Introduction = project.Introduction;
            p.Skill = project.Skill;
            p.Approach = project.Approach;
            p.Likes = project.Likes;
            p.Img = project.Img;
            p.Video = project.Video;
            p.Comments = project.Comments;
            DbContext.Projects.Add(p);
            DbContext.SaveChanges();
            return p;
        }

        public Project GetProjectByProjectName(string ProjectName)
        {
            Project p = DbContext.Projects.FirstOrDefault(e => e.ProjectName == ProjectName);
            return p;
        }
        public void RemoveProject(string ProjectName)
        {
            IEnumerable<Project> projects = DbContext.Projects.ToList<Project>();
            Project project = projects.FirstOrDefault(e => e.ProjectName == ProjectName);
            if (project!= null)
            {
                DbContext.Projects.Remove(project);
                DbContext.SaveChanges();
            }
        }
        public void UpdateProject(Project p, ProjectInDtos pi)
        {
            p.TeamName = pi.TeamName;
            p.ProjectName = pi.ProjectName;
            p.Introduction = pi.Introduction;
            p.Approach = pi.Approach;
            p.Skill = pi.Skill;
            p.Img = pi.Img;
            p.Video = pi.Video;
            DbContext.SaveChanges();
        }
        public void reward(AwardDto ad, Project p)
        {
            p.CommunityImpact1 = ad.CommunityImpact1;
            p.CommunityImpact2 = ad.CommunityImpact2;
            p.Excellence1 = ad.Excellence1;
            p.Excellence2 = ad.Excellence2;
            p.PeopleChoice1 = ad.PeopleChoice1;
            p.PeopleChoice2 = ad.PeopleChoice2;
            DbContext.SaveChanges();
        }
        
        public Comment  WriteComment (Comment c)
        {
            Comment comment = new Comment();
            comment.Name = c.Name;
            comment.CommentText = c.CommentText;
            comment.ProjectID = c.ProjectID;
            DbContext.Comments.Add(comment);
            DbContext.SaveChanges();
            return comment;
        }
        public IEnumerable<Comment> GetAllComments()
        {
            IEnumerable<Comment> c = DbContext.Comments.ToList<Comment>();
            return c;
        }
        public IEnumerable<Comment> GetCommentByProjectID(int ProjectID)
        {
            IEnumerable<Comment> comments = DbContext.Comments.Where(e => e.ProjectID == ProjectID);
            return comments;
        }
        public void  RemoveComment (int CommentID)
        {
            IEnumerable<Comment> Comments = DbContext.Comments.ToList<Comment>();
            Comment c = Comments.FirstOrDefault(e => e.CommentID == CommentID);
            if (c != null)
            {
                DbContext.Comments.Remove(c);
                DbContext.SaveChanges();
               
            }
            
        }
        public Comment GetCommentByID(int ProjectID)
        {
            Comment c = DbContext.Comments.FirstOrDefault(e => e.ProjectID == ProjectID);
            return c;
        }

        public int GetLikeCount(int ProjectID)
        {
            Project project = DbContext.Projects.FirstOrDefault(e => e.ProjectID == ProjectID);
            if (project != null)
            {
                return project.Likes;
            }
            return -1;
        }
        public string UpdateLike(int ProjectID, bool Plus)
        {
            Project project = DbContext.Projects.FirstOrDefault(e => e.ProjectID == ProjectID);
            if (project != null && Plus)
            {
                project.Likes = project.Likes + 1;
                DbContext.SaveChanges();
                return "project " + ProjectID + "'s like + 1";
            }
            else
            {
                project.Likes = project.Likes - 1;
                DbContext.SaveChanges();
                return "project " + ProjectID + "'s like - 1";
            }
            return "Can not find project" + ProjectID;
        }

    }
}
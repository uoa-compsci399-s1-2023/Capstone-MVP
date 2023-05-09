using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capstone_MVP.Model
{
    public class Project{
        [Key]
        public int ProjectID { get; set; }
        //public int StudentId { get; set; }
        public string TeamName { get; set; }
        public string ProjectName { get; set; }
        public string? Semester { get; set; }
        public string? Introduction { get; set; }
        public string? Skill { get; set; }
        public string? Approach { get; set; }
        public string? Img { get; set; }
        public string? Video { get; set; }
        public string? Client { get; set; }
        public int Excellence1 { get; set; }
        public int Excellence2 { get; set; }
        public int CommunityImpact1 { get; set; }
        public int CommunityImpact2 { get; set; }
        public int PeopleChoice1 { get; set; }
        public int PeopleChoice2 { get; set; }
        public int Likes { get; set; } = 0;
        //public string? TeamMembers { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        
    }
}

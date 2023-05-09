using Capstone_MVP.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_MVP.Dtos
{
    public class ProjectOutDto
    {
        public int ProjectID { get; set; }
        public string? TeamName { get; set; }
        public string? ProjectName { get; set; }
        public string? Semester { get; set; }
        public string? Introduction { get; set; }
        public string? Skill { get; set; }
        public string? Approach { get; set; }
        public string? Img { get; set; }
        public string? Video { get; set; }
        public string? Client { get; set; }
        //public bool? PeopleWin { get; set; }
        //public bool? PeopleTwo { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public int? Likes { get; set; }
        public ICollection<Student>? TeamMembers { get; set; }
    }
}

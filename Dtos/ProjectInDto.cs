using Capstone_MVP.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_MVP.Dtos
{
    public class ProjectInDtos
    {

        public string TeamName { get; set; }
        public string ProjectName { get; set; }
        public string? Introduction { get; set; }
        public string? Skill { get; set; }
        public string? Approach { get; set; }
        public string? Img { get; set; }
        public string? Video { get; set; }
        

    }
}

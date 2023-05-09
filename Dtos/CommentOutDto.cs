using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_MVP.Dtos
{
    public class CommentOutDto
    {
        public string? Name { get; set; }
        public string CommentText { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capstone_MVP.Model
{
    public class Comment{
        [Key]
        public int CommentID { get; set; }
        public int ProjectID { get; set; }
        public string? Name { get; set; }
        public string CommentText { get; set; }
    }
}

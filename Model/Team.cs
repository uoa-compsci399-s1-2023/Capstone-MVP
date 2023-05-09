using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Capstone_MVP.Model
{
	public class Team
	{
        [Key]
		public string TeamName { get; set; }
		public string? Student1 { get; set; } = null;
        public string? Student2 { get; set; } = null;
        public string? Student3 { get; set; } = null;
        public string? Student4 { get; set; } = null;
        public string? Student5 { get; set; } = null;
        public string? Student6 { get; set; } = null;


        }
}



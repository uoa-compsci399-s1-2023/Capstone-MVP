using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_MVP.Dtos
{
	public class TeamInDto
	{
        [Key]
        public string TeamName { get; set; }

    }
}

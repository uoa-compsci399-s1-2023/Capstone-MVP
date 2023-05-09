using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Capstone_MVP.Dtos
{
	public class AwardDto
	{
		public string ProjectName { get; set; }
        public int Excellence1 { get; set; }
        public int Excellence2 { get; set; }
        public int CommunityImpact1 { get; set; }
        public int CommunityImpact2 { get; set; }
        public int PeopleChoice1 { get; set; }
        public int PeopleChoice2 { get; set; }

    }
}


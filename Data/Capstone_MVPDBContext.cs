using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Capstone_MVP.Model;

namespace Capstone_MVP.Data
{
	public class Capstone_MVPDBContext : DbContext
	{
        public Capstone_MVPDBContext(DbContextOptions<Capstone_MVPDBContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Visitor> Visitors { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source = Capstone_MVPDatabase.sqlite");
		}
	}
}
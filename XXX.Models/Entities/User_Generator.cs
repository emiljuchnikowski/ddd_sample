using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XXX.Models.Entities {
	[Table("app.User")]
	public partial class User {
		[Column("Id")]

		public Int32 Id { get; set; } 
		[Column("Email")]

		public String Email { get; set; } 
		[Column("Password")]

		public String Password { get; set; } 
		[Column("FirstName")]

		public String FirstName { get; set; } 
		[Column("LastName")]

		public String LastName { get; set; } 
		[Column("Phone")]

		public String Phone { get; set; } 
		[Column("ChangePasswordToken")]

		public Guid? ChangePasswordToken { get; set; } 

	}
}

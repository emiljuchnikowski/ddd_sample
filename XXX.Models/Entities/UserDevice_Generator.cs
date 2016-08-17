using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XXX.Models.Entities {
	[Table("app.UserDevice")]
	public partial class UserDevice {
		[Column("Id")]

		public Int32 Id { get; set; } 
		[Column("Email")]

		public String Email { get; set; } 
		[Column("Password")]

		public String Password { get; set; } 
		[Column("Uuid")]

		public String Uuid { get; set; } 

	}
}

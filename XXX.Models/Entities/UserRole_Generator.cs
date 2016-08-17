using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XXX.Models.Entities {
	[Table("app.UserRole")]
	public partial class UserRole {
		[Column("Id")]

		public Int32 Id { get; set; } 
		[Column("Name")]

		public String Name { get; set; } 
		[Column("UserId")]

		public Int32 UserId { get; set; } 

	}
}

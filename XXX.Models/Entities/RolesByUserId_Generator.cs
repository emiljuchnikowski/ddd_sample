using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XXX.Models.Entities {
	[Table("app.RolesByUserId")]
	public partial class RolesByUserId {
		[Column("Id")]

		public Int32 Id { get; set; } 
		[Column("Name")]

		public String Name { get; set; } 

	}
}

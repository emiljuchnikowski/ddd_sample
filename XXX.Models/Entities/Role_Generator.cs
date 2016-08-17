using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XXX.Models.Entities {
	[Table("app.Role")]
	public partial class Role {
		[Column("Id")]

		public Int32 Id { get; set; } 
		[Column("Name")]

		public String Name { get; set; } 

	}
}

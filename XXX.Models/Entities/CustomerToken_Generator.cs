using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XXX.Models.Entities {
	[Table("app.CustomerToken")]
	public partial class CustomerToken {
		[Column("Token")]

		public String Token { get; set; } 
		[Column("Used")]

		public Boolean Used { get; set; } 
		[Column("Uuid")]

		public String Uuid { get; set; } 
		[Column("UserId")]

		public Int32? UserId { get; set; } 
		[Column("SendToEmail")]

		public String SendToEmail { get; set; } 

	}
}

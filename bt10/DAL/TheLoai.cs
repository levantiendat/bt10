using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt10.DAL
{
	[Table("THELOAI")]
	public class TheLoai
	{
		[Key]
		[Required]
		[StringLength(5)]
		public string ID_TheLoai { get; set; }
		public string Name { get; set; }
		public virtual ICollection<BaiBao> BaiBaos { get; set; }
		public TheLoai()
		{
			BaiBaos = new HashSet<BaiBao>();
		}
	}
}

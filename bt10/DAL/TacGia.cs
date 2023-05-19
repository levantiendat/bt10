using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt10.DAL
{
	[Table("TACGIA")]
	public class TacGia
	{
		[Key]
		[Required]
		[StringLength(5)]
		public string ID_TG { get; set; }
		public string Name { get; set; }
		public string ID_NXB { get; set; }
		[ForeignKey("ID_NXB")]
		public virtual NhaXuatBan NhaXuatBan { get; set; }
		public virtual ICollection<BaiBao> BaiBaos { get; set; }
		public TacGia()
		{
			BaiBaos = new HashSet<BaiBao>();
		}
	}
}

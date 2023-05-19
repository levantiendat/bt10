using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt10.DAL
{
	[Table("BAIBAO")]
	public class BaiBao
	{
		[Key]
		[Required]
		[StringLength(10)]
		public string ID_BB { get; set; }
		public string Name { get; set; }
		public Boolean TinhTrang { get; set; }
		public int NamXuatBan { get; set; }
		[StringLength(5)]
		public string ID_TheLoai { get; set; }
		[ForeignKey("ID_TheLoai")]
		public virtual TheLoai TheLoai { get; set; }
		[StringLength(5)]
		public string ID_TG { get; set; }
		[ForeignKey("ID_TG")]
		public virtual TacGia TacGia { get; set; }
	}
}

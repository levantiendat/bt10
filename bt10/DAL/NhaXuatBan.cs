using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt10.DAL
{
	[Table("NHAXUATBAN")]
	public class NhaXuatBan
	{
		[Key]
		[Required]
		[StringLength(5)]
		public string ID_NXB { get; set; }
		public string Name { get; set; }
		public virtual ICollection<TacGia> TacGias { get; set; }
		
		public NhaXuatBan() 
		{
			TacGias = new HashSet<TacGia>();
			
		}
	}
}

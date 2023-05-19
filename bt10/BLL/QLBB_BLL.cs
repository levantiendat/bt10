using bt10.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace bt10.BLL
{
	public class QLBB_BLL
	{
		public List<CBBItems> GetAllNXB()
		{
			List<CBBItems> list= new List<CBBItems>();
			DBQLBBKK db=new DBQLBBKK();
			foreach(NhaXuatBan nxb in db.NhaXuatBans.ToList())
			{
				list.Add(new CBBItems
				{
					value = nxb.ID_NXB,
					text=nxb.Name
				});
			}
			return list;
		}
		public List<CBBItems> GetAllNXB(int i)
		{
			List<CBBItems> list = new List<CBBItems>();
			list.Add(new CBBItems { value = "", text = "ALL" });
			DBQLBBKK db = new DBQLBBKK();
			foreach (NhaXuatBan nxb in db.NhaXuatBans.ToList())
			{
				list.Add(new CBBItems
				{
					value = nxb.ID_NXB,
					text = nxb.Name
				});
			}
			return list;
		}
		public List<Show001> GetDataFromSearch(string nxb, int namxb, int tt,string txt)
		{
			List<Show001> list=new List<Show001>();
			DBQLBBKK db = new DBQLBBKK();
			List<BaiBao> bb=new List<BaiBao>();
			if(nxb.Length > 0)
			{
				bb=db.BaiBaos.Where(p=>p.TacGia.ID_NXB.CompareTo(nxb)==0).ToList();
			}
			else
			{
				bb = db.BaiBaos.ToList();
			}
			if (namxb > 0)
			{
				List<BaiBao> bb1 = new List<BaiBao>(bb);
				foreach (BaiBao bao in bb1)
				{
					if (bao.NamXuatBan != namxb)
					{
						bb.Remove(bao);
					}
				}
			}
			if (tt >= 0)
			{
				List<BaiBao> bb1 = new List<BaiBao>(bb);
				foreach (BaiBao bao in bb1)
				{
					if (bao.TinhTrang != Convert.ToBoolean(tt))
					{
						bb.Remove(bao);
					}
				}
			}
			if(txt.Length > 0)
			{
				List<BaiBao> bb1 = new List<BaiBao>(bb);
				foreach (BaiBao bao in bb1)
				{
					int check = 0;
					if (bao.ID_BB.Contains(txt))
					{
						check = 1;
					}
					if(bao.Name.Contains(txt))
					{
						check = 1;
					}
					if (bao.TacGia.Name.Contains(txt))
					{
						check = 1;
					}
					if (bao.TacGia.NhaXuatBan.Name.Contains(txt)){
						check = 1;
					}
					try
					{
						if (bao.NamXuatBan == Convert.ToInt32(txt))
						{
							check = 1;
						}
					}catch (Exception ex) { }
					if (check == 1)
					{
						list.Add(new Show001
						{
							MABAIBAO = bao.ID_BB,
							TENBAIBAO = bao.Name,
							TACGIA = bao.TacGia.Name,
							NHAXUATBAN = bao.TacGia.NhaXuatBan.Name,
							TINHTRANG = bao.TinhTrang,
							NAMXUATBAN=bao.NamXuatBan,
						}) ;

					}
				}
				
			}
			else
			{
				foreach(BaiBao bao in bb)
				{
					list.Add(new Show001
					{
						MABAIBAO = bao.ID_BB,
						TENBAIBAO = bao.Name,
						TACGIA = bao.TacGia.Name,
						NHAXUATBAN = bao.TacGia.NhaXuatBan.Name,
						TINHTRANG = bao.TinhTrang,
						NAMXUATBAN = bao.NamXuatBan,
					});
				}
			}
			return list;
			
		}
		public List<CBBItems> GetAllTL()
		{
			List<CBBItems> list = new List<CBBItems>();
			DBQLBBKK db = new DBQLBBKK();
			foreach(TheLoai tl in db.TheLoais.ToList())
			{
				list.Add(new CBBItems { value=tl.ID_TheLoai,text=tl.Name});
			}
			return list;
		}
		public List<CBBItems> GetTacGiaByNXB(string ID_NXB)
		{
			List<CBBItems> list = new List<CBBItems>();
			DBQLBBKK db = new DBQLBBKK();
			foreach (TacGia tg in db.TacGias.Where(p=>p.ID_NXB.CompareTo(ID_NXB)==0).ToList())
			{
				list.Add(new CBBItems { value = tg.ID_TG, text = tg.Name });
			}
			return list;
		}
		public BaiBao GetBBByID(string id)
		{
			DBQLBBKK db = new DBQLBBKK();
			return db.BaiBaos.Where(p=>p.ID_BB.CompareTo(id)==0).FirstOrDefault();
		}
		public void ADD(BaiBao bao)
		{
			try
			{
				DBQLBBKK db = new DBQLBBKK();
				db.BaiBaos.Add(bao);
				db.SaveChanges();
			}
			catch
			{
				MessageBox.Show("ERROR ADD");
			}
			

		}
		public void Update(BaiBao bao)
		{
			try
			{
				DBQLBBKK db = new DBQLBBKK();
				BaiBao bb=db.BaiBaos.Where(p=>p.ID_BB.CompareTo(bao.ID_BB)==0).FirstOrDefault();
				if (bb!=null)
				{
					bb.Name = bao.Name;
					bb.ID_TG = bao.ID_TG;
					bb.ID_TheLoai = bao.ID_TheLoai;
					bb.NamXuatBan= bao.NamXuatBan;
					bb.TinhTrang= bao.TinhTrang;
					db.SaveChanges();
				}
				
				
			}
			catch
			{
				MessageBox.Show("ERROR UPDATE");
			}
		}
		public void Delete(List<String> list)
		{
			try
			{
				DBQLBBKK db = new DBQLBBKK();
				foreach(String s in list)
				{
					BaiBao b=db.BaiBaos.Where(p=>p.ID_BB.CompareTo(s)==0).FirstOrDefault();
					db.BaiBaos.Remove(b);
					db.SaveChanges();
				}


			}
			catch
			{
				MessageBox.Show("ERROR UPDATE");
			}
		}
	}
}

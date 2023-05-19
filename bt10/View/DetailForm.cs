using bt10.BLL;
using bt10.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bt10.View
{
	public partial class DetailForm : Form
	{
		public delegate void MyDel(string nxb, int namxb, int tt, string txt);
		public MyDel d { get; set; }
		public string ma { get; set; }
		public DetailForm(string code)
		{
			ma = code;
			InitializeComponent();
			GUi();
		}
		public void GUi()
		{
			QLBB_BLL bll=new QLBB_BLL();
			cbbTheLoai.Items.AddRange(bll.GetAllTL().ToArray());
			cbbNXB.Items.AddRange(bll.GetAllNXB().ToArray());
			cbbTT.Items.Add("Đã phát hành");
			cbbTT.Items.Add("Chưa phát hành");
			for (int i = 2023; i > 1970; i--)
			{
				cbbNamXB.Items.Add(i);
			}
			if (ma.Length > 0)
			{
				BaiBao bb = new BaiBao();
				bb=bll.GetBBByID(ma);
				txtID.Text = bb.ID_BB;
				txtName.Text = bb.Name;
				cbbTheLoai.Text = bb.TheLoai.Name;
				cbbNXB.Text = bb.TacGia.NhaXuatBan.Name;
				cbbTacGia.Text = bb.TacGia.Name;
				if (bb.TinhTrang)
				{
					cbbTT.SelectedIndex = 0;
				}
				else cbbTT.SelectedIndex = 1;
				cbbNamXB.Text = bb.NamXuatBan.ToString();
				txtID.Enabled = false;

			}
			
		}

		private void cbbNXB_SelectedIndexChanged(object sender, EventArgs e)
		{
			QLBB_BLL bll = new QLBB_BLL();
			
			string ID_NXB = ((CBBItems)cbbNXB.SelectedItem).value;
			cbbTacGia.Items.Clear();
			cbbTacGia.Items.AddRange(bll.GetTacGiaByNXB(ID_NXB).ToArray());
			cbbTacGia.SelectedIndex = 0;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				QLBB_BLL bll = new QLBB_BLL();
				BaiBao bb=new BaiBao();
				bb.ID_BB=txtID.Text;
				bb.Name=txtName.Text;
				bb.ID_TheLoai= ((CBBItems)cbbTheLoai.SelectedItem).value;
				
				bb.ID_TG= ((CBBItems)cbbTacGia.SelectedItem).value;
				if(cbbTT.SelectedIndex == 0)
				{
					bb.TinhTrang = true;
				}
				else
				{
					bb.TinhTrang = false;
				}
				bb.NamXuatBan = Convert.ToInt32(cbbNamXB.SelectedItem.ToString());
				if (ma.Length > 0)
				{
					bll.Update(bb);
				}
				else
				{
					bll.ADD(bb);
				}
				d("", 0, -1, "");
				this.Close();
			}
			catch
			{
				MessageBox.Show("Your information is invalid");
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

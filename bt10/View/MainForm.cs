using bt10.BLL;
using bt10.DAL;
using bt10.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bt10
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			SetFilter();
		}
		public void SetFilter()
		{
			cbbTT.Items.Add("ALL");
			cbbTT.Items.Add("Đã phát hành");
			cbbTT.Items.Add("Chưa phát hành");

			cbbNamXB.Items.Add("ALL");
			for(int i = 2023; i > 1970; i--)
			{
				cbbNamXB.Items.Add(i);
			}
			QLBB_BLL bll=new QLBB_BLL();
			cbbNXB.Items.AddRange(bll.GetAllNXB(1).ToArray());

			cbbTT.SelectedIndex = 0;
			cbbNamXB.SelectedIndex = 0;
			cbbNXB.SelectedIndex = 0;
		}
		public void SetDGV(string nxb,int namxb,int tt,string txt)
		{
			QLBB_BLL bll=new QLBB_BLL();
			data.DataSource = bll.GetDataFromSearch(nxb, namxb, tt, txt);
		}
		private void btnAdd_Click(object sender, EventArgs e)
		{
			DetailForm df = new DetailForm("");
			df.d += new DetailForm.MyDel(SetDGV);
			df.Show();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (data.SelectedRows.Count == 1)
			{
				string id = data.SelectedRows[0].Cells["MABAIBAO"].Value.ToString();
				MessageBox.Show(id);
				DetailForm df = new DetailForm(id);
				df.d += new DetailForm.MyDel(SetDGV);
				df.Show();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (data.SelectedRows.Count > 0)
			{
				List<string> list = new List<string>();
				foreach (DataGridViewRow row in data.SelectedRows) 
				{
					DialogResult at = MessageBox.Show("Bạn có muốn xóa DATN có mã số " + row.Cells["MABAIBAO"].Value.ToString() + " không ?", "Confirm", MessageBoxButtons.OKCancel);
					if (at == DialogResult.OK)
					{
						list.Add(row.Cells["MABAIBAO"].Value.ToString());
					}
					
				}
				QLBB_BLL bll=new QLBB_BLL();
				bll.Delete(list);
				SetDGV("", 0, -1, "");
				
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			string nxb = "";
			int namxb = 0;
			int tt = -1;
			string txt=txtSearch.Text.Trim();

			if (cbbNXB.SelectedIndex > 0)
			{
				nxb = ((CBBItems)cbbNXB.SelectedItem).value.ToString();
			}

			if (cbbNamXB.SelectedIndex > 0)
			{
				namxb = Convert.ToInt32(cbbNamXB.SelectedItem.ToString());
			}
			if (cbbTT.SelectedIndex == 1)
			{
				tt = 1;
			}
			else if (cbbTT.SelectedIndex == 2) { tt = 0; }
			SetDGV(nxb, namxb, tt, txt);
		}

		private void Filter_Changed(object sender, EventArgs e)
		{
			string nxb = "";
			int namxb = 0;
			int tt = -1;

			if (cbbNXB.SelectedIndex>0){
				nxb = ((CBBItems)cbbNXB.SelectedItem).value.ToString();
			}
			
			if (cbbNamXB.SelectedIndex > 0)
			{
				namxb=Convert.ToInt32(cbbNamXB.SelectedItem.ToString());
			}
			if (cbbTT.SelectedIndex ==1)
			{
				tt = 1;
			}
			else if (cbbTT.SelectedIndex ==2) { tt = 0; }
			SetDGV(nxb, namxb, tt,"");
		}
	}
}

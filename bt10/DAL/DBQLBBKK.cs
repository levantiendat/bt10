using System;
using System.Data.Entity;
using System.Linq;

namespace bt10.DAL
{
	public class DBQLBBKK : DbContext
	{
		// Your context has been configured to use a 'DBQLBBKK' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'bt10.DAL.DBQLBBKK' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'DBQLBBKK' 
		// connection string in the application configuration file.
		public DBQLBBKK()
			: base("name=DBQLBBKK")
		{
		}
		public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
		public virtual DbSet<TacGia> TacGias { get; set; }
		public virtual DbSet<TheLoai> TheLoais { get; set; }
		public virtual DbSet<BaiBao> BaiBaos { get; set;}
		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}
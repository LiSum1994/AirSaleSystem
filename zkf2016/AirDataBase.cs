namespace zkf2016
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AirDataBase : DbContext
    {
     
        public AirDataBase()
            : base("name=AirDataBase")
        {
        }
        
        public virtual DbSet<User1> User { get; set; }
        public virtual DbSet<Goods1> Goods { get; set; }
        public virtual DbSet<Sell> Sells { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var UserTable = modelBuilder.Entity<User1>();
            var GoodsTable = modelBuilder.Entity<Goods1>();
            var SellsTable = modelBuilder.Entity<Sell>();
            UserTable.HasKey(o => o.UserId);
            GoodsTable.HasKey(o => o.GoodsId);
            SellsTable.HasKey(o => o.SellsId);
            base.OnModelCreating(modelBuilder);
        }

    }

    /// 用户表
    public class User1
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }

    /// 商品表
    public class Goods1
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsBuyPrice { get; set; }
        public string GoodsSellPrice { get; set; }
        public long GoodsNumber { get; set; }
        public DateTime GoodsBuyDate { get; set; }

    }

    /// 商品销售表
    public class Sell
    {
        public int SellsId { get; set; }
        public string SellsName { get; set; }
        public string SellsSellPrice { get; set; }
        public long SellsNumber { set; get; }
        public DateTime SellsSellDate { get; set; }
    }

}
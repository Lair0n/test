using FlowersShopApp.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FlowersShopApp.Model
{
    public partial class Shop_Model : DbContext
    {
        static Shop_Model shop_Model;
        public Shop_Model()
            : base("name=Shop_Model")
        {
        }
        public static Shop_Model GetContext()//получение контекста базы данных
        {
            if (shop_Model == null)
            {
                shop_Model = new Shop_Model();
            }
            return shop_Model;
        }

        public virtual DbSet<Akzii> Akzii { get; set; }
        public virtual DbSet<Doljnosti> Doljnosti { get; set; }
        public virtual DbSet<Dostavka> Dostavka { get; set; }
        public virtual DbSet<Klienty> Klienty { get; set; }
        public virtual DbSet<Korzina> Korzina { get; set; }
        public virtual DbSet<Oplaty> Oplaty { get; set; }
        public virtual DbSet<Otzivy> Otzivy { get; set; }
        public virtual DbSet<Postavki> Postavki { get; set; }
        public virtual DbSet<Postavschiki> Postavschiki { get; set; }
        public virtual DbSet<Prodaji> Prodaji { get; set; }
        public virtual DbSet<Reiting_zvetov> Reiting_zvetov { get; set; }
        public virtual DbSet<Skidki> Skidki { get; set; }
        public virtual DbSet<Sklad> Sklad { get; set; }
        public virtual DbSet<Sotrudniki> Sotrudniki { get; set; }
        public virtual DbSet<Tip_oplaty> Tip_oplaty { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Zakazy> Zakazy { get; set; }
        public virtual DbSet<Zakazy_klientov> Zakazy_klientov { get; set; }
        public virtual DbSet<Zveta> Zveta { get; set; }
        public virtual DbSet<Zvety> Zvety { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Akzii>()
                .Property(e => e.nazvanie)
                .IsFixedLength();

            modelBuilder.Entity<Akzii>()
                .HasMany(e => e.Skidki)
                .WithRequired(e => e.Akzii)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doljnosti>()
                .Property(e => e.nazvanie)
                .IsFixedLength();

            modelBuilder.Entity<Doljnosti>()
                .HasMany(e => e.Sotrudniki)
                .WithRequired(e => e.Doljnosti)
                .HasForeignKey(e => e.doljnost)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dostavka>()
                .Property(e => e.adres_dostavki)
                .IsFixedLength();

            modelBuilder.Entity<Klienty>()
                .Property(e => e.familiya)
                .IsFixedLength();

            modelBuilder.Entity<Klienty>()
                .Property(e => e.imya)
                .IsFixedLength();

            modelBuilder.Entity<Klienty>()
                .Property(e => e.otchestvo)
                .IsFixedLength();

            modelBuilder.Entity<Klienty>()
                .Property(e => e.adres)
                .IsFixedLength();

            modelBuilder.Entity<Klienty>()
                .Property(e => e.nomer_telefona)
                .IsFixedLength();

            modelBuilder.Entity<Klienty>()
                .HasMany(e => e.Dostavka)
                .WithRequired(e => e.Klienty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klienty>()
                .HasMany(e => e.Korzina)
                .WithRequired(e => e.Klienty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klienty>()
                .HasMany(e => e.Otzivy)
                .WithRequired(e => e.Klienty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klienty>()
                .HasMany(e => e.Zakazy)
                .WithRequired(e => e.Klienty)
                .HasForeignKey(e => e.klient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klienty>()
                .HasMany(e => e.Zakazy_klientov)
                .WithRequired(e => e.Klienty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Otzivy>()
                .Property(e => e.text_otziva)
                .IsFixedLength();

            modelBuilder.Entity<Postavschiki>()
                .Property(e => e.naimenovanie)
                .IsFixedLength();

            modelBuilder.Entity<Postavschiki>()
                .Property(e => e.adres)
                .IsFixedLength();

            modelBuilder.Entity<Postavschiki>()
                .Property(e => e.nomer_telefona)
                .IsFixedLength();

            modelBuilder.Entity<Postavschiki>()
                .HasMany(e => e.Postavki)
                .WithRequired(e => e.Postavschiki)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reiting_zvetov>()
                .Property(e => e.reiting)
                .HasPrecision(1, 0);

            modelBuilder.Entity<Sklad>()
                .Property(e => e.adres)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.familiya)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.imya)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.otchestvo)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Prodaji)
                .WithRequired(e => e.Sotrudniki)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tip_oplaty>()
                .Property(e => e.nazvanie)
                .IsFixedLength();

            modelBuilder.Entity<Tip_oplaty>()
                .HasMany(e => e.Oplaty)
                .WithRequired(e => e.Tip_oplaty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.login)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .Property(e => e.parol)
                .IsFixedLength();

            modelBuilder.Entity<Zakazy>()
                .HasMany(e => e.Oplaty)
                .WithRequired(e => e.Zakazy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zakazy>()
                .HasMany(e => e.Prodaji)
                .WithRequired(e => e.Zakazy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zakazy>()
                .HasMany(e => e.Zakazy_klientov)
                .WithRequired(e => e.Zakazy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zveta>()
                .Property(e => e.nazvanie)
                .IsFixedLength();

            modelBuilder.Entity<Zveta>()
                .HasMany(e => e.Zvety)
                .WithRequired(e => e.Zveta)
                .HasForeignKey(e => e.zvet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zvety>()
                .Property(e => e.imya)
                .IsFixedLength();

            modelBuilder.Entity<Zvety>()
                .HasMany(e => e.Korzina)
                .WithRequired(e => e.Zvety)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zvety>()
                .HasMany(e => e.Postavki)
                .WithRequired(e => e.Zvety)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zvety>()
                .HasMany(e => e.Reiting_zvetov)
                .WithRequired(e => e.Zvety)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zvety>()
                .HasMany(e => e.Skidki)
                .WithRequired(e => e.Zvety)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zvety>()
                .HasMany(e => e.Sklad)
                .WithRequired(e => e.Zvety)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zvety>()
                .HasMany(e => e.Zakazy)
                .WithRequired(e => e.Zvety1)
                .HasForeignKey(e => e.zvety)
                .WillCascadeOnDelete(false);
        }
    }
}

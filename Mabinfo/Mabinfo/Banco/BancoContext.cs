using Mabinfo.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Mabinfo.Banco
{
    public class BancoContext : DbContext
    {
		public DbSet<ModelAction> ModelActions { get; set; }
        public DbSet<ModelEvent> ModelEvents { get; set; }
        public DbSet<ModelLed> ModelLeds { get; set; }
        public DbSet<ModelNozzle> ModelNozzles { get; set; }
        public static object Current { get; internal set; }


        public BancoContext()
        {


       Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object p = optionsBuilder.UseSqlite($"Filename = {Constante.CaminhoDoBanco} ");
        }
    }
}

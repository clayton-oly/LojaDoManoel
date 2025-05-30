using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LojaDoManoel.Service
{
    public class LojaDoManoelContext : DbContext
    {
        public LojaDoManoelContext(DbContextOptions<LojaDoManoelContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.PedidoId);
                entity.Property(e => e.PedidoId).ValueGeneratedOnAdd();
                entity.HasMany(e => e.Produtos)
                    .WithOne(p => p.Pedido)
                    .HasForeignKey(p => p.PedidoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.ProdutoId);
                entity.Property(p => p.ProdutoCodigo).IsRequired();
                entity.Property(p => p.Altura).IsRequired();
                entity.Property(p => p.Largura).IsRequired();
                entity.Property(p => p.Comprimento).IsRequired();
            });
        }
    }

    public class Pedido
    {
        public int PedidoId { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }

    public class Produto
    {
        public int ProdutoId { get; set; }
        public string ProdutoCodigo { get; set; } 

        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}

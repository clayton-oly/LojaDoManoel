using Microsoft.EntityFrameworkCore;

namespace LojaDoManoel.Service
{
    public class LojaDoManoelContext : DbContext
    {
        public LojaDoManoelContext(DbContextOptions<LojaDoManoelContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<CaixaEntity> Caixas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.PedidoId);

                entity.HasMany(e => e.Caixas)
                      .WithOne(c => c.Pedido)
                      .HasForeignKey(c => c.PedidoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CaixaEntity>(entity =>
            {
                entity.HasKey(e => e.CaixaEntityId);

                entity.Property(e => e.CaixaId)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Produtos)
                      .IsRequired();

                entity.Property(e => e.Observacao)
                      .HasMaxLength(500);
            });

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Pedido
    {
        public int PedidoId { get; set; }

        public List<CaixaEntity> Caixas { get; set; } = new List<CaixaEntity>();
    }

    public class CaixaEntity
    {
        public int CaixaEntityId { get; set; }

        public string CaixaId { get; set; } 

        public string Produtos { get; set; }  

        public string? Observacao { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}

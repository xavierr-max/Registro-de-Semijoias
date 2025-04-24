using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistroSemijoias.Models;
namespace RegistroDeSemiJoias.Data.Mappings
{
    public class SemiJoiaMap : IEntityTypeConfiguration<Semijoias>
    {
        public void Configure(EntityTypeBuilder<Semijoias> builder)
        {
            builder.ToTable("SemiJoias");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ImagemUrl)
                .HasMaxLength(250);

            builder.Property(x => x.Estoque)
                .IsRequired()
                .HasColumnType("decimal(18)");

            builder.Property(x => x.Categoria)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}


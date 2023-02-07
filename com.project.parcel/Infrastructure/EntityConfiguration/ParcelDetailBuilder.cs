using com.project.parcel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace com.project.parcel.Infrastructure.EntityConfiguration;

public sealed class ParcelDetailBuilder: IEntityTypeConfiguration<ParcelDetail>
{
    public void Configure(EntityTypeBuilder<ParcelDetail> builder)
    {
        builder.ToTable("parcel_detail");
        builder.HasKey(x => x.ParcelId);
        builder.Property(x => x.NoOfParcels)
            .HasColumnName("no_of_parcel")
            .IsRequired();
        builder.Property(x => x.Description)
            .HasColumnName("description")
            .IsRequired();
        builder.Property(x => x.Weight)
            .HasColumnName("weight")
            .IsRequired();
        builder.Property(x => x.ValueOfGoods)
            .HasColumnName("value_of_goods")
            .IsRequired();
        builder.Property(x => x.LarryNo)
            .HasColumnName("larry_no")
            .IsRequired();
        builder.Property(x => x.TINNo)
            .HasColumnName("tin_no")
            .IsRequired();
        builder.Property(x => x.RatePerKg)
            .HasColumnName("rate_per_kg")
            .IsRequired();
        builder.Property(x => x.ToPay)
            .HasColumnName("to_pay_rupee")
            .IsRequired();
        builder.Property(x => x.DuePaid)
            .HasColumnName("due_paid")
            .IsRequired();
        builder.Property(x => x.Vat)
            .HasColumnName("vat")
            .IsRequired();
        builder.Property(x => x.GrandTotal)
            .HasColumnName("grand_total")
            .IsRequired();
        builder.HasOne(x => x.SenderInformation)
            .WithOne(x => x.ParcelDetail)
            .HasForeignKey<SenderInformation>(x => x.SenderId);
        builder.HasOne(x => x.ReceiverInformation)
            .WithOne(x => x.ParcelDetail)
            .HasForeignKey<ReceiverInformation>(x => x.ReceiverId);
    }
}
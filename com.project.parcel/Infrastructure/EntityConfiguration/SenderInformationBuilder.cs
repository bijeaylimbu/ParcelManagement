using com.project.parcel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace com.project.parcel.Infrastructure.EntityConfiguration;

public sealed class SenderInformationBuilder: IEntityTypeConfiguration<SenderInformation>
{
    public void Configure(EntityTypeBuilder<SenderInformation> builder)
    {
        builder.ToTable("sender_information");
        builder.HasKey(x => x.SenderId);
        builder.Property(x => x.SenderId)
            .HasColumnName("sender_id")
            .IsRequired();
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired();
        builder.Property(x => x.PhoneNumber)
            .HasColumnName("phone_number")
            .IsRequired();
        builder.Property(x => x.Address)
            .HasColumnName("address");
    }
}
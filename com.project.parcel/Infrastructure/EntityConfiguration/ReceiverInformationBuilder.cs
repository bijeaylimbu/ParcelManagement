using com.project.parcel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace com.project.parcel.Infrastructure.EntityConfiguration;

public sealed class ReceiverInformationBuilder: IEntityTypeConfiguration<ReceiverInformation>
{
    public void Configure(EntityTypeBuilder<ReceiverInformation> builder)
    {
        builder.ToTable("receiver_information");
        builder.HasKey(x => x.ReceiverId);
        builder.Property(x => x.ReceiverId)
            .HasColumnName("receiver_id")
            .IsRequired();
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired();
        builder.Property(x => x.PhoneNumber)
            .HasColumnName("phone_number")
            .IsRequired();
    }
}
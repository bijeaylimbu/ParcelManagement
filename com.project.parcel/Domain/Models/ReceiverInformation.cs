using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.project.parcel.Domain.Models;

public sealed class ReceiverInformation
{
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public Guid ReceiverId { get; set; }
    public string Name { get; set; }
    public string? Address { get; set; }
    public string PhoneNumber { get; set; }
    public ParcelDetail ParcelDetail { get; set; }
}
using com.project.parcel.Domain.Models;
using com.project.parcel.Domain.Models.Enum;

namespace com.project.parcel.Domain.BusinessEntities;

public class AddParcelViewModel
{
    public  Guid ParcelId { get; set; }
    public int NoOfParcels { get; set; }
    public string Description { get; set; }
    public float Weight { get; set; }
    public float ValueOfGoods { get; set; }
    public int LarryNo { get; set; }
    public int TINNo { get; set; }
    public DateTime Date { get; set; }
    public int WayBillNumber { get; set; }
    public ShippingStatus ShippingStatus { get; set; }
    public float RatePerKg { get; set; }
    public float ToPay { get; set; }
    public float DuePaid { get; set; }
    public float Vat { get; set; }
    public float GrandTotal { get; set; }
    public virtual SenderInformationViewModel SenderInformation { get; set; }
    public virtual  ReceiverInformationViewModel ReceiverInformation { get; set; }
}
using com.project.parcel.Common;
using com.project.parcel.Domain.BusinessEntities;
using com.project.parcel.Domain.IRepository;
using com.project.parcel.Domain.IServices;
using com.project.parcel.Domain.Models;

namespace com.project.parcel.Services;

public class ParcelService: IParcelService
{
    private readonly IParcelRepository _parcelRepository;
    public ParcelService(IParcelRepository parcelRepository)
    {
        _parcelRepository = parcelRepository ?? throw new ArgumentNullException(nameof(parcelRepository));
    }
    public  async Task<ResponseMessage> CreateParcel(AddParcelViewModel parcelViewModel, CancellationToken cancellationToken)
    {
        return await PersistParcel(parcelViewModel, cancellationToken);
    }

    public async Task<IEnumerable<ParcelDetail>> GetAllParcel(CancellationToken cancellationToken)
    {
        var result = await _parcelRepository.GetAllParcel(cancellationToken);
        return result;
    }

    public async Task<ResponseMessage> PersistParcel(AddParcelViewModel viewModel, CancellationToken cancellationToken)
    {
        var dbParcel = _parcelRepository.AddParcel(new ParcelDetail()
        {
            Date = viewModel.Date,
            WayBillNumber = viewModel.WayBillNumber,
            ShippingStatus = viewModel.ShippingStatus,
            SenderInformation=new SenderInformation()
            {
                Name = viewModel.SenderInformation.Name,
                Address = viewModel.SenderInformation.Address,
                PhoneNumber = viewModel.SenderInformation.PhoneNumber
            },
            ReceiverInformation = new ReceiverInformation()
            {
                Name = viewModel.ReceiverInformation.Name,
                Address = viewModel.ReceiverInformation.Address,
                PhoneNumber = viewModel.ReceiverInformation.PhoneNumber
            },
            NoOfParcels = viewModel.NoOfParcels,
            Description = viewModel.Description,
            Weight = viewModel.Weight,
            ValueOfGoods = viewModel.ValueOfGoods,
            LarryNo = viewModel.LarryNo,
            TINNo = viewModel.TINNo,
            RatePerKg = viewModel.RatePerKg,
            ToPay = viewModel.ToPay,
            DuePaid = viewModel.DuePaid,
            Vat = viewModel.Vat,
            GrandTotal = viewModel.GrandTotal
        });
        var result = await _parcelRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return new ResponseMessage("Parcel Added Successfully", StatusCodes.Status200OK);
    }
}
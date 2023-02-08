using com.project.parcel.Common;
using com.project.parcel.Domain.BusinessEntities;
using com.project.parcel.Domain.Models;

namespace com.project.parcel.Domain.IServices;

public interface IParcelService
{
    Task<ResponseMessage> CreateParcel(AddParcelViewModel parcelViewModel, CancellationToken cancellationToken);

    Task<IEnumerable<ParcelDetail>> GetAllParcel(CancellationToken cancellationToken);
}
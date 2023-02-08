using com.project.parcel.Common;
using com.project.parcel.Domain.BusinessEntities;

namespace com.project.parcel.Domain.IServices;

public interface IParcelService
{
    Task<ResponseMessage> CreateParcel(AddParcelViewModel parcelViewModel, CancellationToken cancellationToken);
}
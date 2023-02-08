using com.project.parcel.BuildingBlocks.Core;
using com.project.parcel.Domain.Models;

namespace com.project.parcel.Domain.IRepository;

public interface IParcelRepository: IRepository<ParcelDetail>
{
    ParcelDetail AddParcel(ParcelDetail parcelDetail);

    Task<IEnumerable<ParcelDetail>> GetAllParcel(CancellationToken cancellationToken);
}
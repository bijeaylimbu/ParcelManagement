using com.project.parcel.Common;

namespace com.project.parcel.Domain.IRepository;

public interface IUnitOfWork: IDisposable
{
    Task<ResponseMessage> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}
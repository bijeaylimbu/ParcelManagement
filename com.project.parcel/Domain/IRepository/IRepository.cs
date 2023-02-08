
namespace com.project.parcel.Domain.IRepository;

public interface IRepository<T> where T: class
{
    IUnitOfWork UnitOfWork { get; }
}
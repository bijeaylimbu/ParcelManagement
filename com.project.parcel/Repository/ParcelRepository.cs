using com.project.parcel.Domain.IRepository;
using com.project.parcel.Domain.Models;
using com.project.parcel.Infrastructure;

namespace com.project.parcel.Repository;

public class ParcelRepository: IParcelRepository
{
    private readonly ParcelDbContext _dbContext;

    public ParcelRepository(ParcelDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public IUnitOfWork UnitOfWork => _dbContext;
    public ParcelDetail AddParcel(ParcelDetail parcelDetail)
    {
        return parcelDetail.ParcelId == default ? _dbContext.ParcelDetails.Add(parcelDetail).Entity : parcelDetail;
    }

   
}
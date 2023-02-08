using com.project.parcel.Domain.IRepository;
using com.project.parcel.Domain.Models;
using com.project.parcel.Infrastructure;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<ParcelDetail>> GetAllParcel(CancellationToken cancellationToken)
    {
        var parcel = await _dbContext.ParcelDetails.OrderByDescending(x => x.ParcelId).Include(x => x.SenderInformation)
            .Include(x => x.ReceiverInformation).AsNoTracking().ToListAsync();
        return parcel;
    }
}
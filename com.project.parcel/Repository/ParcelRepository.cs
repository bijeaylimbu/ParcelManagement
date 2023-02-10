using com.project.parcel.Domain.IRepository;
using com.project.parcel.Domain.Models;
using com.project.parcel.Infrastructure;
using Dapper;

namespace com.project.parcel.Repository;

public class ParcelRepository: IParcelRepository
{
    private readonly ParcelDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private DapperDbContext _dapperDbContext;

    public ParcelRepository(ParcelDbContext dbContext, IConfiguration configuration,DapperDbContext dapperDbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _dapperDbContext = dapperDbContext ?? throw new ArgumentNullException(nameof(dapperDbContext));
    }
    public IUnitOfWork UnitOfWork => _dbContext;
    public ParcelDetail AddParcel(ParcelDetail parcelDetail)
    {
        return parcelDetail.ParcelId == default ? _dbContext.ParcelDetails.Add(parcelDetail).Entity : parcelDetail;
    }

    public async Task<IEnumerable<ParcelDetail>> GetAllParcel(CancellationToken cancellationToken)
    {
        // var parcel = await _dbContext.ParcelDetails.OrderByDescending(x => x.ParcelId).Include(x => x.SenderInformation)
        //     .Include(x => x.ReceiverInformation).AsNoTracking().ToListAsync();
        // return parcel;

        var query = "SELECT  *" +
                    " FROM parcel_detail AS parcel " +
                    "LEFT JOIN sender_information AS sender ON parcel.parcel_id=sender.sender_id " +
                    " LEFT JOIN receiver_information AS receiver ON parcel.parcel_id=receiver.receiver_id; ";
        using (var connection =_dapperDbContext.CreateConnection())
        {
            connection.Open();
            var result = await connection.QueryAsync<ParcelDetail,SenderInformation,  ReceiverInformation,ParcelDetail>(query,
                (parcel, sender, receiver) =>
                {
                    parcel.SenderInformation = sender;
                    parcel.ReceiverInformation = receiver;
                    return parcel;
                },splitOn: "sender_id, receiver_id");
              
          
            return  result;
        }
    }
}
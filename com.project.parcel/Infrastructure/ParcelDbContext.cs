using com.project.parcel.Common;
using com.project.parcel.Domain.IRepository;
using com.project.parcel.Domain.Models;
using com.project.parcel.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace com.project.parcel.Infrastructure;

public partial class ParcelDbContext: DbContext,IUnitOfWork
{
    public ParcelDbContext()
    {
        
    }

    public ParcelDbContext(DbContextOptions<ParcelDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<ParcelDetail> ParcelDetails { get; set; }
    public DbSet<SenderInformation> SenderInformations { get; set; }
    public DbSet<ReceiverInformation> ReceiverInformations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ParcelDetailBuilder());
        modelBuilder.ApplyConfiguration(new ReceiverInformationBuilder());
        modelBuilder.ApplyConfiguration(new SenderInformationBuilder());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer()
            .UseSnakeCaseNamingConvention();
    }
    public async Task<ResponseMessage> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await base.SaveChangesAsync(cancellationToken);
            return new ResponseMessage("SUCCESSFUL", StatusCodes.Status200OK);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            return new ResponseMessage(ex.Message, StatusCodes.Status502BadGateway);
        }
    }
}
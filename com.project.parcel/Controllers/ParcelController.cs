
using com.project.parcel.Domain.BusinessEntities;
using com.project.parcel.Domain.IServices;
using Microsoft.AspNetCore.Mvc;

namespace com.project.parcel.Controllers;

public class ParcelController: Controller
{
    private readonly IParcelService _parcelService;
    public ParcelController(IParcelService parcelService)
    {
        _parcelService = parcelService ?? throw new ArgumentNullException(nameof(parcelService));
    }
    [Route("add-parcel")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddParcel(AddParcelViewModel addParcelViewModel, CancellationToken cancellationToken)
    {
        try
        {
          var result=     await _parcelService.CreateParcel(addParcelViewModel, cancellationToken);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route("parcel-list")]
    public async Task<IActionResult> GetAllParcel( CancellationToken cancellationToken)
    {
        try
        {
            var parcels=  await _parcelService.GetAllParcel( cancellationToken);
            return View("parcelList",parcels);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
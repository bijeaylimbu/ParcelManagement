
using com.project.parcel.Application.Validator;
using com.project.parcel.Domain.BusinessEntities;
using com.project.parcel.Domain.IServices;
using com.project.parcel.Domain.Models;
using FluentValidation.Results;
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
        
            ParcelValidator parcelValidator = new ParcelValidator();
            ValidationResult validationResult = await parcelValidator.ValidateAsync(addParcelViewModel, cancellationToken);
            if(!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View("index", addParcelViewModel);

            }
            else
            {
                var result=     await _parcelService.CreateParcel(addParcelViewModel, cancellationToken);
                ViewBag.SuccessMessage = result.Message;
                ModelState.Clear();
                return View("index");
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
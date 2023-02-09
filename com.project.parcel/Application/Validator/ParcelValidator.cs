using com.project.parcel.Domain.BusinessEntities;
using com.project.parcel.Domain.Models;
using FluentValidation;

namespace com.project.parcel.Application.Validator;

public class ParcelValidator: AbstractValidator<AddParcelViewModel>
{
    public ParcelValidator()
    {
        RuleFor(model => model.Date).NotNull().WithMessage("Date cannot be empty");
        RuleFor(model => model.WayBillNumber).NotNull().WithMessage("Way Bill Number cannot be empty");
        RuleFor(model => model.ShippingStatus).NotEmpty().WithMessage("Shipping Status cannot be empty");
        RuleFor(model => model.SenderInformation.Name).NotEmpty().WithMessage("Sender Name cannot be empty");
        RuleFor(model => model.SenderInformation.Address).NotEmpty().WithMessage("Sender Address cannot be empty");
        RuleFor(model => model.SenderInformation.PhoneNumber).NotEmpty().WithMessage("Sender Phone Number cannot be empty");
        RuleFor(model => model.ReceiverInformation.Name).NotEmpty().WithMessage("Receiver Name cannot be empty");
        RuleFor(model => model.ReceiverInformation.Address).NotEmpty().WithMessage("Receiver Address be empty");
        RuleFor(model => model.ReceiverInformation.PhoneNumber).NotEmpty().WithMessage("Receiver Phone Number cannot be empty");
        RuleFor(model => model.NoOfParcels).NotNull().WithMessage("No of Parcel cannot be empty");
        RuleFor(model => model.LarryNo).NotNull().WithMessage("Larry No cannot be empty");
        RuleFor(model => model.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(model => model.Weight).NotNull().WithMessage("Weight cannot be empty");
        RuleFor(model => model.ValueOfGoods).NotNull().WithMessage("Value of Goods cannot be empty");
        RuleFor(model => model.RatePerKg).NotNull().WithMessage("Rate per kg cannot be empty");
        RuleFor(model => model.ToPay).NotNull().WithMessage("To Pay cannot be empty");
        RuleFor(model => model.DuePaid).NotNull().WithMessage("Due Paid cannot be empty");
        RuleFor(model => model.Vat).NotNull().WithMessage("Vat cannot be empty");
        RuleFor(model => model.GrandTotal).NotNull().WithMessage("Grand Total cannot be empty");
    }
}
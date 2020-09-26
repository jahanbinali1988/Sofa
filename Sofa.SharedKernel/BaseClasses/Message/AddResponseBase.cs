using System;

namespace Sofa.SharedKernel.BaseClasses
{
    public class AddResponseBase : ResponseBase
    {
        public AddResponseBase(bool successful, string message, string errorMessage, Guid newRecordedId) : base(successful, message)
        {
            this.NewRecordedId = newRecordedId;
            this.Message = message;
            this.ErrorMessage = errorMessage;
            this.IsSuccess = successful;
        }

        public AddResponseBase(Guid newRecordedId) : base(true, "عملیات با موفقیت انجام شد.")
        {
            this.NewRecordedId = newRecordedId;
            this.Message = "عملیات با موفقیت انجام شد.";
            this.ErrorMessage = "";
            this.IsSuccess = true;
        }

        public AddResponseBase() : base(true, "عملیات با موفقیت انجام شد.")
        {

        }
        protected Guid NewRecordedId { get; set; }
    }
}

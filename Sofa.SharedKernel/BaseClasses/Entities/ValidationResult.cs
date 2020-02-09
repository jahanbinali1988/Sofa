namespace Sofa.SharedKernel.BaseClasses
{
    public class ValidationResult
    {
        public ValidationResult(string[] propertyNames, string validationMessage, bool isValid)
        {
            PropertyNames = propertyNames;
            ValidationMessage = validationMessage;
            IsValid = isValid;
        }

        public string[] PropertyNames { get; set; }
        public string ValidationMessage { get; set; }
        public bool IsValid { get; set; }
    }
}

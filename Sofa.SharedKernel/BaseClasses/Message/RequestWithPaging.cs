namespace Sofa.SharedKernel.BaseClasses.Message
{
    public abstract class RequestWithPaging : RequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderedBy { get; set; }
        public bool Accending { get; set; }
    }
}

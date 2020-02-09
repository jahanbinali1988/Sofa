using Microsoft.AspNetCore.StaticFiles;

namespace Sofa.Web
{
    public class JsonContentTypeProvider : FileExtensionContentTypeProvider
    {
        public JsonContentTypeProvider()
        {
            Mappings.Add(".geojson", "application/json");
        }
    }
}

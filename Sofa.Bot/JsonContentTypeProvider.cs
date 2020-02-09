using Microsoft.AspNetCore.StaticFiles;

namespace Sofa.Teacher
{
    public class JsonContentTypeProvider : FileExtensionContentTypeProvider
    {
        public JsonContentTypeProvider()
        {
            Mappings.Add(".geojson", "application/json");
        }
    }
}

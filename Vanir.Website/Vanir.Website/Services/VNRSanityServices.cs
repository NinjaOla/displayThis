using Newtonsoft.Json.Linq;
using Sanity.Linq;
using Sanity.Linq.CommonTypes;
using System.Text;

namespace Vanir.Website.Services
{
    public class VNRSanityServices
    {
        private SanityOptions _options;

        public VNRSanityServices(SanityOptions options)
        {
            _options = options;
        }
        public string GetImageUrl(SanityImage image, string noImageUrl = "/images/unknown.jpg")
        {
            var asset = image?.Asset ?? null;
            var imageRef = image?.Asset?.Ref ?? null;

            if (asset == null || imageRef == null)
            {
                return noImageUrl;
            }

            var parameters = new StringBuilder();

            //build url
            var imageParts = imageRef.Split('-');
            var url = new StringBuilder();
            url.Append("https://cdn.sanity.io/");
            url.Append(imageParts[0] + "s/");            // images/
            url.Append(_options.ProjectId + "/");             // projectid/
            url.Append(_options.Dataset + "/");             // dataset/
            url.Append(imageParts[1] + "-");             // asset id-
            url.Append(imageParts[2] + ".");             // dimensions.
            url.Append(imageParts[3]);                       // file extension

            return url.ToString();
        }

    }
}

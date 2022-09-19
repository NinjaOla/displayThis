using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Sanity.Linq.CommonTypes;

namespace Vanir.Website.Models
{
    public enum EnumerableViewMode
    {
        List, Grid
    }
    public record Team
    {

        [JsonProperty("_id")]
        public string _Id { get; set; }

        // Type field is also required
        [JsonProperty("_type")]
        public string DocumentType => "team";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public SanitySlug Slug { get; set; }

        [JsonProperty("members")]
        public List<Person> Members { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_published")]
        public bool IsPublished { get; set; }

        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty("isDisplayFooter")]
        public bool IsDisplayInFooter { get; set; }

        [JsonProperty("isDisplayFrontPage")]
        public bool IsDisplayFrontPage { get; set; }
    }

    public record Person
    {
        [JsonProperty("_id")]
        public string _Id { get; set; }

        // Type field is also required
        [JsonProperty("_type")]
        public string DocumentType => "person";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public SanitySlug Slug { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("socialMedias")]
        public List<SocialInfo> Socials { get; set; }

        [JsonProperty("bio")]
        public object[] Description { get; set; }

        [JsonProperty("image")]
        public SanityImage Image { get; set; }

        [JsonProperty("is_published")]
        public bool IsPublished { get; set; }




    }

    public record SocialInfo
    {
        [JsonProperty("someType")]
        public SocialMediaType Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public enum SocialMediaType
    {
        NONE, FACEBOOK, TWITTER, INSTAGRAM, LINKEDIN, TWITCH, YOUTUBE, MAIL
    }
    public record Article
    {
        [JsonProperty("_id")]
        public string _Id { get; set; }

        // Type field is also required
        [JsonProperty("_type")]
        public string DocumentType => "article";

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("slug")]
        public SanitySlug Slug { get; set; }//URL

        [JsonProperty("mainImage")]
        public SanityImage Image { get; set; }

        [JsonProperty("author")]
        public Person Author { get; set; }

        [JsonProperty("body")]
        public object[] Content { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("is_published")]
        public bool IsPublished { get; set; }

        [JsonProperty("videoIFrame")]
        public string IFrame { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("publishedAt")]
        public DateTimeOffset? TimeStampUTC { get; set; }

        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }


    }
    public record Sponsor
    {

        [JsonProperty("is_main")]
        public bool IsMain { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image_url")]
        public SanityImage Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("is_published")]
        public bool IsPublished { get; set; }
    }

}

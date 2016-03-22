using Maktub82.Samples.Attributes.Attributes;

namespace Maktub82.Samples.Attributes.Enums
{
    public enum Category
    {
        [DisplayName("Series")]
        [ApiValue("series")]
        [ApiValue("tv-series")]
        [ApiValue("tv-vod")]
        Series,
        [DisplayName("Films and Movies")]
        [ApiValue("movies")]
        [ApiValue("films")]
        Films,
        [DisplayName("Documentary")]
        [ApiValue("tv-documentary")]
        Documentary
    }
}

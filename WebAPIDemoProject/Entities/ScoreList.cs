using System.Text.Json.Serialization;

namespace WebAPIDemoProject.Entities
{
    public class ScoreList : BaseCRUD
    {
        public List<MarsksheetItem> Marksheet { get; set; }

        public class MarsksheetItem
        {
            [JsonConverter(typeof(JsonStringEnumConverter))]
            public Subject Subject { get; set; }
            [JsonConverter(typeof(JsonStringEnumConverter))]
            public Grade Grade { get; set; }
        }
    }
}
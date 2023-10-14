namespace WebAPIDemoProject.Entities
{
    public class ScoreList : BaseCRUD
    {
        public List<MarsksheetItem> Marksheet { get; set; }

        public class MarsksheetItem
        {
            public Subject Subject { get; set; }
            public Grade Grade { get; set; }
        }
    }
}
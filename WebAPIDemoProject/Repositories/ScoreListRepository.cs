using WebAPIDemoProject.Entities;

namespace WebAPIDemoProject.Repositories
{
    public class ScoreListRepository : CRUDRepository<ScoreList>
    {
        public ScoreListRepository() : base(nameof(ScoreList))
        {
        }
    }
}
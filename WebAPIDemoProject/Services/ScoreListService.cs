using WebAPIDemoProject.Entities;
using WebAPIDemoProject.Entities.DTO;
using WebAPIDemoProject.Repositories;
using static WebAPIDemoProject.Entities.ScoreList;

namespace WebAPIDemoProject.Services
{
    public class ScoreListService
    {
        private readonly ScoreListRepository _scoreListRepository;

        public ScoreListService(ScoreListRepository scoreListRepository)
        {
            _scoreListRepository = scoreListRepository;
        }

        public Response<ScoreList> Get(int userId)
        {
            var scoreList = _scoreListRepository.Get(userId);
            if (scoreList == null)
            {
                return new Response<ScoreList>
                {
                    StatusMessage = "User Score not found"
                };
            }

            return new Response<ScoreList>
            {
                Result = scoreList,
                StatusMessage = "Success"
            };
        }

        public Response<ScoreList> AddOrUpdate(ScoreList scoreList)
        {
            var marksheet = scoreList.Marksheet;
            var existingScoreList = _scoreListRepository.Get(scoreList.UserId);
            if (existingScoreList != null)
            {
                marksheet.AddRange(existingScoreList.Marksheet);
            }

            if (CheckIfSubjectIsRepeated(marksheet) == false)
            {
                if (existingScoreList == null)
                {
                    _scoreListRepository.Add(scoreList, false);
                }
                else
                {
                    _scoreListRepository.Update(scoreList);
                }

                return new Response<ScoreList>
                {
                    Result = scoreList,
                    StatusMessage = "Success"
                };
            }
            else
            {
                return new Response<ScoreList>
                {
                    StatusMessage = "Subject is repeated",
                };
            }
        }

        private bool CheckIfSubjectIsRepeated(List<MarsksheetItem> marksheet)
        {
            var subjectList = new List<string>();
            foreach (var marksheetItem in marksheet)
            {
                if (subjectList.Contains(marksheetItem.Subject.ToString()))
                {
                    return true;
                }
                else
                {
                    subjectList.Add(marksheetItem.Subject.ToString());
                }
            }
            return false;
        }
    }
}
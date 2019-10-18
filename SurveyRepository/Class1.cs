using System.Threading.Tasks;

using Survey.Model;

namespace Survey.Repository
{
    public interface ISurveyRepository
    {
        Task<int> Create(SurveyModel model);
        Task<SurveyModel> GetSurvey(int surveyId);
        Task<int> RecordSurvey(RecordSurveyModel model);
        Task<double> GetAverage(int surveyId);
    }
}

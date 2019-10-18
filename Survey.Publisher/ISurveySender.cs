using System.Threading.Tasks;
using Survey.Model;

namespace Survey.Publisher
{
    public interface ISurveySender
    {
        Task<int> SendSurvey(SendSurveyModel survey, int surveyRecepient);
    }
}

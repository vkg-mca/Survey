using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Survey.Model;

namespace Survey.Publisher
{
    public class SurveySender : ISurveySender
    {
        private readonly ILogger<ISurveySender> _logger;
        public SurveySender(ILogger<ISurveySender> logger)
        {
            _logger = logger;
        }
        public async Task<int> SendSurvey(SendSurveyModel survey, int surveyRecepient)
        {
            _logger.LogInformation($"Survey [SurveyId={survey.SurveyId}] sent to {surveyRecepient}");
            return 1;
        }
    }
}

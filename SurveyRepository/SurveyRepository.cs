using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Survey.Model;

namespace Survey.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly ILogger<ISurveyRepository> _logger;
        public SurveyRepository(ILogger<ISurveyRepository> logger)
        {
            _logger = logger;
        }
        public async Task<int> Create(SurveyModel model)
        {
            _logger.LogInformation($"Survey created with id={model.SurveyId}");
            await Task.CompletedTask;
            return 1;
        }

        public async Task<double> GetAverage(int surveyId)
        {
            var average = 1.5d;
            await Task.CompletedTask;
            _logger.LogInformation($"Average return as {average}");
            return average;
        }

        public async Task<SurveyModel> GetSurvey(int surveyId)
        {
            _logger.LogInformation($"Survey returned for surveyid={surveyId}");
            await Task.CompletedTask;
            return new SurveyModel();
        }

        public async Task<int?> RecordSurvey(RecordSurveyModel model)
        {
            var count = model.SurveyItems?.Count();
            _logger.LogInformation($"{count } surveys recorded for Survey surveyId={model.SurveyId}");
            await Task.CompletedTask;
            return count;
        }
    }
}

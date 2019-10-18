using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Survey.Model;
using Survey.Publisher;
using Survey.Repository;

namespace Survey.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyRepository _repository;
        private readonly ILogger<SurveyController> _logger;
        private readonly ISurveySender _sender;
        public SurveyController(ISurveyRepository repository,
                             ILogger<SurveyController> logger,
                             ISurveySender sender)
        {
            _repository = repository;
            _logger = logger;
            _sender = sender;
        }
        [HttpPost]
        public async Task<ActionResult> CreateSurvey([FromBody] SurveyModel model)
        {
            var result = await _repository
                .Create(model)
                .ConfigureAwait(false);
            _logger.LogInformation($"Survey created with Id={model.SurveyId }");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> SendSurvey(SendSurveyModel model)
        {
            var survey = await _repository.GetSurvey(model.SurveyId).ConfigureAwait(false);
            _logger.LogInformation($"Survey retrieved with Id={model.SurveyId }");
            var sentResult = _sender.SendSurvey(survey, model.SurveyRecepientId);
            _logger.LogInformation($"Survey sent with Id={model.SurveyId } to sender ={model.SurveyRecepientId}");
            return Ok(sentResult);
        }

        [HttpPost]
        public async Task<ActionResult> RecorddSurvey(RecordSurveyModel model)
        {
            var result = await _repository.RecordSurvey(model).ConfigureAwait(false);
            _logger.LogInformation($"Survey recorded with Id={model.SurveyId }");

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> AnalyseSurvey(int SurveyId)
        {
            var avg = await _repository.GetAverage(SurveyId).ConfigureAwait(false);
            _logger.LogInformation($"Survey with Id={SurveyId} has a result of {avg}");

            return Ok(avg);
        }
    }
}

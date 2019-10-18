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
        [Route("CreateSurvey")]
        public async Task<ActionResult> CreateSurvey([FromBody] SurveyModel survey)
        {
            var result = await _repository
                .Create(survey)
                .ConfigureAwait(false);
            _logger.LogInformation($"Survey created with Id={survey.SurveyId }");
            return Ok(result);
        }

        [HttpPost]
        [Route("SendSurvey")]
        public async Task<ActionResult> SendSurvey([FromBody] SendSurveyModel model)
        {
            var survey = await _repository.GetSurvey(model.SurveyId).ConfigureAwait(false);
            _logger.LogInformation($"Survey retrieved with Id={survey.SurveyId }");
            var sentResult = await _sender.SendSurvey(model, model.SurveyRecepientId);
            _logger.LogInformation($"Survey sent with Id={survey.SurveyId } to sender ={model.SurveyRecepientId}");
            return Ok(sentResult);
        }

        [HttpPost]
        [Route("RecordSurvey")]
        public async Task<ActionResult> RecorddSurvey([FromBody] RecordSurveyModel survey)
        {
            var result = await _repository.RecordSurvey(survey).ConfigureAwait(false);
            _logger.LogInformation($"Survey recorded with Id={survey.SurveyId }");

            return Ok(result);
        }

        [HttpGet]
        [Route("AnalyseSurvey/{SurveyId}")]
        public async Task<ActionResult> AnalyseSurvey(int SurveyId)
        {
            var avg = await _repository.GetAverage(SurveyId).ConfigureAwait(false);
            _logger.LogInformation($"Survey with Id={SurveyId} has a result of {avg}");

            return Ok(avg);
        }
    }
}

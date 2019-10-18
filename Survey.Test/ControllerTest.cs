using System.Threading.Tasks;

using AutoFixture.Xunit2;

using Microsoft.Extensions.Logging;

using Moq;

using Survey.Api.Controllers;
using Survey.Model;
using Survey.Publisher;
using Survey.Repository;

using Xunit;
using Xunit.Abstractions;

namespace Survey.Test
{
    public class ControllerTest
    {
        private ITestOutputHelper _output;
        public ControllerTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Trait("Category", "Unit")]
        [Theory, AutoData]

        public async Task TestGetSurvey(int surveyId, SurveyModel survey)
        {
            var mockSender = new Mock<ISurveySender>(MockBehavior.Loose );
            var mockLogger = new Mock<ILogger<SurveyController>>(MockBehavior.Loose);

            var mockRepo = new Mock<ISurveyRepository>(MockBehavior.Loose);
            mockRepo.Setup(repo => repo.GetSurvey(surveyId));

            var controller = new SurveyController(mockRepo.Object, mockLogger.Object, mockSender.Object);
            var actual = await controller.CreateSurvey(survey).ConfigureAwait(false);
            Assert.NotNull(actual);


        }
    }
}

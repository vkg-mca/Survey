using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
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
        public async Task TestCreateSurvey(int surveyId, SurveyModel survey)
        {
            var mockSender = new Mock<ISurveySender>(MockBehavior.Loose);
            var mockLogger = new Mock<ILogger<SurveyController>>(MockBehavior.Loose);
            var mockRepo = new Mock<ISurveyRepository>(MockBehavior.Loose);

            var controller = new SurveyController(mockRepo.Object, mockLogger.Object, mockSender.Object);
            var actual = await controller.CreateSurvey(survey).ConfigureAwait(false);
            Assert.NotNull(actual);

        }

        [Trait("Category", "Unit")]
        [Theory, AutoData]
        public async Task TestSendSurvey(int surveyId, SendSurveyModel survey)
        {
            var mockSender = new Mock<ISurveySender>(MockBehavior.Default);
            var mockLogger = new Mock<ILogger<SurveyController>>(MockBehavior.Default);
            var mockRepo = new Mock<ISurveyRepository>(MockBehavior.Default);
            mockRepo.Setup(repo => repo.GetSurvey(surveyId));


            //var fixture = new Fixture().Customize(new AutoMoqCustomization());
            //var fistresurvey = fixture.Freeze<Mock<SurveyModel>>();
            //fistresurvey.SetReturnsDefault(fixture.Create<SurveyModel>());


            var controller = new SurveyController(mockRepo.Object, mockLogger.Object, mockSender.Object);
            var actual = await controller.SendSurvey(survey).ConfigureAwait(false);
            Assert.NotNull(actual);

        }

        [Trait("Category", "Unit")]
        [Theory, AutoData]
        public async Task TestRecordSurvey(RecordSurveyModel survey)
        {
            var mockSender = new Mock<ISurveySender>(MockBehavior.Loose);
            var mockLogger = new Mock<ILogger<SurveyController>>(MockBehavior.Loose);
            var mockRepo = new Mock<ISurveyRepository>(MockBehavior.Loose);

            var controller = new SurveyController(mockRepo.Object, mockLogger.Object, mockSender.Object);
            var actual = await controller.RecorddSurvey(survey).ConfigureAwait(false);
            Assert.NotNull(actual);

        }
    }
}

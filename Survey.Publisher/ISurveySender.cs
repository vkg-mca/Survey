namespace Survey.Publisher
{
    public interface ISurveySender
    {
        object SendSurvey(object survey, object surveyRecepient);
    }
}

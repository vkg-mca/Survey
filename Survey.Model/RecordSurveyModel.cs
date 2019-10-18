using System.Collections.Generic;

namespace Survey.Model
{
    public class RecordSurveyModel
    {
        public int SurveyId { get; set; }
        public IEnumerable<SurveyItem> SurveyItems { get; set; }
    }
}

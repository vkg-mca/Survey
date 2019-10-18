using System;
using System.Collections.Generic;

namespace Survey.Model
{
    public class SurveyModel
    {
        public int SurveyId { get; set; }
        public string SurveyTopic { get; set; }
        public DateTime SurveyExpiration { get; set; }
        public IEnumerable<SurveyItem> SurveyItem { get; set; }
    }
}

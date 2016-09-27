using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Infermedica_Models
{

    public class Choice
    {
        public string id { get; set; }
        public string label { get; set; }
    }

    public class QuestionItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Choice> choices { get; set; }
    }

    public class Question
    {
        public string type { get; set; }
        public string text { get; set; }
        public List<QuestionItem> items { get; set; }
    }

    public class Condition
    {
        public string id { get; set; }
        public string name { get; set; }
        public double probability { get; set; }
    }

    public class DiagnosisResponse
    {
        public Question question { get; set; }
        public List<Condition> conditions { get; set; }
        public Extras extras { get; set; }
    }
}

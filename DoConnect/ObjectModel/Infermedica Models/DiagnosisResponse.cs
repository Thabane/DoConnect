using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Infermedica_Models
{
    public enum Type
    {
        single,
        group_single,
        group_multiple
    }
    public enum ID
    {
        present,
        absent,
        unknown
    }
    public class DiagnosisResponse
    {
        public Question question { get; set; }
        public List<ConditionProbability> connditions { get; set; }
        public object extras { get; set; }
    }

    public class Question
    {
        public Type type { get; set; }
        public string text { get; set; }
        //public string Items { get; set; }
        public object extras { get; set; } //additional content, like images or HTML
   }
    public class ConditionProbability
    {
        public string id { get; set; } // condition id 
        public string name { get; set; } //condition name 
        public int probability { get; set; }
    }

    public class QuestionItem
    {
        public string id { get; set; } //observation id 
        public string name { get; set; } //name or alias of observation 
        public List<Choice> choices { get; set; } //list of available answer choices
    }

    public class Choice
    {
        public ID id { get; set; }
        public string label { get; set; }
    }
}

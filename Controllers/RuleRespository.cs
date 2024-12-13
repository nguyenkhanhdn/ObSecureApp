using Newtonsoft.Json;
using Tensorflow;

namespace ObSecureApp.Controllers
{
    public class RuleRepository
    {
        //private readonly string _filePath = "rules.json";

        private string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json", "rules_1.json");

        public List<RuleModel> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<RuleModel>();
            }

            var jsonData = File.ReadAllText(_filePath);

           // var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<RuleModel>>(jsonData) ?? new List<RuleModel>();
        } 

        public RuleModel GetById(int id)
        {
            var rules = GetAll();
            return rules.FirstOrDefault(r => r.Id == id);
        }

        public void Create(RuleModel rule)
        {
            var rules = GetAll();
            rule.Id = rules.Any() ? rules.Max(r => r.Id) + 1 : 1;
            rules.Add(rule);
            SaveToFile(rules);
        }

        public void Update(RuleModel updatedRule)
        {
            var rules = GetAll();
            var rule = rules.FirstOrDefault(r => r.Id == updatedRule.Id);
            if (rule != null)
            {
                rules.Remove(rule);
                rules.Add(updatedRule);
                SaveToFile(rules);
            }
        }

        public void Delete(int id)
        {
            var rules = GetAll();
            var rule = rules.FirstOrDefault(r => r.Id == id);
            if (rule != null)
            {
                rules.Remove(rule);
                SaveToFile(rules);
            }
        }

        private void SaveToFile(List<RuleModel> rules)
        {
            var jsonData = System.Text.Json.JsonSerializer.Serialize(rules);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}

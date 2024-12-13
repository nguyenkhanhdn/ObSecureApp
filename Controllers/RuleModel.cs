namespace ObSecureApp.Controllers
{
    public class RuleModel
    {
        public int id { get; set; }
        public int priority { get; set; }
        public action action { get; set; }
        public condition condition { get; set; }
    }
}

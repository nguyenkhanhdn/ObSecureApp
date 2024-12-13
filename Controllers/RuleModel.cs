namespace ObSecureApp.Controllers
{
    public class RuleModel
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public Action Action { get; set; }
        public Condition Condition { get; set; }
    }
}

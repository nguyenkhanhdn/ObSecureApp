namespace ObSecureApp.Controllers
{
    public class Action
    {
        public  string Type { get; set; }
        public Action(string type)
        {
            this.Type = type;
        }
    }
}

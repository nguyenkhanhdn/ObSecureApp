namespace ObSecureApp.Controllers
{
    public class Condition
    {
        public  string urlFilter { get; set; }
        public  List<string> resourceTypes { get; set; }

        public Condition() {
        
            this.resourceTypes = new List<string>();
            this.urlFilter = string.Empty;
        }

    }
}

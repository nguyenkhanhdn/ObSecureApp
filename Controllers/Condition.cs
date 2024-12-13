namespace ObSecureApp.Controllers
{
    public class condition
    {
        public  string urlFilter { get; set; }
        public  List<string> resourceTypes { get; set; }

        public condition() {
        
            this.resourceTypes = new List<string>();
            this.urlFilter = string.Empty;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using ObSecureApp.Models;
using System.Diagnostics;
using System.IO;

namespace ObSecureApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Predict()
        {

            ////Load sample data
            //var sampleData = new ObSecureMLModel.ModelInput()
            //{
            //    Comment = @"The other two films Hitch and Magnolia are also directly related to the community in question, and may be of interest to those who see those films.  So why not link to them?",
            //};

            ////Load model and predict output
            //var result = ObSecureMLModel.Predict(sampleData);
            //ViewBag.Result = result.PredictedLabel.ToString() + result.Label + result.Score.ToString();
            return View();
        }
        [HttpPost]
        public IActionResult Predict(string id)
        {

            //Load sample data
            var sampleData = new ObSecureMLModel.ModelInput()
            {
                Comment = @"The other two films Hitch and Magnolia are also directly related to the community in question, and may be of interest to those who see those films.  So why not link to them?",
            };

            //Load model and predict output
            var result = ObSecureMLModel.Predict(sampleData);
            ViewBag.Result = result.PredictedLabel.ToString() + result.Label + result.Score.ToString();
            return View();
        }
        [HttpGet]
        public IActionResult Predict2()
        {

            ////Load sample data
            //var sampleData = new ObSecureMLModel.ModelInput()
            //{
            //    Comment = @"The other two films Hitch and Magnolia are also directly related to the community in question, and may be of interest to those who see those films.  So why not link to them?",
            //};

            ////Load model and predict output
            //var result = ObSecureMLModel.Predict(sampleData);
            //ViewBag.Result = result.PredictedLabel.ToString() + result.Label + result.Score.ToString();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Predict2(IFormFile fileUpload)
        {
            if (ModelState.IsValid)
            {
                if (fileUpload != null && fileUpload.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileUpload.FileName);
                    //Using Buffering
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        // The file is saved in a buffer before being processed
                        await fileUpload.CopyToAsync(stream);
                    }

                    //Using Streaming
                    //using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    //{
                    //    await SingleFile.CopyToAsync(stream);
                    //}
                    // Process the file here (e.g., save to the database, storage, etc.)

                    

                    // Create single instance of sample data from first line of dataset for model input
                    var imageBytes = System.IO.File.ReadAllBytes(filePath);
                    ObSecureMLModel2.ModelInput sampleData = new ObSecureMLModel2.ModelInput()
                    {
                        ImageSource = imageBytes,
                    };

                    // Make a single prediction on the sample data and print results.
                    var sortedScoresWithLabel = ObSecureMLModel2.Predict(sampleData);
                    ViewBag.Result = sortedScoresWithLabel.PredictedLabel.ToString() + sortedScoresWithLabel.Label + sortedScoresWithLabel.Score.ToString();
                    return View();
                }
            }
            return View();
        }

        public IActionResult About()
        {
            return View();

        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Features()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

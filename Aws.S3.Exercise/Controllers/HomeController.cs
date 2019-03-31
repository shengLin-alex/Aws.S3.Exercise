using Amazon.S3;
using Aws.S3.Exercise.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Aws.S3.Exercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAmazonS3 AmazonS3;

        public HomeController(IAmazonS3 amazonS3)
        {
            this.AmazonS3 = amazonS3;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> GetBucketsList()
        {
            var res = await this.AmazonS3.ListBucketsAsync();
            var bucketNames = new {bucketsNames = res.Buckets.Select(b => b.BucketName)};
            
            return this.Json(bucketNames);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
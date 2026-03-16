using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab4.Pages
{
    public class IndexModel : PageModel
    {
        private string imagesDir;
        IWebHostEnvironment environment;

        public List<string> Images { get; set; }
        public IndexModel(IWebHostEnvironment environment)
        {
            imagesDir = Path.Combine(environment.WebRootPath, "images");
        }
        public void OnGet()
        {
            UpdateFileList();
        }
        private void UpdateFileList()
        {
            Images = new List<string>();
            foreach (var item in Directory.EnumerateFiles(imagesDir).ToList())
            {
                Images.Add(Path.GetFileName(item));
            }
        }
    }
}

using ImageMagick;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab4.Pages
{
    public class UploadModel : PageModel
    {
        [BindProperty]
        public IFormFile Upload { get; set; }
        private string imagesDir;

        public UploadModel(IWebHostEnvironment environment)
        {
            imagesDir = Path.Combine(environment.WebRootPath, "images");
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (Upload != null)
            {
                if(Upload.Length > 1 * 1024 * 1024)
                {
                    ModelState.AddModelError("Upload", "File size must be less than 1 MB.");
                    return Page();
                }
                string extension = Path.GetExtension(Upload.FileName).ToLower();
                var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + extension;
                var path = Path.Combine(imagesDir, fileName); 

                var watermarkPath = Path.Combine(imagesDir, "download.png");

                using var image = new MagickImage(Upload.OpenReadStream());

                using var watermark = new MagickImage(watermarkPath);
                watermark.HasAlpha = true;

                watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 4);

                image.Composite(watermark, Gravity.Southeast, CompositeOperator.Over);

                image.Write(path);
            }

            return RedirectToPage("Index");
        }
    }
}

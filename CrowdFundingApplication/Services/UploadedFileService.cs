namespace CrowdFundingApplication.Services;

public class UploadedFileService
{
    public static string UploadedFile(IFormFile image, IWebHostEnvironment _webHostEnvironment, string nameFolder)//Create a uniq Id for each image 
    {
        string uniqueFileName = null;

        if (image != null)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, nameFolder);
            uniqueFileName = Guid.NewGuid().ToString() + ".jpg";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
        }
        return uniqueFileName;
    }
}

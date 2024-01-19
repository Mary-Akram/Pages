using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

public static class Images
{
    private static IWebHostEnvironment _webHostEnvironment;

    public static void Initialize(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public static async Task<bool> DeleteImage(string filePath)
    {
        try
        {
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}


using System;
using Microsoft.AspNetCore.Http;

namespace Service.Helpers
{
	public static class FileHelper
	{
        public static bool CheckFileType(this IFormFile file, string pattern)
        {
            return file.ContentType.Contains(pattern);
        }

        public static string GenerateFileName(this IFormFile file)
        {
            return Guid.NewGuid().ToString() + "_" + file.FileName;
        }

        public static void DeleteFileFromPath(string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }

        public static string GetFilePath(string env, string folder, string fileName)
        {
            return Path.Combine(env, folder, fileName);
        }

        public static async Task CreateLocalFileAsync(this IFormFile file, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
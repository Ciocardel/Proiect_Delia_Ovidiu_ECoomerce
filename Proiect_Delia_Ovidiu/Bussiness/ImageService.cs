namespace Proiect_Delia_Ovidiu.Bussiness
{
    public class ImageService
    {
        private readonly IWebHostEnvironment _hostingEnv;
        public ImageService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnv = hostingEnvironment;
        }

        public async Task<string> SaveImage(Stream stream, string extension)
        {
            string imageName = Guid.NewGuid().ToString();
            using var fileStream = File.Create(Path.Combine(_hostingEnv.WebRootPath, "images", $"{imageName}{extension}"));
            fileStream.Position = 0;
            await stream.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            fileStream.Close();
            return $"{imageName}{extension}";
        }

    }
}

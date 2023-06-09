using SignInTechnologys.Common.Helpers;
using SignInTechnologys.Interfaces.Common;

namespace SignInTechnologys.Services.Common
{
	public class FileService : IFileService
	{
		private readonly string _rootPath;
		private readonly string _images = "media/avatars";
		public FileService(IWebHostEnvironment webHostEnvironment)
		{
			this._rootPath = webHostEnvironment.WebRootPath;
		}
		
		public Task<bool> DeleteImageAsync(string imagePath)
		{
			string filePath = Path.Combine(this._rootPath, imagePath);
			if(!File.Exists(filePath)) 
				return Task.FromResult(false);
			
			try
			{
				File.Delete(filePath);
				return Task.FromResult(true);
			}
			catch (Exception)
			{
				return Task.FromResult(false);
			}
		}

		public async Task<string> SaveImageAsync(IFormFile image)
		{
			string imageName = ImageHelper.UniqueName(image.Name);
			string imagePath = Path.Combine(this._rootPath, _images, imageName);
			var stream = new FileStream(imagePath, FileMode.Create);
			try
			{
				await image.CopyToAsync(stream);
				return Path.Combine(_images, imageName);
			}
			catch 
			{
				return "";
			}

			finally { stream.Close(); }
		}
	}
}

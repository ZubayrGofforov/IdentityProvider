namespace SignInTechnologys.Interfaces.Common
{
    public interface IFileService
    {
        public Task<string> SaveImageAsync(IFormFile image);
		
        public Task<bool> DeleteImageAsync(string imagePath);
	}
}

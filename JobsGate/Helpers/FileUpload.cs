namespace JobsGate.Helpers
{
    public class FileUpload
    {
        public string UploadUserImage(IFormFile Image, string inst_Image = "img/users/user.webp")
        {

            if (Image != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

                var imagePath = Path.Combine("wwwroot", "img", "users", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    Image.CopyToAsync(stream);
                }
                return "img/users/" + fileName;
            }
            return inst_Image;
        }

        public string UploadCV(IFormFile file)
        {

            if (file != null)
            {
                /*var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);*/
                var fileName = file.FileName;
                var filePath = Path.Combine("wwwroot", "files", "cvs", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
                return "/files/cvs/" + fileName;
            }
            return null;
        }
    }
}

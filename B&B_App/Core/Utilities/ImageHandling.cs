using Microsoft.AspNetCore.Components.Forms;
using B_B_ClassLibrary.Models;
using B_B_ClassLibrary.BusinessModels;

namespace B_B_App.Core.Utilities
{
    public class ImageHandling
    {
        /// <summary>
        /// User need to select an image from file selection dialog for this to work 
        /// 
        /// dialog anwser in not needed but just a way for user to define the upload..
        /// 
        /// Used to generate the table in the UploadPictures page.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="dialogAnwser"></param>
        /// <returns></returns>
        public static async Task<Picture> GetImageFile(IBrowserFile file, int typeId) 
        {
            Picture imageFile = new Picture();

            imageFile.TypeId = typeId;
            imageFile = await GenerateImageString(file, imageFile);

            return imageFile;
        }

        /// <summary>
        /// User have to select an image for this method to work aka IBrowserFile
        /// 
        /// Dialog anwser is used if user wants to change Image Name, Size and Type
        /// 
        /// 
        /// This method is used in ImageHandler GetImage to get the image as base64 and the file size in bytes 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="anwser"></param>
        /// <param name="imageFile"></param>
        /// <returns></returns>
        private static async Task<Picture> GenerateImageString(IBrowserFile file,  Picture imageFile) 
        {
            IBrowserFile resizedFile;
            resizedFile = await file.RequestImageFileAsync(file.ContentType, 250, 400); // resize the image file
            
            var buf = new byte[resizedFile.Size]; // allocate a buffer to fill with the file's data
            using (var stream = resizedFile.OpenReadStream())
            {
                await stream.ReadAsync(buf); // copy the stream to the buffer
            }

            imageFile.Base64 = "data:image/png;base64," + Convert.ToBase64String(buf); // convert to a base64 string!!
            
            return imageFile;
        }
    }
}

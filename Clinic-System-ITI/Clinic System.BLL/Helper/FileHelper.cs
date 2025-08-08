using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_System.BLL.Helper
{
    public static class FileHelper
    {
        public static string UploadFile(string folderName, IFormFile? file)
        {
            if (file is null) return null;
            try
            {
                //catch the folder Path and the file name in server
                // 1 ) Get Directory
                string folderPath = Directory.GetCurrentDirectory() + "/wwwroot/imges/" + folderName;


                //2) Get File Name
                string fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
                //Guid => Word contain from 36 character

                // 3) Merge Path with File Name
                string finalPath = Path.Combine(folderPath, fileName);
                //combine put /

                //4) Save File As Streams "Data Overtime"
                using (var Stream = new FileStream(finalPath, FileMode.Create))
                {
                    file.CopyTo(Stream);
                }

                return fileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static string DeleteFile(string folderName, string? fileName)
        {
            if (fileName is not null) return "No file match file name";
            try
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imges", folderName, fileName);

                if (File.Exists(directory))
                {
                    File.Delete(directory);
                    return "File Deleted";
                }

                return "File Not Deleted";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

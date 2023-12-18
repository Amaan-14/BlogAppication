using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using static System.Net.WebRequestMethods;

namespace BlogApplication.Models
{
    public class SaveImage
    {
        private static SaveImage obj { get; set; }
        private SaveImage()
        {

        }

        public static SaveImage CreateObject()
        {
            if(obj == null)
            {
                 obj = new SaveImage();
            }

            return obj;
        }

        //Save : Saving File into Image Folder
        public string Save(HttpPostedFileBase Photo)
        {
            //Getting FileName
            string fileName = Path.GetFileName(Photo.FileName);

            //Setting Newname using datetime because may some photo has same name 
            string NewFileName = DateTime.Now.Ticks.ToString() + fileName;

            //setting the path where we want to save image
            fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), NewFileName);

            //save image
            Photo.SaveAs(fileName);

            //return New Filename For save into database
            return NewFileName;

        }

        //Delete Photo from image folder
        public void Delete(string path)
        {
            //setting filename and set path;
            string fileName = "~/Images/" + Path.GetFileName(path);

            //getting imagefile in Existing_photo
            string Existing_Photo = HttpContext.Current.Request.MapPath(fileName);

            if (System.IO.File.Exists(Existing_Photo))
            {
                System.IO.File.Delete(Existing_Photo);
            }


        }
    }
}
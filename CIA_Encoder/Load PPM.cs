using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CIA_Encoder
{
    class Load_PPM
    {
        public Bitmap LoadPPM(string filename, int imgWidth, int imgLength)
        {
            StreamReader Inputfile = new StreamReader(filename);
            bool commentsEnd = false;
            Inputfile.ReadLine();
            //pass over all the comments
            while (commentsEnd == false)
            {
                string comment = Inputfile.ReadLine();
                if (!comment.Contains("#"))
                {
                    commentsEnd = true;
                }
            }
            Inputfile.ReadLine();
            
            //generate new bitmap after gathering all essintal info
            Bitmap P3IMG = new Bitmap(imgWidth, imgLength);
            
            //loop through the x and y by grabbing three lines of RGB values for each pixel
            for (int totalY = 0; totalY < imgLength; totalY++)
            {
                for (int totalX = 0; totalX < imgWidth; totalX++)
                {
                    //parse and read each of the color values
                    int redVal = int.Parse(Inputfile.ReadLine());
                    int grnVal = int.Parse(Inputfile.ReadLine());
                    int bluVal = int.Parse(Inputfile.ReadLine());
                    Color colCurrent = Color.FromArgb(redVal, grnVal, bluVal);
                    //add the pixels that are appropriate for beung used to encode


                    P3IMG.SetPixel(totalX, totalY, colCurrent);
                    
                }
            }
            //set P3IMG to the user selected picture box
            Inputfile.Close();
            return P3IMG;
            
        }
    }
}

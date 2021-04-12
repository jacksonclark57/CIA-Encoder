using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
namespace CIA_Encoder
{
    class Load_P6
    {
        public Bitmap LoadPPM(string filename,int imgWidth ,int imgLength,List<string>CommentCount)
        {
            FileStream Inputfile = new FileStream(filename,FileMode.Open);
            char curByte = ' ';
           
            // goes through the header 
            for (int index = 0; index < 3 + CommentCount.Count; index++)
            {
                curByte = (char)Inputfile.ReadByte();

                while (curByte != '\n')
                {
                    curByte = (char)Inputfile.ReadByte();
                }
            }
            

            Bitmap P6IMG = new Bitmap(imgWidth, imgLength);
            
            //loop through the x and y by grabbing three lines of RGB values for each pixel
            for (int totalY = 0; totalY < imgLength; totalY++)
            {
                for (int totalX = 0; totalX < imgWidth; totalX++)
                {
                    //Read each byte and add to te colcurrent
                    int redVal = Inputfile.ReadByte();
                    int grnVal = Inputfile.ReadByte();
                    int bluVal = Inputfile.ReadByte();
                    Color colCurrent = Color.FromArgb(redVal, grnVal, bluVal);
                   
                    P6IMG.SetPixel(totalX, totalY, colCurrent);
                    //progressBar1.Value++;
                }
            }
            //set P3IMG to the user selected picture box
            Inputfile.Close();
            return P6IMG;
            
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace CIA_Encoder
{
    public partial class Form1 : Form
    {
        //declare global dictionary
        Dictionary<int, string> _EncodeDictionary = new Dictionary<int, string>();
        List<string> _commentStrings = new List<string>();
        string fileFormat = "";
        int imgLength = 0;
        int imgWidth = 0;
        string maxPixel = "";

        public Form1()
        {
            InitializeComponent();
            progressBar2.Visible = false;
        }
        public void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encodedStatus.Text = "";
            progressBar2.Value = 0;
            EncodedIMG.Image = null;
            saveBTN.Enabled = false;
            _commentStrings.Clear();
            Load_PPM LoadP3 = new Load_PPM();
            Load_P6 LoadP6 = new Load_P6();
            
            //open the menu then open a file
            DialogResult dgrTemp = OpenFile.ShowDialog();

            if (dgrTemp == DialogResult.OK)
            {
                txtHiddenMessage.Text = null;
                //Gets header data and stores to global variables
                StreamReader Inputfile = new StreamReader(OpenFile.FileName);
                bool commentsEnd = false;
                fileFormat = Inputfile.ReadLine();
                int count = 0;
                string LW = "";
                string currentNum = "";
                //grab all the comments and add them to the global list of comments
                while (commentsEnd == false)
                {
                    //add the current line
                    _commentStrings.Add(Inputfile.ReadLine());
                    if (!_commentStrings[count].Contains("#"))
                    {
                        commentsEnd = true;
                        LW = _commentStrings[count];
                        //remove the length and width
                        _commentStrings.RemoveAt(count);
                    }
                    count++;
                }
                char[] length_width = LW.ToCharArray();
                maxPixel = Inputfile.ReadLine();

                //Loop through char array
                for (int index = 0; index < length_width.Length; index++)
                {
                    //if the char array reaches a space it assigns the current number to img width
                    if (length_width[index] == ' ')
                    {
                        imgWidth = int.Parse(currentNum);
                        currentNum = "";
                    }
                    //if the number is parseable it adds it to current number
                    else if (int.Parse(length_width[index].ToString()) >= 0 && int.Parse(length_width[index].ToString()) <= 9)
                    {
                        currentNum += length_width[index];
                    }
                    if (int.TryParse(currentNum, out _) && imgWidth != 0)
                    {
                        imgLength = int.Parse(currentNum);
                    }
                }
                Inputfile.Close();


                if (fileFormat == "P3")
                {
                    UserIMG.Image = LoadP3.LoadPPM(OpenFile.FileName, imgWidth, imgLength);
                } 
                if (fileFormat == "P6")
                {
                    UserIMG.Image = LoadP6.LoadPPM(OpenFile.FileName, imgWidth, imgLength,_commentStrings);
                }
                int maxChar = UserIMG.Image.Width * UserIMG.Image.Width;
                if (maxChar < 255)  txtHiddenMessage.MaxLength = maxChar; 
                else txtHiddenMessage.MaxLength = 255;
               
            }
            EncodeBTN.Enabled = true;
            
        }

        
        public Bitmap prepareIMG()
        {
            progressBar2.Visible = true;
            progressBar2.Maximum = UserIMG.Image.Height * UserIMG.Image.Width;
            progressBar2.Value = 0;
            Bitmap userImage = new Bitmap(UserIMG.Image);
            Color curPix = new Color();
            //Loop through the user chosen picture to evaluate  and alter the pixels
            for (int totalY = 0; totalY < UserIMG.Image.Height; totalY++)
            {
                for (int totalX = 0; totalX < UserIMG.Image.Width; totalX++)
                {
                    //Grab the current pixelfrom the x and y in the bitmap
                    curPix = userImage.GetPixel(totalX, totalY);
                    
                    if (curPix.B == 32)
                    {
                        //moves pixel data for the aski space value
                        curPix = Color.FromArgb(curPix.R, curPix.G, 31);
                        userImage.SetPixel(totalX, totalY, curPix);
                    }
                    if (curPix.B >= 48 && curPix.B <= 58)
                    {
                        //moves pixel data for  aski numbers 1-9 value
                        curPix = Color.FromArgb(curPix.R, curPix.G, 59);
                        userImage.SetPixel(totalX, totalY, curPix);
                    }
                    //move all aski values for A-Z 
                    if (curPix.B >= 97 && curPix.B <= 110)
                    {
                        //A - M moves the blue value lower
                        curPix = Color.FromArgb(curPix.R, curPix.G, 96);
                        userImage.SetPixel(totalX, totalY, curPix);
                    }
                    if (curPix.B >= 111 && curPix.B <= 122)
                    {
                        //N - Z moves the blue value over
                        curPix = Color.FromArgb(curPix.R, curPix.G, 123);
                        userImage.SetPixel(totalX, totalY, curPix);
                    }

                    progressBar2.Value++;
                }
            }

            EncodedIMG.Image = userImage;
            encodedStatus.Text = "Image Encoded";
            progressBar2.Visible = false;
            //return the prepared bitmap
            return userImage;
            
        }

        public Bitmap encodeIMG(Bitmap encodedImg, Dictionary<int, string> askivals)
        {
            string message = txtHiddenMessage.Text.ToLower();
            Color curPix = new Color();
            int startx = 0;
            int starty = 0;
            //Loop through char array , evaluate letter and assign value to a pixel
            for (int index = 0; index < message.Length; index++)
            {
                //change the letter to asci value
                int blue = message[index];
                //evaluate if aski values coorilate with the message
                if (askivals.ContainsKey(message[index]))
                {
                    //grab the pixel
                    curPix = encodedImg.GetPixel(startx,starty);
                    //set the blue value to the asci value from the messages index
                    curPix = Color.FromArgb(curPix.R, curPix.G, blue);

                    encodedImg.SetPixel(startx, starty, curPix);
                    //once the current pixel hits the width limiter it moves down a row
                    if (startx == imgWidth - 1) { starty++; startx = 0; }
                    else { startx++; }
                }
            }
            saveBTN.Enabled = true;
            return encodedImg;
        }

        public Dictionary<int, string> buildDic()
        {
            Dictionary<int, string> EncodeDictionary = new Dictionary<int, string>();

             EncodeDictionary.Add(97, "a"); EncodeDictionary.Add(110, "n"); EncodeDictionary.Add(32, " ");
             EncodeDictionary.Add(98, "b"); EncodeDictionary.Add(111, "o"); EncodeDictionary.Add(48, "0");
             EncodeDictionary.Add(99, "c"); EncodeDictionary.Add(112, "p"); EncodeDictionary.Add(49, "1");
            EncodeDictionary.Add(100, "d"); EncodeDictionary.Add(113, "q"); EncodeDictionary.Add(50, "2");
            EncodeDictionary.Add(101, "e"); EncodeDictionary.Add(114, "r"); EncodeDictionary.Add(51, "3");
            EncodeDictionary.Add(102, "f"); EncodeDictionary.Add(115, "s"); EncodeDictionary.Add(52, "4");
            EncodeDictionary.Add(103, "g"); EncodeDictionary.Add(116, "t"); EncodeDictionary.Add(53, "5");
            EncodeDictionary.Add(104, "h"); EncodeDictionary.Add(117, "u"); EncodeDictionary.Add(54, "6");
            EncodeDictionary.Add(105, "i"); EncodeDictionary.Add(118, "v"); EncodeDictionary.Add(55, "7");
            EncodeDictionary.Add(106, "j"); EncodeDictionary.Add(119, "w"); EncodeDictionary.Add(56, "8");
            EncodeDictionary.Add(107, "k"); EncodeDictionary.Add(120, "x"); EncodeDictionary.Add(57, "9");
            EncodeDictionary.Add(108, "l"); EncodeDictionary.Add(121, "y");
            EncodeDictionary.Add(109, "m"); EncodeDictionary.Add(122, "z");
            return EncodeDictionary;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK && EncodedIMG.Image != null)
            {
                 //call the Save PPM
                 saveImagePPM(saveFile.FileName);
            }
        }

        public void saveImagePPM(string Filepath)
        {
            
            StreamWriter outFile = new StreamWriter(Filepath);
            Bitmap finalIMG = new Bitmap(EncodedIMG.Image);
            Color curpix = new Color();
            //write the File format
            outFile.WriteLine(fileFormat);
            //Write out all the stored comments
            for (int index = 0; index < _commentStrings.Count; index++)
            {
                outFile.WriteLine(_commentStrings[index]);
            }
            //Write out the length and width
            outFile.WriteLine("{0} {1}", imgWidth, imgLength);
            outFile.WriteLine(maxPixel);

            //Save P3-----------------------------------------------------
            if (fileFormat == "P3")
            {
                //Loop through all the pixel data
                for (int totalY = 0; totalY < EncodedIMG.Image.Height; totalY++)
                {
                    for (int totalX = 0; totalX < EncodedIMG.Image.Width; totalX++)
                    {
                        //write out all the pixel data
                        curpix = finalIMG.GetPixel(totalX, totalY);
                        outFile.WriteLine(curpix.R);
                        outFile.WriteLine(curpix.G);
                        //if the pixel is at the end of the picture
                        if (totalX == finalIMG.Width - 1 && totalY == finalIMG.Height - 1)
                        {
                            outFile.Write(curpix.B);
                        }
                        else
                        {
                            outFile.WriteLine(curpix.B);
                        }
                    }
                }
                outFile.Close();

            }
            else
            {
                outFile.Close();
                //save P6----------------------------------------------------------------
                FileStream ByteWriter = new FileStream(Filepath, FileMode.Append);
                //Loop through all the pixel data
                for (int totalY = 0; totalY < EncodedIMG.Image.Height; totalY++)
                {
                    for (int totalX = 0; totalX < EncodedIMG.Image.Width; totalX++)
                    {
                        //Write all byte data to the file
                        curpix = finalIMG.GetPixel(totalX, totalY);
                        ByteWriter.WriteByte(curpix.R);
                        ByteWriter.WriteByte(curpix.G);
                        //if the pixel is at the end of the picture
                        if (totalX == finalIMG.Width - 1 && totalY == finalIMG.Height - 1)
                        {
                            ByteWriter.WriteByte(curpix.B);
                        }
                        else
                        {
                            ByteWriter.WriteByte(curpix.B);
                        }
                    }
                }
                ByteWriter.Close();
            }
            

        }

        private void encode_Click(object sender, EventArgs e)
        {
            //check to see if the image box has been filled in and there is a message to encode
            if (UserIMG.Image != null && txtHiddenMessage.Text != "")
            {
                //reset the status of the text box and the progress bar
                encodedStatus.Text = "";
                
                encodeIMG(prepareIMG(), buildDic());
            }
            else
            {
                //send the user a error message
                MessageBox.Show("Please Insert a message to encode.", "Encoding Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

       
        
    }
}








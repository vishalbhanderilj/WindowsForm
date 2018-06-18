using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }
        private void Open_file()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //display the intial directory
            ofd.InitialDirectory = @"C:\";
            //restore current directory before closing it
            ofd.RestoreDirectory = true;

            //set the title of open file dailog
            ofd.Title = "Select File";
            //file does not exixsts
            ofd.CheckFileExists = true;
            ofd.CheckFileExists = true;
            textBox1.Text = ofd.FileName;
            ofd.Multiselect = true;
            /*foreach(String file in ofd.FileNames)
            {
                MessageBox.Show(file);
            }*/
            if (ofd.ShowDialog() == DialogResult.OK)

            {

                textBox1.Text = ofd.FileName;

            }

        }
        private void Delete_File()
        {
            string filepath = textBox1.Text;
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                MessageBox.Show("File Successfully Deleted");
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("File Does Not Exixsts");
            }
        }
        private void Move_File()
        {
            string filepath = textBox1.Text;
            string file =  textBox3.Text;
            string destinationpath = textBox2.Text;
            string dest = Path.Combine(textBox2.Text, textBox3.Text);
            if (File.Exists(filepath))
            {
                File.Move(filepath, dest);
                MessageBox.Show("File Sucessfully Moved");

            }
            else
            {
                MessageBox.Show("File Does Not Exists ");
            }

        }
        private void Open_Folder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            DialogResult result = fbd.ShowDialog();
            if(result == DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
                Environment.SpecialFolder root = fbd.RootFolder;
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            Open_file();
            
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Delete_File();

        }

        private void Move_Click(object sender, EventArgs e)
        {
            Move_File();
        }

        private void Select_Path_Click(object sender, EventArgs e)
        {
            Open_Folder();
        }
        // Move File and with File Keywords
        private void copyFiles()
        {
            string sorcepath = txt_SourcePath.Text;
            string destinationpath = txt_DestinationPath.Text;

            string filename = txt_FileName.Text;

            string sourcefile = Path.Combine(sorcepath, filename);
            string destfile = Path.Combine(destinationpath, filename);

            if (!Directory.Exists(destinationpath))
            {
                Directory.CreateDirectory(destinationpath);
            }

           
            //for copy file from source to destination
                File.Copy(sourcefile, destfile, true);
               // Directory.Move(sorcepath, destfile);
                MessageBox.Show("File Successfully copy to destination location");
                txt_DestinationPath.Text = "";
                txt_FileName.Text = "";
                txt_SourcePath.Text = "";
            
            
           

        }

        private void MoveFile_Click(object sender, EventArgs e)
        {
            copyFiles();
        }
        private void movefiles()
        {
            string sourcepath = txt_SourcePath.Text;
            string destinationpath = txt_DestinationPath.Text;
            string filename = txt_FileName.Text;

            string sfile = Path.Combine(sourcepath, filename);
            string dfile = Path.Combine(destinationpath, filename);

            try
            {
                if(txt_FileName.Text == "")
                {
                    if (Directory.Exists(sourcepath))
                    {
                        FileInfo finfo = new FileInfo(sourcepath);
                        Console.WriteLine(finfo.Directory);
                        Console.WriteLine(finfo.Length);
                        
                        if (Directory.Exists(destinationpath))
                        {
                            string[] files = Directory.GetFiles(sourcepath);

                            foreach (string s in files)
                            {
                                string fname = Path.GetFileName(s);
                                string s1file = Path.Combine(sourcepath, fname);
                                string d1file = Path.Combine(destinationpath, fname);
                                File.Move(s1file, d1file);
                                Console.WriteLine(d1file);
                                Console.WriteLine(fname);

                            }
                            MessageBox.Show("All Files Moved Successfully");

                        }
                        else
                        {
                            MessageBox.Show("Destination path is not exists");
                        }
                        //Directory.CreateDirectory(dfile);
                        //File.Move(sfile, dfile);
                        // MessageBox.Show("File Move SuccessFully to destination");
                        //txt_DestinationPath.Text = "";
                        // txt_FileName.Text = "";
                        //txt_SourcePath.Text = "";

                       
                    }
                    else
                    {
                        MessageBox.Show("source path is not exists");
                    }
                    
                 }
                else
                {
                    if (Directory.Exists(sourcepath))
                    {
                        
                        if (Directory.Exists(destinationpath))
                        {
                            string search = "*" + filename + "*";
                            string[] files = Directory.GetFiles(sourcepath,search);

                            foreach (string s in files)
                            {
                                string fname = Path.GetFileName(s);
                                string s1file = Path.Combine(sourcepath, fname);
                                string d1file = Path.Combine(destinationpath, fname);
                                File.Move(s1file, d1file);
                                Console.WriteLine(d1file);
                                Console.WriteLine(fname);

                            }
                            MessageBox.Show("All Files Moved Successfully");







                        }
                        else
                        {
                            //validate destination
                            MessageBox.Show("Destination path is not existed");
                        }
                    }
                    else
                    {
                        //validate source path
                        MessageBox.Show("Source path is not existed");
                    }
                }

                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void btn_Move_Click(object sender, EventArgs e)
        {
            movefiles();
        }

        private void Move_Directory()
        {
             string sourcepath = txt_Dsourcepath.Text;
             string destinationpath = txt_Ddestinationpath.Text;
          //  string destfile = Path.Combine()
        try{
             if (Directory.Exists(sourcepath))

             {
                    DirectoryInfo dir = new DirectoryInfo(sourcepath);
                    Console.WriteLine(dir);
                    //Console.WriteLine(dir.)
                    if (Directory.Exists(destinationpath))
                     {

                    
                        Directory.Move(sourcepath, destinationpath + "\\" + (new DirectoryInfo(sourcepath)).Name);// + "\\new moved");

                        MessageBox.Show("Directory or folder Successfully Moved");


                    }
                    else
                    {
                      MessageBox.Show("Destination path is not existed");
                    }

                }
             else
             {
                 //validate source path
                 MessageBox.Show("Source path is not existed");
             }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }


        private void MoveDirectory_Click(object sender, EventArgs e)
        {
            Move_Directory();
        }
    }
}

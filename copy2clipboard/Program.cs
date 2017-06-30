using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace copy2clipboard
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string filepath;
            if(args.Length > 0)
            {
                filepath = args[0];
                if (filepath.ToLower().Contains(".svg"))
                {
                    System.Console.WriteLine("SVG is being copied to clipboard");
                    copyAsSVG(filepath);
                }
                System.Console.WriteLine(args[0]);
            }
            else
            {
                System.Console.WriteLine("No arguments specified, closing");
            }
        }

        private static void copyAsSVG(string filepath)
        {
            //StringCollection paths = new StringCollection
            //{
            //    filepath
            //};
            //Clipboard.SetFileDropList(paths);
            string svg = File.ReadAllText(filepath);
            byte[] bytes = Encoding.UTF8.GetBytes(svg);
            MemoryStream stream = new MemoryStream(bytes);
            //DataObject dataObj = new DataObject();
            //dataObj.SetData(stream);
            Clipboard.SetData("image/svg+xml", stream);
        }
    }
}

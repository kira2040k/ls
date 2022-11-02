using CommandLine;
using ls;
using static ls.funs;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.AccessControl;

namespace HelloWorld
{

    class Hello
    {

        public class Options
        {
            // find [done]
            // list sub dir.. [done]
            // file size [done]
            // file size with GB,KB [done]
            // colors 50%
            // types [done]
            // clean code [done]
            // fix type and find bug [done]
            // file permisitons 
            // add more info
            

            [Option('p', "path", Required = false, HelpText = "Specify path e.g: -p C:\\Users\\")]
            public string path { get; set; }

            [Option('s', "size", Required = false, HelpText = "Print file or folder size. e.g: -s KB")]
            public string size { get; set; }

            [Option('f', "find", Required = false, HelpText = "find file or folder . e.g: -f backup.zip")]
            public string find { get; set; }

            [Option('t', "type", Required = false, HelpText = "file or folder . e.g: -t file")]
            public string type { get; set; }

            [Option('l', "list", Required = false, HelpText = "List subdirectories recursively.")]
            public bool list { get; set; }

            [Option('r', "regex", Required = false, HelpText = "Use regex for file searching.")]
            public string regex { get; set; }

            //[Option('a',"permissions", Required = false, HelpText = "print file permissions")]
            //public bool permissions { get; set; }
            [Option('i', "info", Required = false, HelpText = "print informations")]
            public bool info { get; set; }
            

        }




        static void Main(string[] args)
        {
            funs funs = new funs();
            Parser.Default.ParseArguments<Options>(args)
                  .WithParsed<Options>(o =>
                  {
                      if (o.path == null)
                          o.path = ".";
                      funs.run(o);
                      Console.OutputEncoding = Encoding.UTF8;
                      
                  });   

                    }
    }
}
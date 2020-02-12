using System;
using System.Linq;
using System.IO;
using System.Globalization;
using McMaster.Extensions.CommandLineUtils;

namespace Latihan12Feb
{
    [HelpOption("--hlp")]
    class Program
    {
        public static int Main(string[] args)

          =>  CommandLineApplication.Execute<Program>(args);
            
        [Argument(0, Description = "Configuration file")]
        [FileExists]
        public string ConfigurationFile { get; }

        [Argument(1, Description = "Comparison file 1")]
        [FileExists]
        public string ComparisonFile1 { get; }

        [Argument(2, Description = "Comparison File 2")]
        [FileExists]
        public string ComparisonFile2 { get; }

        private void OnExecute()
        {
            Console.WriteLine(ConfigurationFile);
            Console.WriteLine(ComparisonFile1);
            Console.WriteLine(ComparisonFile2);
        }

        // public class StringTranform 
        // {
        //      [Option("lowercase",Description = "The String")]
        //     public string Subject { get; set;}
        //     public void OnExecute()
        //     {
        //         var subject = Subject.ToLower() ;

                
        //     }
        // } 

        // public class StringTranform2 
        // {
        //      [Option("upercase",Description = "The String")]
        //     public string Subject { get; set;}
        //     public void OnExecute()
        //     {
        //         var subject = Subject.ToUpper() ;
        //         Console.WriteLine($"Hello {subject}!");

        //     }
        // }
        // public class StringTranform3 
        // {
        //      [Option("capitalize",Description = "The String")]
        //     public string Subject { get; set;}
        //     public void OnExecute()
        //     {
        //         var subject = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Subject) ;
        //         Console.WriteLine($"Hello {subject}!");

        //     }
        // }      
    }
     
 }
 


using System;
using System.Linq;
using System.IO;
using System.Globalization;
using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;

namespace Latihan12Feb
{
    [HelpOption("--hlp")]
    [Subcommand(
        typeof(UpperCase),
        typeof(LowerCase),
        typeof(Capitalize),
        typeof(Palindrome),
        typeof(obfuscator)
    )]
    class Program
    {
        public static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
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

    [Command(Description = "Command to uppercase string", Name = "uppercase")]
    class UpperCase
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine($"{text.ToUpper()}");
        }
    }
    [Command(Description = "Command to lowercase string", Name = "lowercase")]
    class LowerCase
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine($"{text.ToLower()}");
        }
    }

    [Command(Description = "Command to Capitalize string", Name = "capitalize")]
    class Capitalize
    {
        [Argument(0)]
        public string text { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine($"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text)}");
        }
    }

    public class Arithmatic 
    {

    }
    
    [Command(Description = "check if the string is palindrome", Name = "palindrome")] 
    class Palindrome
    {
        [Argument(0)]
       public string text { get; set; }
       public bool OnExecute(CommandLineApplication app)
        {

            string first = text.Substring(0, text.Length / 2);
            char[] arr = text.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
            string second = temp.Substring(0, temp.Length / 2);

            Console.WriteLine(first.Equals(second));
            return first.Equals(second);
        }
    }

   [Command(Description = "Command to Capitalize string", Name = "obfuscator")] 
    public class   obfuscator 
    {
        [Argument(0)]
        public string email { get; set; }
        public void OnExecute(CommandLineApplication app)
        {

            char[] Email = email.ToCharArray();
            List<string> Obfused = new List<string>();
            for(int i =0;i<Email.Length;i++)
            {
                Obfused.Add($"&#{Convert.ToString(Convert.ToInt32(Email[i]))}");
            }
            Console.WriteLine(String.Join(";", Obfused));
        }

    }
    
    public class randomstring 
    {

    }
     
 }
 


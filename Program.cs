using System;
using System.Linq;
using System.IO;
using System.Globalization;
using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Latihan12Feb
{
    [HelpOption("--hlp")]
    [Subcommand(
        typeof(UpperCase),
        typeof(LowerCase),
        typeof(Capitalize),
        typeof(Add),
        typeof(Multiply),
        typeof(Substract),
        typeof(Divide),
        typeof(Palindrome),
        typeof(obfuscator),
        typeof(randomstring),
        typeof(GetIPpublic),
        typeof(getIPPrivateNetwork),
        typeof(sum)
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

    //num2
    [Command(Description = "Command to add number", Name = "add")]
    class Add
    {
        [Argument(0)]
        public int [] num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            long sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i];
            }
            Console.WriteLine(sum);

        }
    }
    [Command(Description = "Command to substract number", Name = "substract")]
    class Substract
    {
        [Argument(0)]
        public int [] num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            long sum = num[0];
            for (int i = 1; i < num.Length; i++)
            {
                sum -= num[i];
            }
            Console.WriteLine(sum);
        }
    }
    [Command(Description = "Command to multiply number", Name = "multiply")]
    class Multiply
    {
        [Argument(0)]
        public int [] num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {

            double sum = num[0];
            for (int i = 1; i < num.Length; i++)
            {
                sum *= num[i];
            }
            Console.WriteLine(sum);

        }
    }
    [Command(Description = "Command to divide number", Name = "divide")]
    class Divide
    {
        [Argument(0)]
        public int [] num { get; set; }
        public void OnExecute(CommandLineApplication app)
        {
            double sum = num[0];
            for (int i = 1; i < num.Length; i++)
            {
                sum /= num[i];
            }
            Console.WriteLine(sum);
        }
    }

    
    [Command(Description = "check if the string is palindrome", Name = "palindrome")] 
    class Palindrome
    {
        [Argument(0)]
       public string text { get; set; }
       public void OnExecute(CommandLineApplication app)
            {
                string rev;
                char[] word = text.ToCharArray();
                Array.Reverse(word);
                rev = new string(word);
                bool palindrom = text.Equals(rev, StringComparison.OrdinalIgnoreCase);
                if (palindrom == true)
                {
                    Console.WriteLine("Is palindrome? Yes");
                } else
                {
                    Console.WriteLine("Is palindrome? No");
                }
            }
    }

    //4
   [Command(Description = "obfuscator ", Name = "obfuscator")] 
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


    //5
    [Command(Description = "Command to Capitalize string", Name = "randomstring")]     
    class randomstring 
    {
         [Option(ShortName = "l")]
        public int Count { get; }
        public void OnExecute(CommandLineApplication app)
        {
            StringBuilder str_build = new StringBuilder();  
            Random random = new Random();  

            char letter;  

            for (int i = 0; i < Count; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);  
            }  
            System.Console.WriteLine(str_build.ToString());

        }

    }

    //6
    [Command(Description = "Command to Capitalize string", Name = "ip")]     
    class GetIPpublic
    {
        public void OnExecute(CommandLineApplication app)
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            Console.WriteLine(hostName);  
           // Get the IP  
            string myIP = Dns.GetHostEntry(hostName).AddressList[3].ToString();  
            Console.WriteLine("My IP Address is :"+myIP);  
            Console.ReadKey();  
        }


    }


    //7
    [Command(Description = "Command to Capitalize string", Name = "ip-external")]  
    class getIPPrivateNetwork
    {
        public void OnExecute(CommandLineApplication app)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    Console.WriteLine("My IP Address is : null");
                }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            Console.WriteLine("My IP Address Is : "+host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString()); 
        }
    }


    //10
    [Command(Description = "command to sum every input", Name="sum")]
    class sum
    {
        public void OnExecute(CommandLineApplication app)
        {
            long sum = 0;
            string X = "";
            while (X != null)
            {
                Console.Write("Insert number : ");
                X = Console.ReadLine();
                if (X == "")
                {
                    break;
                }
                else
                {
                    long A = Convert.ToInt32(X);
                    sum += A;
                }
            }
            Console.WriteLine(sum);
        }
    }
 }
 


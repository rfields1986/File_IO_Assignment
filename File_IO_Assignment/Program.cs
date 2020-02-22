using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week9Assign
{
    class Program
    {
        static void Main(string[] args)
        {

            //Brittney,
            //      You do not have to create any files in the debug folder prior to running the code.  
            //      If the code works, the files will be automatically generated/deleted in the debug folder as the code runs.
            //      The "Analytics.txt" file will overwrite the data from options 2,3,4 each time the application is run. 



            StreamWriter header = new StreamWriter("Header.txt");
            header.WriteLine("               FFFFFFFFF   IIIIIIII   LL         EEEEEEEE     IIIIIIII       //   OOOOOOOO\n" +
                "               FF             II      LL         EE              II         //    OO    OO\n" +
                "               FFFF           II      LL         EE              II        //     OO    OO\n" +
                "               FF             II      LL         EEEE            II       //      OO    OO\n" +
                "               FF             II      LL         EE              II      //       OO    OO\n" +
                "               FF          IIIIIIII   LLLLLLLL   EEEEEEEE     IIIIIIII  //        OOOOOOOO\n");
            header.Close();

            int quit = 0, selection, count = 0, rolls = 0, drop = 0;
            string readout, input, charreadout;
            Random roll = new Random();
            File.Delete("Analytics.txt");


            do
            {
                drop = 0;


                while (drop == 0)
                {
                    Console.Clear();
                    StreamReader header1 = new StreamReader("Header.txt");
                    readout = header1.ReadToEnd();
                    header.Close();
                    Console.Write($"{readout}\n\n1) Append To File\n2) Display line count of file\n3) Display character count, by line, for file\n" +
                        $"4) Display random number of lines from file" +
                        $"\n5) Quit\n\n--------Selection--------> ");
                    Int32.TryParse(Console.ReadLine(), out selection);

                    switch (selection)
                    {
                        case 1:
                            StreamWriter file = new StreamWriter("File.txt", true);
                            Console.Write("\nPlease enter data to be written to the file--> ");
                            input = Console.ReadLine();
                            file.WriteLine(input);
                            file.Close();
                            count = File.ReadAllLines("File.txt").Length;
                            Console.WriteLine("\nTo return to the main menu press any key");
                            Console.ReadKey();

                            break;

                        case 2:
                            if (count > 0)
                            {
                                StreamWriter analyze = new StreamWriter("Analytics.txt");
                                analyze.WriteLine($"Line count is {count}    " + DateTime.Now);
                                Console.WriteLine($"\nThe line count is {count}\n\nTo return to the main menu press any key");
                                Console.ReadKey();
                                analyze.Close();
                            }
                            else
                            {
                                Console.WriteLine("No data in file.\nTo return to the main menu press any key");
                                Console.ReadKey();

                            }
                            break;

                        case 3:
                            if (count > 0)
                            {
                                StreamReader Char = new StreamReader("File.txt");
                                StreamWriter anaylze = new StreamWriter("Analytics.txt", true);

                                for (int a = 0; a < count; a++)
                                {
                                    charreadout = Char.ReadLine();
                                    Console.WriteLine($"\n{charreadout} is {charreadout.Length} characters long.\n");
                                    anaylze.WriteLine($"{charreadout} is {charreadout.Length} characters long." + DateTime.Now + "\n");
                                }
                                Console.WriteLine("To return to the main menu press any key");
                                Console.ReadKey();
                                Char.Close();
                                anaylze.Close();

                            }
                            else
                            {
                                Console.WriteLine("No data in file.\nTo return to the main menu press any key");
                                Console.ReadKey();
                            }
                            break;

                        case 4:
                            if (count > 0)
                            {
                                StreamWriter anaylze = new StreamWriter("Analytics.txt", true);
                                StreamReader file1 = new StreamReader("File.txt");
                                rolls = roll.Next(0, count) + 1;
                                Console.WriteLine($"\nShowing {rolls} line(s)\n");
                                for (int b = 0; b < rolls; b++)
                                {
                                    readout = file1.ReadLine();
                                    Console.WriteLine($"\n{readout}\n");
                                    anaylze.WriteLine($"{readout}");

                                }
                                Console.WriteLine("To return to the main menu press any key");
                                Console.ReadKey();
                                file1.Close();
                                anaylze.Close();
                            }
                            else
                            {
                                Console.WriteLine("No data in file.\nTo return to the main menu press any key");
                                Console.ReadKey();
                            }
                            break;

                        case 5:

                            Console.WriteLine("\nGoodbye\n");
                            quit = 1;
                            drop = 1;
                            break;






                    }







                }



            }
            while (quit != 1);
            {
                File.Delete("File.txt");


            }



        }
    }
}

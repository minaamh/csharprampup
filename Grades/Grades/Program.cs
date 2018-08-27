using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello! This is the grade book program");
            IGradeTracker book = new ThrowAwayGradeBook("Mina's Book");
            //book.AddGrade(91);
            //book.AddGrade(89.5f);
            //book.AddGrade(75); Do this instead:

            try
            {
                using (FileStream stream = File.Open("grades.txt", FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        float grade = float.Parse(line);
                        book.AddGrade(grade);
                        line = reader.ReadLine();
                    }
                }

                //The next chunk is replaced by the code above. Just another way to do things
                //string[] lines = File.ReadAllLines("grades.txt");
                //foreach (string line in lines)
                //{
                //    float grade = float.Parse(line);
                //    book.AddGrade(grade);
                //}
                book.WriteGrades(Console.Out);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found!");
                return;
            }
            using (StreamWriter outputFile = File.CreateText("GradesResults.txt"))
            {
                book.WriteGrades(outputFile);
            }

            try
            {
                Console.WriteLine("Please enter a name for the book:");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }


            WriteNames("Mina", "Mirna", "Magdi", "Manal");
            GradeStatistics stats = book.ComputeStatistics();
            stats.AvgGradeChange += new AvgGradechangedDelegate(OnAvgGradeChange);
            book.NameChanged += new NamedChangedDelegate(OnNameChanged);

            int number = 20;
            WriteBytes(number);
            WriteBytes(stats.averageGrade);

            book.Name = "Amazing Book";

            WriteNames(book.Name);
            WriteResults(book);
            Console.WriteLine("{0} {1}", stats.LetterGrade, stats.Description); stats.LetterGrade = "A";

        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            foreach (var grade in book)
            {
                Console.WriteLine(grade);
            }
            Console.WriteLine(stats.averageGrade);
            Console.WriteLine(stats.highestGrade);
            Console.WriteLine(stats.lowestGrade);
        }

        private static void OnAvgGradeChange(object sender, AvgGradeEventArgsDelegate args)
        {
            Console.WriteLine("Average grade changed from {0} to {1}", args.OldAvgGrade, args.NewAvgGrade);
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak($"Average grade changed from {args.OldAvgGrade} to {args.NewAvgGrade}");
        }

        private static void OnNameChanged(object sender, NameChangeEventArgsDelegate args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak($"Name changed from {args.OldValue} to {args.NewValue}");
        }

        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        private static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteBytesArray(bytes);
        }


        private static void WriteBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteBytesArray(bytes);
        }

        private static void WriteBytesArray(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write("0X{0:X} ", b);
            }
            Console.WriteLine();
        }
    }
}

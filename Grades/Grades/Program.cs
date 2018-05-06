using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello! This is the grade book program");
            GradeBook book = new GradeBook("Mina's Book");
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            WriteNames("Mina", "Mirna", "Magdi", "Manal");
            GradeStatistics stats = book.ComputeStatistics();

            book.NameChanged += new NamedChangedDelegate(OnNameChanged);

            int number = 20;
            WriteBytes(number);
            WriteBytes(stats.averageGrade);

            book.Name = "Amazing Book";

            WriteNames(book.Name);
            Console.WriteLine(stats.averageGrade);
            Console.WriteLine(stats.highestGrade);
            Console.WriteLine(stats.lowestGrade);

            book.Name = "Mina's Book";
        }

        private static void OnNameChanged(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak($"Name changed from {args.OldValue} to {args.NewValue}");
        }

        private static void WriteNames(params string []names)
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

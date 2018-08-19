using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {

        public GradeBook(string name = "No name set")
        {
            Console.WriteLine("GradeBook ctor");
            Name = name;
            _grades = new List<float>();
        }
        public void AddGrade(float grade)
        {
            _grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            float sum = 0;
            foreach (float grade in _grades)
            {
                sum += grade;
            }
            stats.averageGrade = sum / _grades.Count;
            stats.highestGrade = _grades.Max();
            stats.lowestGrade = _grades.Min();
            return stats;
        }

        public void WriteGrades(TextWriter destination)
        {
            destination.WriteLine("Grades:"+destination.NewLine);
            foreach (float grade in _grades)
            {
                destination.WriteLine(grade);
            }

            //for (int i = 0; i < _grades.Count; i++)
            //{
            //    @destination.WriteLine(_grades[i]);
            //}
            destination.WriteLine("**********************" + destination.NewLine);
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Name of GradeBook cannot be set to NULL or empty");
                }
                if (!string.IsNullOrEmpty(value))
                {
                    if (_name!=value)
                    {
                        string OldValue = _name;
                        _name = value;
                        if (NameChanged != null)
                        {
                            NameChangeEventArgsDelegate args = new NameChangeEventArgsDelegate();
                            args.OldValue = OldValue;
                            args.NewValue = value;
                            NameChanged(this, args);
                        }
                    }
                    
                }
            }
        }

        public event NamedChangedDelegate NameChanged;
        protected List<float> _grades;

    }
}

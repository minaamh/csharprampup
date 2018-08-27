using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {

        public GradeBook(string name = "No name set")
        {
            Console.WriteLine("GradeBook ctor");
            Name = name;
            _grades = new List<float>();
        }
        public override void AddGrade(float grade)
        {
            _grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
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

        public override void WriteGrades(TextWriter destination)
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

        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }

        protected List<float> _grades;
    }
}

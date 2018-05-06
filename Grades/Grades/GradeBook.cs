using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {

        public GradeBook(string name = "No name set")
        {
            Name = name;
            grades = new List<float>();
        }
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            float sum = 0;
            foreach (float grade in grades)
            {
                sum += grade;
            }
            stats.averageGrade = sum / grades.Count;
            stats.highestGrade = grades.Max();
            stats.lowestGrade = grades.Min();
            return stats;
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
                if (!string.IsNullOrEmpty(value))
                {
                    if (_name!=value)
                    {
                        string OldValue = _name;
                        _name = value;
                        if (NameChanged != null)
                        {
                            NameChangeEventArgs args = new NameChangeEventArgs();
                            args.OldValue = OldValue;
                            args.NewValue = value;
                            NameChanged(this, args);
                        }
                    }
                    
                }
            }
        }

        public event NamedChangedDelegate NameChanged;
        List<float> grades;

    }
}

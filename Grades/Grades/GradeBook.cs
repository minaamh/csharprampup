using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook()
        {
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
            foreach(float grade in grades)
            {
                sum += grade;
            }
            stats.averageGrade = sum / grades.Count;
            stats.highestGrade = grades.Max();
            stats.lowestGrade = grades.Min();
            return stats;
        }
        List<float> grades;
   
    }
}

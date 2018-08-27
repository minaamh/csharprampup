using System.Collections;
using System.IO;

namespace Grades
{
    internal interface IGradeTracker : IEnumerable 
    {
        string Name { get; set; }

        void AddGrade(float grade);

        GradeStatistics ComputeStatistics();

        void WriteGrades(TextWriter destination);

        event NamedChangedDelegate NameChanged;
    }
}
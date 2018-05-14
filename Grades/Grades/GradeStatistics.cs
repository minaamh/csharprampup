using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        public float averageGrade;
        public float highestGrade;
        public float lowestGrade;

        public string Description
        {
            get
            {
                string result;

                switch (LetterGrade)
                {
                    case "A":
                        result= "Excellent";
                        break;
                    case "B":
                        result = "Above average";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below Average";
                        break;
                    default:
                        result = "Excellent";
                        break;
                }
                return result;
            }
        }

        public string LetterGrade
        {
            get
            {
                string result;
                string oldValue = _letterGrade;
                if (averageGrade >= 90)
                {
                    result = "A";
                }
                else if (averageGrade >= 80)
                {
                    result = "B";
                }
                else if (averageGrade >= 70)
                {
                    result = "C";
                }
                else if (averageGrade >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }
                IsAvgGradeChanged(result, oldValue);
                _letterGrade = result;
                return result;
            }

            set
            {
                string oldAvgGrade = _letterGrade;
                IsAvgGradeChanged(value, oldAvgGrade);
            }
        }


        private void IsAvgGradeChanged(string result, string oldValue)
        {
            if (result != oldValue && oldValue != null)
            {
                if (AvgGradeChange != null)
                {
                    AvgGradeEventArgsDelegate args = new AvgGradeEventArgsDelegate();
                    args.OldAvgGrade = oldValue;
                    args.NewAvgGrade = result;
                    AvgGradeChange(this, args);
                }
            }
        }

        public event AvgGradechangedDelegate AvgGradeChange;
        private string _letterGrade;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);

        public abstract GradeStatistics ComputeStatistics();

        public abstract IEnumerator GetEnumerator();
        public abstract void WriteGrades(TextWriter destination);

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
                    if (_name != value)
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
        
    }
}

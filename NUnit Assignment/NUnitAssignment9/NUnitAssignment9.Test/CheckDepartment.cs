using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitAssignment9.Test
{
    public class CheckDepartment : NUnit.Framework.Constraints.Constraint
    {
        readonly string _dept;

        public CheckDepartment(string dept)
        {
            _dept = dept;

        }
        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            List<Student> stu = actual as List<Student>;
            foreach (Student e in stu)
            {
                if (e.Department != _dept)
                {
                    return new ConstraintResult(this, actual, ConstraintStatus.Error);
                }
            }
            return new ConstraintResult(this, actual, ConstraintStatus.Success);

        }
    }

    public class Is : NUnit.Framework.Is
    {
        public static CheckDepartment Check(string dept)
        {
            return new CheckDepartment(dept);
        }
    }
}

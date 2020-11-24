using System.Collections.Generic;

namespace Training
{
    public class TestCase
    {
        public int NumberOfStudentsToPick { get; }

        public IEnumerable<int> StudentsSkill { get; }

        public TestCase(int numberOfStudentsToPick, IEnumerable<int> studentsSkill)
        {
            NumberOfStudentsToPick = numberOfStudentsToPick;
            StudentsSkill = studentsSkill;
        }
    }
}
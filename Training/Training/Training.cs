using System;
using System.Collections.Generic;
using System.Linq;

namespace Training
{
    public class Training
    {
        private const int Error = -1;

        public static int GetMinimumTrainingRequiredV1(TestCase testCase)
        {
            // Pre-condition.
            if (!IsTestCaseValid(testCase))
            {
                return Error;
            }

            List<int> orderedSkills = testCase.StudentsSkill.OrderByDescending(studentSkill => studentSkill).ToList();

            // First possible selection.
            int candidateValue = 0;

            for (int j = 1; j < testCase.NumberOfStudentsToPick; ++j)
            {
                candidateValue += orderedSkills[0] - orderedSkills[j];
            }

            int result = candidateValue;

            int numOfPossibleSelections = orderedSkills.Count - testCase.NumberOfStudentsToPick + 1;
            int numOfStudentsToPickMinus1 = testCase.NumberOfStudentsToPick - 1;

            for (int i = 1; i < numOfPossibleSelections; ++i)
            {
                candidateValue -= numOfStudentsToPickMinus1 * (orderedSkills[i - 1] - orderedSkills[i]);
                candidateValue += orderedSkills[i] - orderedSkills[i + numOfStudentsToPickMinus1];

                result = Math.Min(result, candidateValue);
            }

            return result;
        }

        public static int GetMinimumTrainingRequiredV2(TestCase testCase)
        {
            // Pre-condition.
            if (!IsTestCaseValid(testCase))
            {
                return -1;
            }

            int result = int.MaxValue;

            List<int> orderedSkills = testCase.StudentsSkill.OrderByDescending(studentSkill => studentSkill).ToList();

            int numOfPossibleSelections = orderedSkills.Count - testCase.NumberOfStudentsToPick + 1;

            for (int i = 0; i < numOfPossibleSelections; ++i)
            {
                int candidateValue = 0;

                for (int j = 1; j < testCase.NumberOfStudentsToPick; ++j)
                {
                    candidateValue += orderedSkills[i] - orderedSkills[i + j];

                    if (candidateValue >= result)
                    {
                        break;
                    }
                }

                result = Math.Min(result, candidateValue);
            }

            return result;
        }

        private static bool IsTestCaseValid(TestCase testCase)
        {
            if (testCase.NumberOfStudentsToPick <= 0)
            {
                return false;
            }

            if (testCase.StudentsSkill == null)
            {
                return false;
            }

            return testCase.NumberOfStudentsToPick <= testCase.StudentsSkill.Count();
        }
    }
}
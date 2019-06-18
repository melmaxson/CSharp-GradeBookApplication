using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        //public int studentRank;

        public override char GetLetterGrade(double averageGrade)
        {
            int letterGradeGroupSize = (int)Math.Ceiling(Students.Count * .2);
            
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            else
            {
                int rank = CalculateStudentRank(averageGrade);
 
                if (rank <= letterGradeGroupSize)
                    return 'A';
                else if (rank <= (2 * letterGradeGroupSize))
                    return 'B';
                else if (rank <= (3 * letterGradeGroupSize))
                    return 'C';
                else if (rank <= (4 * letterGradeGroupSize))
                    return 'D';
                else
                    return 'F';
            }
        }

        int CalculateStudentRank(double averageGrade)
        {
            int studentRank = 1;

            foreach (var student in Students)
            {
                
                if (student.AverageGrade > averageGrade)
                {
                    studentRank += 1;
                    //else if (student.AverageGrade > averageGrade)
                    //  studentsAbove += 1;
                    //else if (student.AverageGrade == averageGrade)
                    //    sameGrade += 1;

                }
            }
            return studentRank;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grads in order to properly calculate a student's overall grade.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grads in order to properly calculate a student's overall grade.");
            else
                base.CalculateStudentStatistics(name);
        }

    }
}

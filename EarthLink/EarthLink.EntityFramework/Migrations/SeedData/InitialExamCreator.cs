using EarthLink.EntityFramework;
using EarthLink.Exams;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EarthLink.Migrations.SeedData
{
    public class InitialExamCreator
    {
        private readonly EarthLinkDbContext _context;

        public InitialExamCreator(EarthLinkDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var dummyExam = "<div id=\"brinza-task-description\"><p>This is a demo task. You can read about this task and its solutions in <a href=\"http://blog.codility.com/2011/03/solutions-for-task-equi.html\" target=\"_blank\">this blog post</a>.</p><p>A zero-indexed array A consisting of N integers is given. An <i>equilibrium index</i> of this array is any integer P such that 0 ≤ P &lt; N and the sum of elements of lower indices is equal to the sum of elements of higher indices, i.e. <br></p><blockquote><p>A[0] + A[1] + ... + A[P−1] = A[P+1] + ... + A[N−2] + A[N−1].<br></p></blockquote><p>Sum of zero elements is assumed to be equal to 0. This can happen if P = 0 or if P = N−1.</p><p>For example, consider the following array A consisting of N = 8 elements:</p><tt style=\"white-space:pre-wrap\">  A[0] = -1  A[1] =  3  A[2] = -4  A[3] =  5  A[4] =  1  A[5] = -6  A[6] =  2  A[7] =  1</tt><p>P = 1 is an equilibrium index of this array, because:</p><blockquote><ul style=\"margin: 10px;padding: 0px;\"><li>A[0] = −1 = A[2] + A[3] + A[4] + A[5] + A[6] + A[7]</li></ul></blockquote><p>P = 3 is an equilibrium index of this array, because:</p><blockquote><ul style=\"margin: 10px;padding: 0px;\"><li>A[0] + A[1] + A[2] = −2 = A[4] + A[5] + A[6] + A[7]</li></ul></blockquote><p>P = 7 is also an equilibrium index, because:</p><blockquote><ul style=\"margin: 10px;padding: 0px;\"><li>A[0] + A[1] + A[2] + A[3] + A[4] + A[5] + A[6] = 0</li></ul></blockquote><p>and there are no elements with indices greater than 7.</p><p>P = 8 is not an equilibrium index, because it does not fulfill the condition 0 ≤ P &lt; N.</p><p>Write a function:</p><blockquote><p class=\"lang-cs\" style=\"font-family: monospace; font-size: 9pt; display: block; white-space: pre-wrap\"><tt>class Solution { public int solution(int[] A); }</tt></p></blockquote><p>that, given a zero-indexed array A consisting of N integers, returns any of its equilibrium indices. The function should return −1 if no equilibrium index exists.</p><p>For example, given array A shown above, the function may return 1, 3 or 7, as explained above.</p><p>Assume that:</p><blockquote><ul style=\"margin: 10px;padding: 0px;\"><li>N is an integer within the range [<span class=\"number\">0</span>..<span class=\"number\">100,000</span>];</li><li>each element of array A is an integer within the range [<span class=\"number\">−2,147,483,648</span>..<span class=\"number\">2,147,483,647</span>].</li></ul></blockquote><p>Complexity:</p><blockquote><ul style=\"margin: 10px;padding: 0px;\"><li>expected worst-case time complexity is O(N);</li><li>expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).</li></ul></blockquote><p>Elements of input arrays can be modified.</p></div>";
            Random rnd = new Random();
            var demoExam1 = _context.Exams.FirstOrDefault(p => p.Name == "Demo Exam 1");
            if (demoExam1 == null)
            {
                _context.Exams.Add(
                    new Exams.Exam
                    {
                        Name = "Demo Exam 1",
                        InvitationUrl = ((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + rnd.Next(1, 10000)).ToString(),
                        Description = dummyExam,
                        TestCases = new List<TestCase>
                        {
                            new TestCase { ExpectedOutput = "24", Input = "[8,8,8]" },
                            new TestCase { ExpectedOutput = "12", Input = "[6,6]" }
                        }
                    });
            }

            var demoExam2 = _context.Exams.FirstOrDefault(p => p.Name == "Demo Exam 2");
            if (demoExam2 == null)
            {
                _context.Exams.Add(
                    new Exams.Exam
                    {
                        Name = "Demo Exam 2",
                        InvitationUrl = ((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + rnd.Next(1, 10000)).ToString(),
                        Description = dummyExam,
                        TestCases = new List<TestCase>
                        {
                            new TestCase { ExpectedOutput = "24", Input = "[8,8,8]" },
                            new TestCase { ExpectedOutput = "12", Input = "[6,6]" }
                        }
                    });
            }

            var demoExam3 = _context.Exams.FirstOrDefault(p => p.Name == "Demo Exam 3");
            if (demoExam3 == null)
            {
                _context.Exams.Add(
                    new Exams.Exam
                    {
                        Name = "Demo Exam 3",
                        InvitationUrl = ((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + rnd.Next(1, 10000)).ToString(),
                        Description = dummyExam,
                        TestCases = new List<TestCase>
                        {
                            new TestCase { ExpectedOutput = "24", Input = "[8,8,8]" },
                            new TestCase { ExpectedOutput = "12", Input = "[6,6]" }
                        }
                    });
            }

            var demoExam4 = _context.Exams.FirstOrDefault(p => p.Name == "Demo Exam 4");
            if (demoExam1 == null)
            {
                _context.Exams.Add(
                    new Exams.Exam
                    {
                        Name = "Demo Exam 4",
                        InvitationUrl = ((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + rnd.Next(1, 10000)).ToString(),
                        Description = dummyExam,
                        TestCases = new List<TestCase>
                        {
                            new TestCase { ExpectedOutput = "9", Input = "[4,3,2]" },
                            new TestCase { ExpectedOutput = "32", Input = "[6,26]" }
                        }
                    });
            }
        }
    }
}

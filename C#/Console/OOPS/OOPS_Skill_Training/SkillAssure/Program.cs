using System.Runtime.CompilerServices;

namespace SkillAssure
{
    internal class Program
    {
        static void Main(string[] args)
        {
          SkillAssureTrainingModel model = new SkillAssureTrainingModel();
            model.ClientName = "XYZ CORP";
            McqQuestion mcqquestion = new McqQuestion
            {
                marks = 5,
                QuestionName = "What is oops",
                option1 = "A",
                option2 = "B",
                option3 = "C",
                option4 = "D",
                RightOption="A"
            };
            HandsOnQuestion hanque = new HandsOnQuestion
            {
                marks=10,
                QuestionDesc="Create a class in c#",
                ReferenceDocument="Doc.pdf"
            };
            Assessment assessment = new Assessment
            {
                AssessmentId="A1",
                Desc="Basics test",
                DtAssessment=DateTime.Now,

            };
            assessment.questions.Add(hanque);
            assessment.questions.Add(mcqquestion);
            Course course = new Course
            {
                CourseId = "C1",
                Name="C# Fundamentals"
            };
            Iteration iteration = new Iteration
            {
                IterationNo=1,
                Goal="Understand c# basics",
                Course=course,
            };
            iteration.Assessments.Add(assessment);
            model.Iterations.Add(iteration);
            Console.WriteLine($"Total assessments: {model.GetTotalAssessmentTraining()}");
            Console.WriteLine($"Mcq Questions: {model.GetNumMcqBasedAssessments()}");
            Console.WriteLine($"HandsOn Questions: {model.GetNumHandsOnBasedAssessments()}");
            Console.WriteLine($"Total Score: {model.GetTotalScoreOfAllAssessments()}");
        }
    }
    abstract class Question
    {
        public int marks {  get; set; }
    }

    class McqQuestion : Question
    {
        public string QuestionName { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string RightOption { get; set; }
    }
    class HandsOnQuestion : Question
    {
        public string QuestionDesc { get; set; }
        public string ReferenceDocument { get; set; }
    }
    class Assessment
    {
        public string AssessmentId { get; set; }
        public string Desc { get; set; }
        public int NoOfQuestions => questions.Count;

        public DateTime DtAssessment { get; set; }

        public List<Question> questions { get; set; } = new List<Question>();

        public int GetTotalMarks()
        {
            int total = 0;
            foreach (Question question in questions)
            {
                total += question.marks;
            }
            return total;
        }

    }
    class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
    }
    class Iteration
    {
        public int IterationNo { get; set; }
        public string Goal {  get; set; }

        public List<Assessment> Assessments { get; set; }=new List<Assessment>();
        public Course Course { get; set; }
    }

    class SkillAssureTrainingModel
    {
        public string ClientName    { get; set; }
        public List<Iteration> Iterations { get; set; }= new List<Iteration>();
        public int GetTotalAssessmentTraining()
        {
            int count = 0;
            foreach (Iteration iteration in Iterations)
            {
                count += iteration.Assessments.Count;
            }
            return count;
        }
        public int GetNumMcqBasedAssessments()
        {
            int count = 0;
            foreach (Iteration iteration in Iterations)
            {
                foreach (var item in iteration.Assessments)
                {
                    foreach (var q in item.questions)
                    {
                        if(q is McqQuestion)
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            return count;
        }

        public int GetNumHandsOnBasedAssessments()
        {
            int count = 0;
            foreach (Iteration iteration in Iterations)
            {
                foreach (var item in iteration.Assessments)
                {
                    foreach (var q in item.questions)
                    {
                        if (q is HandsOnQuestion)
                        {
                            count ++;
                            break;
                        }
                    }
                }
            }
            return count;
        }

        public int GetTotalScoreOfAllAssessments()
        {
            int total = 0;
            foreach (Iteration iteration in Iterations)
            {
                foreach (var item in iteration.Assessments)
                {
                    total += item.GetTotalMarks();
                }

            }
            return total;
        }
    }
}

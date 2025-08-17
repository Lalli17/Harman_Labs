namespace TrainerTraineeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Training training = new Training();
            Trainer trainer = new Trainer();
            Organization organization = new Organization();

            organization.Name = "EdForce";

            training.Trainer = trainer;
            trainer.Organization = organization;

            Console.WriteLine($"The Organization is : {training.GetTrainingOrgName()}");

            Trainee t1 = new Trainee();
            Trainee t2 = new Trainee();
            Trainee t3 = new Trainee();

            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            training.Trainees.Add(t3);

            Console.WriteLine($"Trainees Count : {training.GetNoOfTrainees()}");

            Course course = new Course();
            training.Course = course;

            Module m1 = new Module();
            Module m2 = new Module();

            course.Modules.Add(m1);
            course.Modules.Add(m2);

            Unit u1 = new Unit();
            u1.Duration = 60;
            Unit u2 = new Unit();
            u2.Duration = 30;
            Unit u3 = new Unit();
            u3.Duration = 30;
            Unit u4 = new Unit();
            u4.Duration = 30;

            m1.Units.Add(u1);
            m1.Units.Add(u2);

            m2.Units.Add(u3);
            m2.Units.Add(u4);

            Console.WriteLine($"Training Duration: {training.GetTrainingDuration()}");



        }
    }

    class Organization
    {
        public string Name { get; set; }

        public Address Address
        {
            get;
            set;
        }
    }
    class Trainer
    {
        public Organization Organization { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();

        public List<Training> Trainings { get; set; } = new List<Training>();

        public Address Address
        {
            get;
            set;
        }
    }
    class Trainee
    {
        public Trainer Trainer { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();

        public Address Address
        {
            get;
            set;
        }
    }
    class Training
    {

        public Trainer Trainer { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();

        public Course Course { get; set; }

        public string GetTrainingOrgName()
        {
            //this->trainer->org->name
            return Trainer.Organization.Name;

        }

        public int GetNoOfTrainees()
        {
            //int noOfTrainees = 0;
            //noOfTrainees = Trainees.Count;
            //return noOfTrainees;
            return Trainees.Count;
        }
        public int GetTrainingDuration()
        {
            int trainingDuration = 0;

            // for each module in a course
            foreach (Module module in Course.Modules)
            {
                // for each unit in a module
                foreach (Unit unit in module.Units)
                {
                    trainingDuration += unit.Duration;
                }
            }

            return trainingDuration;
        }
    }
    class Course
    {
        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<Module> Modules { get; set; } = new List<Module>();
    }
    class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
    }
    class Unit
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
    class Topic
    {
        public string Name { get; set; }
    }
}

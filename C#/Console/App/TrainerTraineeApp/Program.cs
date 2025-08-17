namespace TrainerTraineeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Training training = new Training();//only this object wil give an error and now all the other classes shd have objects
            Trainer trainer = new Trainer();
            Organization organization = new Organization();
            //in memory all the above objects are independent and need to be connected

            organization.Name = "EdForce";

            training.Trainer = trainer;//connection between training and trainer
            trainer.Organization = organization;//connection between trainer and organization

            Console.WriteLine($"The Organization is:{training.GetTrainingOrgName()}");//uses

            Trainee t1= new Trainee();
            Trainee t2 = new Trainee();
            Trainee t3 = new Trainee();// again independent so make a relation

            training.Trainees.Add( t1);
            training.Trainees.Add( t2);
            training.Trainees.Add( t3);

            Console.WriteLine($"Trainees Count:{training.GetNoOfTrainees()}");

            Course course = new Course();
            training.Course = course;//course object addresss is stored

            Module m1 = new Module();
            Module m2 = new Module();

            course.Modules.Add( m1);
            course.Modules.Add( m2);

            Unit u1= new Unit();
            u1.Duration = 60;
            Unit u2 = new Unit();
            u2.Duration = 30;
            Unit u3 = new Unit();
            u3.Duration = 30;
            Unit u4 = new Unit();
            u4.Duration = 30;

            m1.units.Add( u1);
            m1.units.Add( u2);

            m2.units.Add( u3);
            m2.units.Add(u4);


            Console.WriteLine($"Training Duration: {training.GetTrainingDuration()}");
        }
    }
    class Organization
    {
        public string Name { get; set; }
    }
    class Trainer
    {
        public Organization Organization { get; set; }//1 to 1 
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();//1 to many relationship
    }
    class Trainee
    {
       public Trainer Trainer { get; set; } //birectional relationship
       public List<Trainer> Trainers { get; set; } = new List<Trainer>();
       public List<Training> Trainings { get; set; } = new List<Training>(); // list of trainings


    }

    class Training
    {
        public Trainer Trainer { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public Course Course { get; set; }//basiclly null and the course needs to be created
        public string GetTrainingOrgName()
        {
            //this->trainer->org->name
            //training has an object called trainer souse that object
            return Trainer.Organization.Name; //instance of classes 
        }
        public int GetNoOfTrainees()
        {
            
            return Trainees.Count;
        }
        
        public int GetTrainingDuration()
        {
            int trainingDuration = 0;
            // for each module in a course

            foreach (Module module in Course.Modules)
            {
            //for each unit in a module
            
                foreach (Unit unit in module.units)
                {
                    trainingDuration+= unit.Duration;//till this will give a null value exception

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
        public List<Unit> units { get; set; }= new List<Unit>();
    }

    class Unit
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; }=new List<Topic>();
    }
    class Topic
    {  
        public string Name {  get; set; }

    }
}

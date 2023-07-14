namespace MediatorWithoutMediatr.Entities
{
    public class Course : BaseEntity
    {
        public Course(string name, string description, DateTime initialDate)
        {
            Name = name;
            Description = description;
            InitialDate = initialDate;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }
        public DateTime InitialDate { get; private set; }
    }
}

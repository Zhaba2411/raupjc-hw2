namespace Task1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {

            if (!(obj is Student)) return false;
            Student s = (Student) obj;
            return Name.Equals(s.Name) && Jmbag.Equals(s.Jmbag);
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode() ^ Name.GetHashCode();
        }

        public static bool operator ==(Student obj1, Student obj2)
        {
            return (obj1.Name == obj2.Name && obj1.Jmbag == obj2.Jmbag);
        }

        public static bool operator !=(Student obj1, Student obj2)
        {
            return !(obj1.Name == obj2.Name && obj1.Jmbag == obj2.Jmbag);
        }
    }
}
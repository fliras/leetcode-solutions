namespace oxente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        static string GetKindOfPerson(Person p) => p switch
        {
            { Age: <= 12 } => "Child",
            { Age: <= 18 } => "Teenager",
            _ => "teu cu"
        };
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

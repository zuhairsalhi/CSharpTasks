namespace Task09.App
{
    public abstract class Shape
    {
        public string Name { get; set; }

        protected Shape(string name)
        {
            Name = name;
        }

        public abstract double CalculateArea();
    }
}

namespace lab2.Core.Types
{
    public class Product
    {
        public string Name { get; }
        public int Id { get; }

        public Product(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj is Product other)
            {
                return other.GetHashCode() == GetHashCode();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name}({Id})";
        }
    }
}

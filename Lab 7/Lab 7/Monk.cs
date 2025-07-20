using System.Numerics;
namespace Lab_7
{
    public class Monk : Enemy
    {
        public int manaPower;
        public Monk(Vector3 position, int health) : base(position, health) { }

        public override void Attack()
        {
            Console.WriteLine($"Monk uses {manaPower} mana to attack!");
        }
    }
}

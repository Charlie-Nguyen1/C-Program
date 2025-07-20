using System.Numerics;
namespace Lab_7
{
    public class Monster : Enemy
    {
        public int firePower;
        public Monster(Vector3 position, int health) : base(position, health) { }
        public override void Attack()
        {
            Console.WriteLine($"Monster attacks with {firePower} damage !");
        }
    }

}

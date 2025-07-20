using System.Numerics;

namespace Lab_7
{
    public abstract class Enemy
    {
        public Vector3 Position;
        public int Health;

        public Enemy(Vector3 position, int health)
        {
            Position = position;
            Health = health;
        }
        public abstract void Attack();
        public override string ToString()
        {
            return $"Enemy at position {Position} with health {Health}";
        }
    }
}

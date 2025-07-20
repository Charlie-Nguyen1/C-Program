using System.Numerics;

namespace Lab_7
{
    public class Program
    {
        static void Main(string[] args)
        {
            Enemy[] enemies = new Enemy[50];
            Random random = new Random();

            for (int i = 0; i < enemies.Length; i++)
            {
                Vector3 position = new Vector3(random.Next(0, 50), random.Next(0, 50), random.Next(0, 50));
                int health = random.Next(0, 100);

                if (random.Next(0, 2) == 0)
                {
                    enemies[i] = new Monk(position, health) { manaPower = random.Next(20, 81) };
                }
                else
                {
                    enemies[i] = new Monster(position, health) { firePower = random.Next(20, 51) };
                }
                Console.WriteLine($"Enemies created : {enemies[i]}");
            }
            Console.WriteLine("\n-----Enemies attacking! ----------");
            for (int i = 0; i < enemies.Length; i++)
            {
                Console.WriteLine($"Enemy {i + 1} at position {enemies[i].Position} with health {enemies[i].Health}");
                enemies[i].Attack();
            }
        }
    }
}

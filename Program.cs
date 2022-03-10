//1.Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. 
//    Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом. 
//    Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз. 
//    Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. 
//    Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно. 
//    Создать многопоточное приложение, моделирующее работу садовников.


using System.Threading.Tasks;
class Program
{
    private static int[,] pole;
    const int m=5;
    const int n = 2;

    static void Main()
    {


        pole = new int[n, m] { { 10, 20, 30, 40, 50 },{ 15, 25, 35, 45, 55 } };

        Thread Gardner1 = new Thread(sad1);
        Thread Gardner2 = new Thread(sad2);

        Gardner1.Start();
        Gardner2.Start();

        Gardner1.Join();
        Gardner2.Join();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(pole[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }

    private static void sad1()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (pole[i, j] >= 0)
                    pole[i, j] = -1;
                Thread.Sleep(1);
            }
        }
    }

    private static void sad2()
    {
        for (int i = m - 1; i > 0; i--)
        {
            for (int j = n - 1; j > 0; j--)
            {
                if (pole[j, i] >= 0)
                    pole[j, i] = -2;
                Thread.Sleep(1);
            }
        }
    }
}
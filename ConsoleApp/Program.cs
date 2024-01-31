namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Manager m = new Manager();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1.Show list Category");
                Console.WriteLine("2.Search category by id.");
                Console.WriteLine("3.Add category to DB");
                Console.WriteLine("4. Update category by id");
                Console.WriteLine("5. Delete category by id");
                Console.WriteLine("0. Exit.");

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0: return;
                    case 1:
                        {
                            Console.WriteLine("List category");
                            await m.ShowList();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter id:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            await m.SerachByIdAsync(id);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter Name: ");
                            string name = Console.ReadLine();
                            await m.InsertAsync(name);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter id:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Name: ");
                            string name = Console.ReadLine();
                            await m.UpdateAsync(id, name);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter id:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            await m.Delete(id);
                            break;
                        }
                }
            }
        }
    }
}

using menuList.Models;

namespace menuList{
    class Program{
        public static void Main(string[] args)
        {
            List<string> items = new List<string> {"Hii!", "Welcome!", "Exit!!"};
            Menu m = new Menu(10, 10, ConsoleColor.Blue, ConsoleColor.White, items);
            m.PressEnter += m_PressEnter;
            m.Show();

        }
        public static void m_PressEnter(object sender, ItemArgs e){
            switch(e.Current){
                case 0:
                    Console.Clear();
                    Console.WriteLine("Hii!");
                    Console.ReadLine();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Welcome!");
                    Console.ReadLine();
                    break;
                case 2:
                    e.IsExit = true;
                    break;
            }
        }
    }
}
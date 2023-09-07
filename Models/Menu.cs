namespace menuList.Models
{
    public delegate void EnterDelegate(object sender, ItemArgs e);
    public class Menu
    {
        #region variables
        public event EnterDelegate PressEnter;
        int current;
        int XPos;
        int YPos;
        List<string> menuItems;
        ConsoleColor hForeColor;
        ConsoleColor hBackColor;
        ConsoleColor foreColor;
        ConsoleColor backColor;
        #endregion

        //Constructors
        public Menu(int XPos, int YPos, ConsoleColor hForeColor, ConsoleColor hBackColor, ConsoleColor foreColor, ConsoleColor backColor, List<string> menuItems){
            PressEnter = OnPressEnter;
            current = 0;
            this.XPos = XPos;
            this.YPos = YPos;
            this.hForeColor = hForeColor;
            this.hBackColor = hBackColor;
            this.foreColor= foreColor;
            this.backColor = backColor;
            this.menuItems = menuItems;
        }
        public Menu(int XPos, int YPos, ConsoleColor hForeColor, ConsoleColor hBackColor, List<string> menuItems):this(XPos, YPos, hBackColor, hForeColor, ConsoleColor.White, ConsoleColor.Black, menuItems){
        }

        // Functionalites

        // Draw the menu
        public void Draw(){
            for(var item = 0; item < menuItems.Count; item++){
                Console.SetCursorPosition(XPos, YPos+item);
                if(item == current){
                    Console.BackgroundColor = hBackColor;
                    Console.ForegroundColor = hForeColor;
                }
                else {
                    Console.BackgroundColor = backColor;
                    Console.ForegroundColor = foreColor;
                }
                Console.Write(menuItems[item]);
            }
            Console.ResetColor();
        }
        // Create and Draw the menu
        public void Show(){
            ConsoleKeyInfo cki;
            ItemArgs e = new ItemArgs(current);
            do{
                Draw();
                cki = Console.ReadKey(true);
                switch(cki.Key){
                    case ConsoleKey.UpArrow:
                        current--;
                        if(current < 0)
                            current = menuItems.Count-1;
                        break;
                    case ConsoleKey.DownArrow:
                        current++;
                        if(current == menuItems.Count)
                            current = 0;
                        break;
                    case ConsoleKey.Enter:
                        e = new ItemArgs(current);
                        PressEnter(this, e);
                        break;
                    case ConsoleKey.Escape:
                        e.IsExit = true;
                        break;
                    case ConsoleKey.Home:
                        current = 0;
                        break;
                    case ConsoleKey.End:
                        current = menuItems.Count-1;
                        break;
                }
            }while(!e.IsExit);
        }
        private void OnPressEnter(object sender, ItemArgs e){

        }
    }
}
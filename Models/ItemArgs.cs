namespace menuList.Models
{
    public class ItemArgs : EventArgs
    {
        int current;
        public int Current
        {
            get { return current; }
            set { current = value; }
        }
        private bool isExit;
        public bool IsExit
        {
            get { return isExit; }
            set { isExit = value; }
        }
        public ItemArgs(int current){
            this.current = current;
        }
    }
}
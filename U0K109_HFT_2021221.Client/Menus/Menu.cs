namespace U0K109_HFT_2021221.Client
{
    public delegate void Clear();
    public delegate string Input();
    public delegate void Output(string s);
    public class MenuClass
    {
        public event Clear clear;
        public event Input input;
        public event Output write;
        public event Output writeline;
        public void Start(RestService rest)
        {
            write?.Invoke("Loading:");
            for (int i = 0; i < 70; i++)
            {
                write?.Invoke(">");
                System.Threading.Thread.Sleep(100);
            }
            MainMenu(rest);
        }
        public void MainMenu(RestService rest)
        {
            Create create = new Create();
            Read read = new Read();
            Update update = new Update();
            Delete delete = new Delete();
            Stat stat = new Stat();


            string choice = "";
            while (!choice.Equals("0"))
            {
                clear?.Invoke();
                writeline?.Invoke("Apple menu");
                writeline?.Invoke("");
                writeline?.Invoke("0. Quit");
                writeline?.Invoke("1. Stat");
                writeline?.Invoke("2. Create");
                writeline?.Invoke("3. Read");
                writeline?.Invoke("4. Update");
                writeline?.Invoke("5. Delete");
                writeline?.Invoke("");

                choice = input?.Invoke();
                switch (choice)
                {
                    case "0":
                        break;
                    case "1":
                        stat.Start(clear, input, write, writeline, rest);
                        break;
                    case "2":
                        create.Start(clear, input, write, writeline, rest);
                        break;
                    case "3":
                        read.Start(clear, input, write, writeline, rest);
                        break;
                    case "4":
                        update.Start(clear, input, write, writeline, rest);
                        break;
                    case "5":
                        delete.Start(clear, input, write, writeline, rest);
                        break;
                    default:
                        writeline?.Invoke("Invalid option.");
                        break;
                }
            }
        }

    }
}

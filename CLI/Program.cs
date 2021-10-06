

namespace Practise.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<int, account> accounts = new Dictionary<int, account>();
            TheMachine MyBank = new TheMachine("MyBank", "Government");
            MyBank.StartTheMachine();
        }
    }
    
}

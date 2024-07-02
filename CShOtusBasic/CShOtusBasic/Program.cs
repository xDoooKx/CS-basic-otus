
namespace CShOtusBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppState.AppInit();

            ListWorker worker = new ListWorker();

            worker.WorkWithLists();

            AppState.CloseApp();
        }
    }
}

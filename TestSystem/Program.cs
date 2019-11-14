using TestSystem.TestModule;

namespace TestSystem
{
    class Start
    {
        static void Main(string[] args)
        {
            TestManager testManager = new TestManager();
            testManager.startManualTest();
        }
    }
}

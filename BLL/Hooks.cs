using TechTalk.SpecFlow;

namespace lab_ta_homework_5.BLL
{
    [Binding]
    public static class Hooks
    {
        [BeforeScenario]
        public static void StartBrowser()
        {
            Driver.StartBrowser();
        }

        [AfterScenario]
        public static void StopBrowser()
        {
            Driver.StopBrowser();
        }
    }
}

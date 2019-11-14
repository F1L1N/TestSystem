using System;

namespace TestSystem
{
    class Config
    {
        public static string log = "log.txt";
        //public static string testFiles = System.IO.Directory.GetCurrentDirectory() + "/TestModule/tests";
        public static string testFiles = AppDomain.CurrentDomain.BaseDirectory + "tests";
        public static string defaultTestFile = testFiles + "\\test.txt";
        public static string defaultAnswerFile = testFiles + "\\answers.txt";
        public static string adminName = "Филин Павел Дмитриевич";
        public static string defaultTopic = "Основы государственного управления экономикой";
    }
}

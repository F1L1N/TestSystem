using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomobileExpertSystem.TestModule
{
    class TestManager
    {
        public TestManager()
        {

        }

        public Test initManualTest()
        {
            Console.Write("Введите ФИО: ");
            string name = Config.adminName;
            //string name = Console.ReadLine();
            Console.Write("Введите тему: ");
            string topic = Config.defaultTopic;
            //string topic = Console.ReadLine();
            Test test = new Test(name, topic);
            return test;
        }

        public void startManualTest()
        {
            Test test = initManualTest();
            QuestionManager questionManager = new QuestionManager();
            test.writeStartTime();
            QuestionDatabase handledDatabase = questionManager.manualStart();

            finishTest(test);
        }

        public void finishTest(Test test)
        {
            test.writeFinishTime();
            logTest(test);
        }

        public void logTest(Test test)
        {
            string[] logArray = Config.log.Split(".");
            string path = logArray[0] + "_" + test.name + "_" + test.startTestTime.ToString() + "." + logArray[1];
            using (StreamWriter output = File.AppendText(path))
            {
                output.WriteLine("Проходящий тест: " + test.name);
                output.WriteLine("Тема теста: " + test.topic);
                output.WriteLine("Начало теста: " + test.startTestTime);
                output.WriteLine("Конец теста: " + test.finishTestTime);
                output.WriteLine("Количество заданных вопросов: " + test.numberQuestions);
                output.WriteLine("Количество правильных вопросов: " + test.rightAnswers);
                output.WriteLine("Список вопросов с неправильным ответом: " + test.wrongAnswers.ToString());
            }
        }
    }
}

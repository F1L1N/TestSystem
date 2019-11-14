﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestSystem.TestModule
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
            Console.WriteLine(name);
            //string name = Console.ReadLine();
            Console.Write("Введите тему: ");
            string topic = Config.defaultTopic;
            Console.WriteLine(topic);
            //string topic = Console.ReadLine();
            Test test = new Test(name, topic);
            return test;
        }

        public void startManualTest()
        {
            Test test = initManualTest();
            QuestionManager questionManager = new QuestionManager();
            test.writeStartTime();
            QuestionDatabase handledDatabase = questionManager.manualStart(test);
            //questionManager.manualStart(test);
            finishTest(test, handledDatabase);
        }

        public void finishTest(Test test, QuestionDatabase database)
        {
            test.writeFinishTime();
            showResult(test, database);
            logTest(test);
        }

        public void showResult(Test test, QuestionDatabase database)
        {
            Console.WriteLine("\nТест окончен.");
            Console.WriteLine("Сдающий: " + test.name);
            Console.WriteLine("Тема: " + test.topic);
            Console.WriteLine("Начат: " + test.startTestTime);
            Console.WriteLine("Закончен: " + test.finishTestTime);
            Console.WriteLine("Вопросов в тесте: " + test.numberQuestions);
            Console.WriteLine("Правильных ответов: " + test.rightAnswers);
            if (test.numberQuestions == test.rightAnswers)
            {
                Console.WriteLine("Отлично!");
            }
            else
            {
                Console.WriteLine("Ошибки допущены в следующих вопросах: ");
                foreach (var entry in test.wrongAnswers)
                {
                    //Console.Write(entry + " ");
                    LinkedList<Question> questions = database.getQuestions();
                    LinkedListNode<Question> firstNode = questions.First;
                    for (LinkedListNode<Question> question = firstNode; question != null; question = question.Next)
                    {
                        Question node = question.Value;
                        if (node.getId() == entry)
                        {
                            Console.WriteLine();
                            node.showAnswer();
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public void logTest(Test test)
        {
            string[] logArray = Config.log.Split(".");
            string path = logArray[0] + "_" + test.name + "_" + test.startTestTime.ToString() + "." + logArray[1];
            path = path.Replace(" ", "_").Replace(":", "-");
            using (StreamWriter output = File.CreateText(path))
            {
                output.WriteLine("Проходящий тест: " + test.name);
                output.WriteLine("Тема теста: " + test.topic);
                output.WriteLine("Начало теста: " + test.startTestTime);
                output.WriteLine("Конец теста: " + test.finishTestTime);
                output.WriteLine("Количество заданных вопросов: " + test.numberQuestions);
                output.WriteLine("Количество правильных вопросов: " + test.rightAnswers);
                if (test.wrongAnswers.Count == 0)
                {
                    output.WriteLine("Список вопросов с неправильным ответом: ошибок нет.");
                }
                else
                {
                    output.Write("Список вопросов с неправильным ответом: ");
                    foreach (var entry in test.wrongAnswers)
                    {
                        output.Write(entry + " ");
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace TestSystem
{
    class Question
    {
        private int id;

        private string question;

        private char answer;

        private List<string> variants = new List<string>();
        public Question(int id, string question, List<string> variants, char answer)
        {
            this.id = id;
            this.answer = answer;
            this.question = question;
            this.variants = variants;
        }

        public char getAnswer()
        {
            return answer;
        }

        public int getId()
        {
            return id;
        }

        private string answerOnQuestion()
        {
            Console.Write("Answer: ");
            //answer = Console.ReadLine() == "y" ? true : false;
            string currentAnswer = Console.ReadLine();
            return currentAnswer;
        }

        public string show()
        {
            Console.WriteLine("\nНомер вопроса: " + id);
            Console.WriteLine(question);
            foreach (string variant in variants)
            {
                Console.WriteLine(variant);
            }
            return answerOnQuestion();
        }

        public void showAnswer()
        {
            Console.WriteLine("На вопрос: ");
            showQuestion();
            Console.Write("правильный ответ - ");
            Console.WriteLine(answer + ".");
        }
        public void showQuestion()
        {
            Console.WriteLine(question);
        }
    }
}

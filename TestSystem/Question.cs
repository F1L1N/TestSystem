﻿using System;
using System.Collections.Generic;

namespace AutomobileExpertSystem
{
    class Question
    {
        private int id;

        private string question;

        private char answer;

        private List<string> variants = new List<string>();

        public char getAnswer()
        {
            return answer;
        }

        public Question(int id, char answer, string question)
        {
            this.id = id;
            this.answer = answer;
            this.question = question;
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
            Console.WriteLine(question);
            return answerOnQuestion();
        }

        public void showAnswer()
        {
            Console.WriteLine("На вопрос: ");
            showQuestion();
            Console.Write("Вы ответили так - ");
            Console.WriteLine(answer + ".");
        }
        public void showQuestion()
        {
            Console.WriteLine(question);
        }
    }
}

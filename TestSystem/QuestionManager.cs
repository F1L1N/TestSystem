using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomobileExpertSystem
{
    class QuestionManager
    {
        private QuestionDatabase questionDatabase = new QuestionDatabase();

        public QuestionManager()
        {
            init();
        }

        private void init()
        {
            string path = Config.defaultTestFile;
            string testText = string.Empty;

            if (File.Exists(path))
            {
                testText = File.ReadAllText(path, Encoding.UTF8);
            }

            string[] questions = testText.Split("\r\n\r\n");

            foreach (string question in questions)
            {
                string[] buffer = question.Split("\r\n");
                if (buffer[0].Equals(string.Empty)) buffer.
                int id = Int32.Parse(buffer[0]);
                string questionText = buffer[1];
                List<string> variants = new List<string>();
                for (int i = 2; i < buffer.Length; i++)
                {
                    variants.Add(buffer[i]);
                }
            }
        }

        public QuestionDatabase manualStart() 
        {
            string signal;
            LinkedListNode<Question> firstNode = questionDatabase.getQuestions().First;
            for (LinkedListNode<Question> question = firstNode; question != null; question = question.Next)
            {
                signal = question.Value.show();
                while (signal == "back")
                {
                    if (question != firstNode)
                    {
                        question = question.Previous;
                    }
                    signal = question.Value.show();
                }
            } 
            answersAnalysis();
            //TODO логгирование списка вопросов
            return this.questionDatabase;
        }

        private void answersAnalysis()
        {
            List<string> tags = new List<string>();
            for (LinkedListNode<Question> question = questionDatabase.getQuestions().First; question != null; question = question.Next)
            {
                Question node = question.Value;
                
            }
            
        }
    }
}

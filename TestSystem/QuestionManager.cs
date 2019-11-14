using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestSystem.TestModule;

namespace TestSystem
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
            string answerPath = Config.defaultAnswerFile;
            string testText = string.Empty;
            string answersText = string.Empty;

            if (File.Exists(path))
            {
                testText = File.ReadAllText(path, Encoding.UTF8);
            }
            if (File.Exists(answerPath))
            {
                answersText = File.ReadAllText(answerPath, Encoding.UTF8);
            }


            string[] questions = testText.Split("\r\n\r\n");
            string[] answers = answersText.Split("\r\n");
            Dictionary<int, char> answersBase = new Dictionary<int, char>();
            foreach (string answer in answers)
            {
                string[] entry = answer.Split("-");
                answersBase.Add(Int32.Parse(entry[0]), Convert.ToChar(entry[1]));
            }

            int position = 0;
            foreach (string question in questions)
            {
                string[] buffer = question.Split("\r\n");
                if (buffer[0].Equals(string.Empty))
                {
                    position++;
                }
                int id = Int32.Parse(buffer[position]);
                position++;
                string questionText = buffer[position];
                position++;
                List<string> variants = new List<string>();
                for (int i = position; i < buffer.Length; i++)
                {
                    variants.Add(buffer[i]);
                }
                position = 0;
                questionDatabase.Add(new Question(id, questionText, variants, answersBase.GetValueOrDefault(id)));
            }
        }

        public QuestionDatabase manualStart(Test test) 
        {
            string signal;
            LinkedListNode<Question> firstNode = questionDatabase.getQuestions().First;
            Dictionary<int, char> answers = new Dictionary<int, char>();
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
                answers.Add(question.Value.getId() ,Convert.ToChar(signal));
            } 
            answersAnalysis(test, answers);
            return questionDatabase;
        }

        private void answersAnalysis(Test test, Dictionary<int, char> answers)
        {
            int numberQuestions = questionDatabase.getQuestions().Count;

            int numberAnswers = answers.Count;

            int rightAnswers = 0;

            List<int> wrongAnswers = new List<int>();

            for (LinkedListNode<Question> question = questionDatabase.getQuestions().First; question != null; question = question.Next)
            {
                Question node = question.Value;

                char currentNodeAnswer = node.getAnswer();

                int questionId = node.getId();

                if (currentNodeAnswer.Equals(answers[questionId]))
                {
                    rightAnswers++;
                }
                else
                {
                    wrongAnswers.Add(questionId);
                }
                

            }

            test.numberAnswers = numberAnswers;
            test.numberQuestions = numberQuestions;
            test.rightAnswers = rightAnswers;
            test.wrongAnswers = wrongAnswers;
            
            
        }
    }
}

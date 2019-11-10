using System;
using System.Collections.Generic;
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
            int i = 1;
            questionDatabase.Add(new Question(i, 'б', "Управление - это: ")); i++;
            questionDatabase.Add(new Question(i, 'б', "Управление - это: ")); i++;
            questionDatabase.Add(new Question(i, 'б', "Управление - это: ")); i++;
            questionDatabase.Add(new Question(i, 'б', "Управление - это: ")); i++;
            questionDatabase.Add(new Question(i, 'б', "Управление - это: ")); i++;
            questionDatabase.Add(new Question(i, 'б', "Управление - это: ")); i++;
            questionDatabase.Add(new Question(i, 'б', "Управление - это: ")); i++;
            questionDatabase.Add(new Question(i, 'б', "Управление - это: ")); i++;
            questionDatabase.Add(new Question(i, 'б', "Управление - это: ")); i++;
            questionDatabase.Add(new Question(i, 'б', "Управление - это: ")); i++;
        }

        public QuestionDatabase autoStart()
        {
            LinkedListNode<Question> firstNode = questionDatabase.getQuestions().First;
            for (LinkedListNode<Question> question = firstNode; question != null; question = question.Next)
            {
                question.Value.show();
            }
            return this.questionDatabase;
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

using System;
using System.Collections.Generic;
using System.IO;

namespace BodgeBuzz.Trivia
{
    public class TriviaManager
    {
        private const int NumberOfQuestions = 100;

        private readonly HashSet<int> _usedTrivia;
        private int _currentTrivia;
        private static Random _random;
        private int _newIndex;
        private string[] _triviaFile;

        //private List<TriviaItem> answerCollection; idk if I'm going to do a class or just read txt files


        public TriviaManager()
        {
            _usedTrivia = new HashSet<int>();
            _currentTrivia = -1;
            _random = new Random();
        }

        private void VoidTrivia(int index)
        {
            _usedTrivia.Add(index);
        }

        public string[] PresentTrivia()
        {
            

            do
            {
                _newIndex = _random.Next(0, NumberOfQuestions);
            } while (_usedTrivia.Contains(_newIndex));

            string path = Directory.GetCurrentDirectory() + "Trivia" + _newIndex.ToString();
            _triviaFile = System.IO.File.ReadAllLines(@path);

            _usedTrivia.Add(_newIndex);

            return _triviaFile; //TODO
        }
    }
}
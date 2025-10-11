using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _isComplete;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public abstract void RecordEvent();
        public abstract bool IsComplete();
        
        public virtual string GetDetailsString()
        {
            string status = _isComplete ? "[X]" : "[ ]";
            return $"{status} {_name} ({_description})";
        }

        public abstract string GetStringRepresentation();

        public virtual int GetPoints() => _points;
        public string GetName() => _name;
    }
}
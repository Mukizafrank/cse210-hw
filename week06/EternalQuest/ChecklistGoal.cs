namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus) 
            : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) 
            : base(name, description, points)
        {
            _amountCompleted = amountCompleted;
            _target = target;
            _bonus = bonus;
            _isComplete = (amountCompleted >= target);
        }

        public override void RecordEvent()
        {
            if (!_isComplete)
            {
                _amountCompleted++;
                if (_amountCompleted >= _target)
                {
                    _isComplete = true;
                }
            }
        }

        public override bool IsComplete() => _isComplete;

        public override int GetPoints()
        {
            if (_isComplete && _amountCompleted == _target)
            {
                return _points + _bonus;
            }
            return _points;
        }

        public override string GetDetailsString()
        {
            string status = _isComplete ? "[X]" : "[ ]";
            return $"{status} {_name} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
        }

        public int GetAmountCompleted() => _amountCompleted;
        public int GetTarget() => _target;
        public int GetBonus() => _bonus;
    }
}
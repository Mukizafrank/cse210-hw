namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) 
            : base(name, description, points) { }

        public override void RecordEvent()
        {
            // Eternal goals never complete, just give points each time
        }

        public override bool IsComplete() => false; // Never complete

        public override string GetDetailsString()
        {
            return $"[∞] {_name} ({_description})";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_name},{_description},{_points}";
        }
    }
}
using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Uses the base class method to get student name
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}

class Student
{ 
    private int _age;

    private string _name;

    private Dictionary<string, int> _grades = new Dictionary<string, int>();

    public Student(int age, string name)
    {
        _age = age;
        _name = name;
    }

    public override string ToString()
    {
        return $"student {_name} ({_age})";
    }

    /// <summary>
    /// Public method to set a grade for a subject.
    /// </summary>
    public void SetGrade(string subject, int grade)
    {
        // and -> &&
        // or -> ||
        if (grade < 0 || grade > 100)
        {
            throw new Exception("Invalid grade");
        }

        _grades[subject] = grade;
        if (_grades.TryGetValue("key", out grade))
        {
            
        }
    }

    private double GetAverageGrade()
    {
        double sum = 0;
        foreach (var value in _grades.Values)
        {
            sum += value;
        }

        return sum / _grades.Count;
    }
}
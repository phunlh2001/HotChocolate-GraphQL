using LearnChocolate.Schema.Queries.Base;

namespace LearnChocolate.Schema.Queries;

public class StudentType : PersonType
{
    public double GPA { get; set; }
}

using LearnChocolate.Schema.Base;

namespace LearnChocolate.Schema;

public class StudentType : PersonType
{
    public double GPA { get; set; }
}

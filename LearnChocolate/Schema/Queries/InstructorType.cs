using LearnChocolate.Schema.Queries.Base;

namespace LearnChocolate.Schema.Queries;

public class InstructorType : PersonType
{
    public double Salary { get; set; }
}

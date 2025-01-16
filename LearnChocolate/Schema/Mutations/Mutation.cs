using HotChocolate.Subscriptions;
using LearnChocolate.Subscriptions;

namespace LearnChocolate.Schema.Mutations;

public class Mutation
{
    private readonly List<CourseResult> _courses;
    public Mutation()
    {
        _courses = [];
    }

    public async Task<CourseResult> CreateCourse(CourseInputType input, [Service] ITopicEventSender sender)
    {
        var course = new CourseResult
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            Subject = input.Subject,
            InstructorId = input.InstructorId
        };

        _courses.Add(course);
        await sender.SendAsync(nameof(Subscription.CourseCreated), course);

        return course;
    }

    public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType input, [Service] ITopicEventSender sender)
    {
        var course = _courses.FirstOrDefault(c => c.Id == id) ?? throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));

        course.Name = input.Name;
        course.Subject = input.Subject;
        course.InstructorId = input.InstructorId;

        var updateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
        await sender.SendAsync(updateCourseTopic, course);

        return course;
    }

    public bool DeleteCourse(Guid id)
    {
        return _courses.RemoveAll(c => c.Id == id) >= 1;
    }
}

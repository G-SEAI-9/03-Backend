public class Course
{
    public required string Title { get; set; }
    public required string Instructor { get; set; }
}

public interface ICourseCatalog
{
    IReadOnlyCollection<Course> ListCourse();
}

public class CourseCatalog : ICourseCatalog
{
    private readonly List<Course> _course = [];

    public IReadOnlyCollection<Course> ListCourse()
    {
        return _course.AsReadOnly();
    }
}

public class CourseDB : ICourseCatalog
{
    //    TODO: connection to db
    public IReadOnlyCollection<Course> ListCourse()
    {
        throw new NotImplementedException();
    }
}

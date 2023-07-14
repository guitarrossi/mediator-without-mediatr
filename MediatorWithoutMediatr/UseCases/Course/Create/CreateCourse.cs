using FluentValidation;
using MediatorWithoutMediatr.Commom;
using MediatorWithoutMediatr.Interfaces;
using MediatorWithoutMediatr.Mapper;

namespace MediatorWithoutMediatr.UseCases.Course.Create
{
    public record CreateCourse(string Name, string Description, DateTime InitialDate)
    {
    }

    public class CourseValidator : AbstractValidator<CreateCourse>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name must not be empty");

            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("Description must not be empty");
        }
    }

    public class CreateCourseHandler
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<Response> Handle(CreateCourse createCourse, CancellationToken ct)
        {
            var course = createCourse.MapToCourse();

            _courseRepository.Add(course);

            return Task.FromResult(new Response(course));
        }
    }
}

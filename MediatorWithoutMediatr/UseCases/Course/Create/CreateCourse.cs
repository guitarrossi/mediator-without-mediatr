using FluentValidation;
using MediatorWithoutMediatr.Commom;
using MediatorWithoutMediatr.Interfaces;
using MediatorWithoutMediatr.Mapper;
using MediatorWithoutMediatr.Notifications.Base;
using MediatorWithoutMediatr.Notifications.User;
using MediatorWithoutMediatr.UseCases.Base;

namespace MediatorWithoutMediatr.UseCases.Course.Create
{
    public record CreateCourse(string Name, string Description, DateTime InitialDate) : IUseCase
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

    public class CreateCourseHandler : IHandler<CreateCourse>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Response> Handle(CreateCourse request, CancellationToken cancellationToken)
        {
            var course = request.MapToCourse();

            _courseRepository.Add(course);

            return new Response(course);
        }

    }
}

using App.Core.Interfaces;
using App.Core.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Apps.Student.Command
{
    public class UpdateStudentByIdCommand : IRequest<string>
    {
        public StudentDto Student { get; set; }
        public UpdateStudentByIdCommand(StudentDto student)
        {
            Student = student;
        }
    }


    public class UpdateStudentByIdCommandHandler : IRequestHandler<UpdateStudentByIdCommand, string>
    {

        private readonly IAppDbContext _appDbContext;

        public UpdateStudentByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<string> Handle(UpdateStudentByIdCommand request, CancellationToken cancellationToken)
        {
            var id = request.Student.StudentId;

            var student = await _appDbContext.Set<Domain.Student>().FindAsync(id);

            if (student == null)
            {
                return "Cannot Found Student";
            }

            student.FirstName = request.Student.FirstName;
            student.LastName = request.Student.LastName;
            student.DateOfBith = request.Student.DateOfBith;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return "Successfully Updated";
        }
    }



}

using App.Core.Interfaces;
using App.Core.Models;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Apps.Student.Query
{
    public class GetStudentByIdQuery : IRequest<StudentDto>
    {
        public readonly int Id;

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }

    }


    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {

        private readonly IAppDbContext _appDbContext;

        public GetStudentByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = _appDbContext.Set<Domain.Student>().Find(request.Id);
            return student.Adapt<StudentDto>();
        }
    }
}

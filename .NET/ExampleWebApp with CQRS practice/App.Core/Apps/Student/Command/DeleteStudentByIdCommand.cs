using App.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Apps.Student.Command
{
    public class DeleteStudentByIdCommand : IRequest<string>
    {
        public int Id { get; set; }
        public DeleteStudentByIdCommand(int id)
        {
            Id = id;
        }
    }


    public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, string>
    {

        private readonly IAppDbContext _appDbContext;

        public DeleteStudentByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(DeleteStudentByIdCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var student = await _appDbContext.Set<Domain.Student>().FindAsync(id);

            _appDbContext.Set<Domain.Student>().Remove(student);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            
            return "Successfully Deleted";
        }
    }




}

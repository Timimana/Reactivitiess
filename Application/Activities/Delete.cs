using System.Runtime.InteropServices;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.id);

                if (activity == null) return null;

                _context.Remove(activity);

               var result = await _context.SaveChangesAsync() > 0;

               if (!result) Result<Unit>.Failure("Failed to delete the activity");

               return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
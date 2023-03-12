using DataStore;
using DataStore.Models;
using MediatR;
using MediatrWebAPI.Queries;
using Microsoft.EntityFrameworkCore;

namespace MediatrWebAPI.Handlers;

public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
{
    private readonly NorthwindContext _context;

    public GetOrdersHandler(NorthwindContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            cancellationToken.ThrowIfCancellationRequested();

        return await _context.Orders
            .Take(10)
            .ToListAsync(); 
    }
}

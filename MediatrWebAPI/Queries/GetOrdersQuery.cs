using DataStore.Models;
using MediatR;

namespace MediatrWebAPI.Queries;

public record GetOrdersQuery(): IRequest<IEnumerable<Order>>;  


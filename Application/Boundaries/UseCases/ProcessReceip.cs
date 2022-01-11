using Domain.Receip;
using MediatR;

namespace Application.Boundaries.UseCases;

public class ProcessReceip : IRequest<Receip>
{
    public string TextReceip { get; set; }
    public Guid ClientId { get; set; }
}
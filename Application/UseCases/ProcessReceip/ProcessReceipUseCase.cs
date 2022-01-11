using Domain.Receip;
using MediatR;

namespace Application.UseCases.ProcessReceip;

public class ProcessReceipUseCase : IRequestHandler<Boundaries.UseCases.ProcessReceip, Receip>
{
    private readonly IReceipRepository _repository;

    public ProcessReceipUseCase(IReceipRepository repository)
    {
        _repository = repository;
    }

    public async Task<Receip> Handle(Boundaries.UseCases.ProcessReceip request, CancellationToken cancellationToken)
    {
        var receip = new Receip(request.ClientId, request.TextReceip);

        await _repository.CreateAsync(receip);

        return receip;
    }
}
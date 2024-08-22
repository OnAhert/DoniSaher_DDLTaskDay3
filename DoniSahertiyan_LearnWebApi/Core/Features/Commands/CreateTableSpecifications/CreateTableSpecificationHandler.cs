using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Commands.CreateTableSpecification
{
    public class CreateTableSpecificationHandler : IRequestHandler<CreateTableSpecificationCommand, CreateTableSpecificationResponse>
    {
        private readonly ITableSpecificationRepository _tableSpecificationRepository;

        public CreateTableSpecificationHandler(ITableSpecificationRepository tableSpecificationRepository)
        {
            _tableSpecificationRepository = tableSpecificationRepository;
        }

        public async Task<CreateTableSpecificationResponse> Handle(CreateTableSpecificationCommand command, CancellationToken cancellationToken)
        {
            var tableSpecification = new TableSpecification
            {
                TableId = Guid.NewGuid(), // Assuming TableId is generated on creation
                TableNumber = command.TableNumber,
                ChairNumber = command.ChairNumber,
                TablePic = command.TablePic,
                TableType = command.TableType
            };

            await _tableSpecificationRepository.AddAsync(tableSpecification);
            await _tableSpecificationRepository.SaveChangesAsync();

            var response = new CreateTableSpecificationResponse
            {
                TableId = tableSpecification.TableId,
                TableNumber = tableSpecification.TableNumber,
                ChairNumber = tableSpecification.ChairNumber,
                TablePic = tableSpecification.TablePic,
                TableType = tableSpecification.TableType
            };

            return response;
        }
    }
}

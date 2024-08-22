using MediatR;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Commands.UpdateTableSpecification
{
    public class UpdateTableSpecificationHandler : IRequestHandler<UpdateTableSpecificationCommand, UpdateTableSpecificationResponse>
    {
        private readonly ITableSpecificationRepository _tableSpecificationRepository;

        public UpdateTableSpecificationHandler(ITableSpecificationRepository tableSpecificationRepository)
        {
            _tableSpecificationRepository = tableSpecificationRepository;
        }

        public async Task<UpdateTableSpecificationResponse> Handle(UpdateTableSpecificationCommand command, CancellationToken cancellationToken)
        {
            var tableSpecification = await _tableSpecificationRepository.GetByIdAsync(command.TableId);

            if (tableSpecification == null)
            {
                // Handle not found case (e.g., return null or throw an exception)
                return null;
            }

            tableSpecification.TableNumber = command.TableNumber;
            tableSpecification.ChairNumber = command.ChairNumber;
            tableSpecification.TablePic = command.TablePic;
            tableSpecification.TableType = command.TableType;

            await _tableSpecificationRepository.UpdateAsync(tableSpecification);
            await _tableSpecificationRepository.SaveChangesAsync();

            var response = new UpdateTableSpecificationResponse
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

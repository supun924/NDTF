using MediatR;
using NDTFAPI.Application.Features.Fines.DTOs;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Fines.Queries.GetFineById
{
    public class GetFineByIdQueryHandler : IRequestHandler<GetFineByIdQuery, FineDetailsDto>
    {
        private readonly IFineRepository _repository;

        public GetFineByIdQueryHandler(
            IFineRepository repository)
        {
            _repository = repository;
        }

        public async Task<FineDetailsDto> Handle(
            GetFineByIdQuery request,
            CancellationToken cancellationToken)
        {
            var fine = await _repository
                .GetByIdWithDetailsAsync(request.FineId);

            if (fine == null)
                throw new Exception("Fine not found");

            return new FineDetailsDto
            {
                FineId = fine.FineId,
                FineReference = fine.FineReference,
                DriverName = $"{fine.Driver.FirstName} {fine.Driver.LastName}",
                VehicleNumber = fine.Vehicle.RegistrationNumber,
                OfficerName = fine.Officer.Username,
                TotalAmount = fine.TotalAmount,
                Status = fine.Status,
                IssueDate = fine.IssueDate,

                Violations = fine.FineViolations
                    .Select(v => new FineViolationDto
                    {
                        ViolationId = v.ViolationId,
                        ViolationCode = v.Violation.ViolationCode,
                        ViolationName = v.Violation.ViolationName,
                        Amount = v.Amount
                    }).ToList()
            };
        }
    }
}

using MediatR;
using NDTFAPI.Application.Features.Drivers.DTOs;
using NDTFAPI.Application.Features.Fines.DTOs;
using NDTFAPI.Application.Interfaces;
using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Fines.Queries.GetFinesQuery
{
    public class GetFinesQueryHandler : IRequestHandler<GetFinesQuery,List<FineListDto>>
    {
        private readonly IFineRepository _repository;

        public GetFinesQueryHandler(
            IFineRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FineListDto>> Handle(
            GetFinesQuery request,
            CancellationToken cancellationToken)
        {
            var fines = await _repository.SearchAsync(
                request.Search,
                request.PageNumber,
                request.PageSize);

            var total = await _repository.CountAsync(
                request.Search);

            return fines.Select(x => new FineListDto
            {
                FineId = x.FineId,
                FineReference = x.FineReference,
                DriverName =
                            $"{x.Driver.FirstName} {x.Driver.LastName}",
                VehicleNumber =
                            x.Vehicle.RegistrationNumber,
                TotalAmount = x.TotalAmount,
                Status = x.Status,
                IssueDate = x.IssueDate
            }).ToList();
        }
    }
}

using MediatR;
using NDTFAPI.Application.Common.Helpers;
using NDTFAPI.Application.Interfaces;
using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Fines.Commands.IssueFine
{
    internal class IssueFineHandler : IRequestHandler<IssueFineCommand, int>
    {
        private readonly IFineRepository _fineRepository;
        private readonly IFineViolationRepository _fineViolationRepository;
        private readonly IViolationRepository _violationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public IssueFineHandler(
            IFineRepository fineRepository,
            IFineViolationRepository fineViolationRepository,
            IViolationRepository violationRepository,
            IUnitOfWork unitOfWork)
        {
            _fineRepository = fineRepository;
            _fineViolationRepository = fineViolationRepository;
            _violationRepository = violationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            IssueFineCommand request,
            CancellationToken cancellationToken)
        {
            var violations =
                await _violationRepository
                    .GetByIdsAsync(request.ViolationIds);

            decimal totalAmount =
                violations.Sum(x => x.FineAmount);

            var fine = new Fine
            {
                FineReference =
                    FineReferenceGenerator.Generate(),

                OfficerId = request.OfficerId,

                DriverId = request.DriverId,

                VehicleId = request.VehicleId,

                StationId = request.StationId,

                TotalAmount = totalAmount,

                Status = "PENDING",

                IssueDate = DateTime.UtcNow,

                Notes = request.Notes
            };

            await _fineRepository.AddAsync(fine);

            await _unitOfWork.SaveChangesAsync();

            foreach (var violation in violations)
            {
                await _fineViolationRepository.AddAsync(
                    new FineViolation
                    {
                        FineId = fine.FineId,
                        ViolationId = violation.ViolationId,
                        Amount = violation.FineAmount
                    });
            }

            await _unitOfWork.SaveChangesAsync();

            return fine.FineId;
        }
    }
}

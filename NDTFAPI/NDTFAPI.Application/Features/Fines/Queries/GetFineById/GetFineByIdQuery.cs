using MediatR;
using NDTFAPI.Application.Features.Fines.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Fines.Queries.GetFineById
{
    public record GetFineByIdQuery(int FineId)
    : IRequest<FineDetailsDto>;
}

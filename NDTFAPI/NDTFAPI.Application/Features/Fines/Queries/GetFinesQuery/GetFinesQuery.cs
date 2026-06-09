using MediatR;
using NDTFAPI.Application.Features.Fines.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Fines.Queries.GetFinesQuery
{

    public record GetFinesQuery(
        string? Search,
        int PageNumber = 1,
        int PageSize = 10)
        : IRequest<List<FineListDto>>;
}

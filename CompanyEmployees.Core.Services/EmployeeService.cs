using AutoMapper;
using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Services.Abstractions;
using LoggingService;

namespace CompanyEmployees.Core.Services;

public class EmployeeService: IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }
}
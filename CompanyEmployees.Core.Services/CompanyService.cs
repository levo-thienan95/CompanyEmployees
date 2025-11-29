using AutoMapper;
using CompanyEmployees.Core.Domain.Entities;
using CompanyEmployees.Core.Domain.Exceptions;
using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Services.Abstractions;
using LoggingService;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Core.Services;

public class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
    {
        _loggerManager.LogInformation("Getting all companies");
        var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);

        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        return companiesDto;
    }

    public CompanyDto GetCompany(Guid companyId, bool trackChanges)
    {
        _loggerManager.LogInformation("Getting company");
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        
        if (company is null)
            throw new CompanyNotFoundException(companyId);
        
        var companyDto = _mapper.Map<CompanyDto>(company); 
        return companyDto;
    }
}
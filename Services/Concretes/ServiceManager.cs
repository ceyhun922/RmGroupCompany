using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RmWebApi.Context;
using RmWebApi.DTOs.ServiceDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class ServiceManager : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly RmContext _context;

    public ServiceManager(IServiceRepository serviceRepository, IMapper mapper, RmContext context)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<ResultServiceDto>> GetAllAsync()
    {
        var entities = await _serviceRepository.GetAllAsync();
        return _mapper.Map<List<ResultServiceDto>>(entities);
    }

    public async Task<ResultServiceDto> GetByIdAsync(int id)
    {
        var entity = await _serviceRepository.GetByIdAsync(id);
        return _mapper.Map<ResultServiceDto>(entity);
    }

    public async Task CreateAsync(CreateServiceDto dto)
    {
        var entity = new RmWebApi.Entities.Service
        {
            Title = dto.Title,
            Slug = dto.Slug,
            Description = dto.Description,
            IconName = dto.IconName,
            ImageUrl = dto.ImageUrl,
            Images = new List<string>(),
            DisplayOrder = dto.DisplayOrder
        };
        await _context.Services.AddAsync(entity);
        await _context.SaveChangesAsync();

        if (dto.Items != null)
        {
            for (int i = 0; i < dto.Items.Count; i++)
            {
                _context.ServiceItems.Add(new ServiceItem
                {
                    Name = dto.Items[i].Name,
                    ImageUrl = dto.Items[i].ImageUrl,
                    DisplayOrder = i,
                    ServiceId = entity.Id
                });
            }
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(UpdateServiceDto dto)
    {
        var entity = await _context.Services.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == dto.Id);
        if (entity == null) return;

        entity.Title = dto.Title;
        entity.Slug = dto.Slug;
        entity.Description = dto.Description;
        entity.IconName = dto.IconName;
        entity.ImageUrl = dto.ImageUrl;
        entity.DisplayOrder = dto.DisplayOrder;

        _context.ServiceItems.RemoveRange(entity.Items);
        if (dto.Items != null)
        {
            for (int i = 0; i < dto.Items.Count; i++)
            {
                _context.ServiceItems.Add(new ServiceItem
                {
                    Name = dto.Items[i].Name,
                    ImageUrl = dto.Items[i].ImageUrl,
                    DisplayOrder = i,
                    ServiceId = entity.Id
                });
            }
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Services.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id);
        if (entity == null) return;
        _context.ServiceItems.RemoveRange(entity.Items);
        _context.Services.Remove(entity);
        await _context.SaveChangesAsync();
    }
}

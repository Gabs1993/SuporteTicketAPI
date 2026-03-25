using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITicketService
    {
        Task<PagedResultDto<TicketDto>> GetAllAsync(int page, int pageSize);
        Task<TicketDto?> GetByIdAsync(Guid id);
        Task<TicketDto> CreateAsync(CreateTicketDto dto);
        Task UpdateStatusAsync(Guid id);
        Task UpdateAsync(Guid id, UpdateTicketDto dto);
        Task DeleteAsync(Guid id);
        
    }
}

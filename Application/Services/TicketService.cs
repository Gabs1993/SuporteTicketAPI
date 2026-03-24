using Application.DTOs;
using Application.Interfaces;
using Application.Mappins;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResultDto<TicketDto>> GetAllAsync(int page, int pageSize)
        {
            var (data, totalItems) = await _repository.GetPagedAsync(page, pageSize);

            return new PagedResultDto<TicketDto>
            {
                Data = data.Select(TicketMapping.ToDto),
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<TicketDto?> GetByIdAsync(Guid id)
        {
            var ticket = await _repository.GetByIdAsync(id);

            if (ticket == null)
                return null;

            return TicketMapping.ToDto(ticket);
        }

        public async Task<TicketDto> CreateAsync(CreateTicketDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Titulo))
                throw new Exception("Título é obrigatório");

            var ticket = new Ticket(dto.Titulo, dto.Descricao);

            await _repository.AddAsync(ticket);

            return TicketMapping.ToDto(ticket);
        }

        public async Task UpdateStatusAsync(Guid id)
        {
            var ticket = await _repository.GetByIdAsync(id);

            if (ticket == null)
                throw new Exception("Ticket não encontrado");

            ticket.MarkAsDone();

            await _repository.UpdateAsync(ticket);
        }

        public async Task DeleteAsync(Guid id)
        {
            var ticket = await _repository.GetByIdAsync(id);

            if (ticket == null)
                throw new Exception("Ticket não encontrado");

            await _repository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Guid id, UpdateTicketDto dto)
        {
            var ticket = await _repository.GetByIdAsync(id);

            if (ticket == null)
                throw new Exception("Ticket não encontrado");

            ticket.Titulo = dto.Titulo;
            ticket.Descricao = dto.Descricao;

            await _repository.UpdateAsync(ticket);
        }

        public async Task MarkAsInProgressAsync(Guid id)
        {
            var ticket = await _repository.GetByIdAsync(id);

            if (ticket == null)
                throw new Exception("Ticket não encontrado");

            ticket.MarkAsInProgress();

            await _repository.UpdateAsync(ticket);
        }
    }
}

using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappins
{
    public static class TicketMapping
    {
        public static TicketDto ToDto(Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                Titulo = ticket.Titulo,
                Descricao = ticket.Descricao,
                Status = ticket.Status,
                DataCriada = ticket.DataCriada
            };
        }
    }
}

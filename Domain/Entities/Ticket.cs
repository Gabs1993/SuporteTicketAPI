using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public TicketStatus Status { get; set; }

        public DateTime DataCriada { get; set; }

        protected Ticket() { }

        public Ticket(string title, string description)
        {
            Titulo = title;
            Descricao = description;
            Status = TicketStatus.Open;
            DataCriada = DateTime.UtcNow;
        }

        public void MarkAsDone()
        {
            if (Status == TicketStatus.Done)
                throw new Exception("Ticket já está concluído");

            Status = TicketStatus.Done;
        }

        public void UpdateStatus(TicketStatus newStatus)
        {
            if (Status == TicketStatus.Done)
                throw new Exception("Ticket já está concluído");

            
            if (newStatus < Status)
                throw new Exception("Não é permitido voltar o status");

            Status = newStatus;
        }

    }
}

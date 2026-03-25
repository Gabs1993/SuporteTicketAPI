using Domain.Entities;
using FluentAssertions;


namespace SuporteTicketApiTests.Tests
{
    public class TicketTests
    {
        [Fact]
        public void Should_Create_Ticket_With_Status_Open()
        {
            var ticket = new Ticket("Teste", "Descrição");

            ticket.Status.Should().Be(TicketStatus.Open);
        }

        [Fact]
        public void Should_Mark_As_Done()
        {
            var ticket = new Ticket("Teste", "Descrição");

            ticket.MarkAsDone();

            ticket.Status.Should().Be(TicketStatus.Done);
        }

        [Fact]
        public void Should_Not_Allow_Mark_As_Done_Twice()
        {
            var ticket = new Ticket("Teste", "Descrição");

            ticket.MarkAsDone();

            Action act = () => ticket.MarkAsDone();

            act.Should().Throw<Exception>()
                .WithMessage("Ticket já está concluído");
        }
    }
}

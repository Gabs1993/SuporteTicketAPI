using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Moq;


namespace SuporteTicketApiTests.ServiceTests
{
    public class TicketServiceTests
    {
        [Fact]
        public async Task Should_Return_Paged_Tickets()
        {
            // Arrange
            var mockRepo = new Mock<ITicketRepository>();

            var tickets = new List<Ticket>
        {
            new Ticket("Teste 1", "Desc 1"),
            new Ticket("Teste 2", "Desc 2")
        };

            mockRepo.Setup(r => r.GetPagedAsync(1, 10))
                .ReturnsAsync((tickets, 2));

            var service = new TicketService(mockRepo.Object);

            // Act
            var result = await service.GetAllAsync(1, 10);

            // Assert
            result.Data.Should().HaveCount(2);
            result.TotalItems.Should().Be(2);
            result.Page.Should().Be(1);
            result.PageSize.Should().Be(10);
        }
    }
}

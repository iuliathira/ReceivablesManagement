using AutoMapper;
using Moq;
using ReceivablesManagement.Business.DTOs;
using ReceivablesManagement.Business.Services;
using ReceivablesManagement.Data.Entities;
using ReceivablesManagement.Data.Repositories;
using ReceivablesManagement.Business.Mappers;
//using Microsoft.EntityFrameworkCore;


namespace ReceivablesManagement.Tests
{
    public class ReceivableServiceTests
    {
        private readonly IMapper mapper;
        private readonly Mock<IReceivablesRepository> receivablesRepositoryMock;

        public ReceivableServiceTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ReceivableProfile());
            });
            this.mapper = mapperConfiguration.CreateMapper();
            this.receivablesRepositoryMock = new Mock<IReceivablesRepository>();
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedReceivables()
        {
            // Arrange

            var receivablesServices = new ReceivablesServices(mapper, receivablesRepositoryMock.Object);

            var receivableDTOs = Data.GetDefaultReceivableDTOs();

            var receivables = receivableDTOs.Select(mapper.Map<Receivable>).ToList();

            receivablesRepositoryMock.Setup(repo => repo.ReadAllAsync()).ReturnsAsync(receivables);

            // Act
            var result = await receivablesServices.GetAllAsync();

            // Assert
            Assert.Equal(receivableDTOs.Count, result.Count);
            Assert.Equal(receivableDTOs.First(), result.First(), new ReceivableDTOEqualityComparer());
            Assert.Equal(receivableDTOs.ElementAt(1), result.ElementAt(1), new ReceivableDTOEqualityComparer());
            Assert.Equal(receivableDTOs.ElementAt(2), result.ElementAt(2), new ReceivableDTOEqualityComparer());
        }


        [Fact]
        public async Task AddAsync_ShouldReturnGeneratedGuid()
        {
            // Arrange
            var receivableDTO = new ReceivableDTO
            {
                Reference = "REF_2023_11",
                CurrencyCode = "USD",
                IssueDate = "2023-01-05",
                OpeningValue = 2100,
                PaidValue = 2100,
                DueDate = "2023-01-30",
                ClosedDate = "2023-01-25",
                Cancelled = false,
                DebtorName = "SoftVision",
                DebtorReference = "SV_REF",
                DebtorAddress1 = "Main Street 15",
                DebtorAddress2 = "Building 5, ap. 22",
                DebtorTown = "Cluj",
                DebtorState = "Romania",
                DebtorZip = "400657",
                DebtorCountryCode = "RO",
                DebtorRegistrationNumber = "RO3197676"
            };
            var receivable = mapper.Map<Receivable>(receivableDTO);
            var generatedGuid = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880773");

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Receivable>(receivableDTO)).Returns(receivable);

            var receivablesServices = new ReceivablesServices(mapperMock.Object, receivablesRepositoryMock.Object);

            receivablesRepositoryMock.Setup(repo => repo.CreateAsync(receivable)).ReturnsAsync(generatedGuid);

            // Act
            var receivableGuid = await receivablesServices.AddAsync(receivableDTO);
            var currentData = await receivablesServices.GetAllAsync();
            // Assert
            Assert.Equal(generatedGuid, receivableGuid);
        }

        [Fact]
        public async Task GetSummaryAsync_ShouldReturnSummaryWithoutFilters()
        {
            // Arrange
            var receivables = Data.GetReceivablesForSummary().AsAsyncQueryable();

            var receivablesRepositoryMock = new Mock<IReceivablesRepository>();
            //var mapperMock = new Mock<IMapper>();
            //mapperMock.Setup(m => m.Map<Receivable>(receivableDTO)).Returns(receivable);

            receivablesRepositoryMock.Setup(repo => repo.ReadAll()).Returns(receivables);

            var receivablesServices = new ReceivablesServices(mapper, receivablesRepositoryMock.Object);

            // Act
            var summary = await receivablesServices.GetSummaryAsync(new ReceivableFilterDTO());

            // Assert
            Assert.Equal(2, summary.NumberOfOpenReceivables);
            Assert.Equal(6, summary.NumberOfClosedReceivables);
            Assert.Equal(1, summary.NumberOfCancelledReceivables);
            Assert.Equal(3449.99M, summary.ValueOfOpenReceivables);
            Assert.Equal(10700.55M, summary.ValueOfClosedReceivables);
            Assert.Equal(3000, summary.ValueOfCancelledReceivables);
            Assert.Equal(2050, summary.ValueOfPaidOpenReceivables);
            Assert.Equal(10700.55M, summary.ValueOfPaidClosedReceivables);
            Assert.Equal(3000, summary.ValueOfPaidCancelledReceivables);
            Assert.Equal(3, summary.NumberOfDebtors);
        }

        [Fact]
        public async Task GetSummaryAsync_ShouldReturnSummaryForADebtor()
        {
            // Arrange
            var receivables = Data.GetReceivablesForSummary().AsAsyncQueryable();
            var receivablesRepositoryMock = new Mock<IReceivablesRepository>();
            receivablesRepositoryMock.Setup(repo => repo.ReadAll()).Returns(receivables);

            var receivablesServices = new ReceivablesServices(mapper, receivablesRepositoryMock.Object);

            // Act
            var summary = await receivablesServices.GetSummaryAsync(new ReceivableFilterDTO { DebtorName = "ITQ"});

            // Assert
            Assert.Equal(1, summary.NumberOfOpenReceivables);
            Assert.Equal(2, summary.NumberOfClosedReceivables);
            Assert.Equal(0, summary.NumberOfCancelledReceivables);
            Assert.Equal(450, summary.ValueOfOpenReceivables);
            Assert.Equal(4200, summary.ValueOfClosedReceivables);
            Assert.Equal(0, summary.ValueOfCancelledReceivables);
            Assert.Equal(50, summary.ValueOfPaidOpenReceivables);
            Assert.Equal(4200, summary.ValueOfPaidClosedReceivables);
            Assert.Equal(0, summary.ValueOfPaidCancelledReceivables);
            Assert.Equal(1, summary.NumberOfDebtors);
        }

        [Fact]
        public async Task GetSummaryAsync_ShouldReturnSummaryForAnIssueDate()
        {
            // Arrange
            var receivables = Data.GetReceivablesForSummary().AsAsyncQueryable();
            var receivablesRepositoryMock = new Mock<IReceivablesRepository>();
            receivablesRepositoryMock.Setup(repo => repo.ReadAll()).Returns(receivables);

            var receivablesServices = new ReceivablesServices(mapper, receivablesRepositoryMock.Object);

            // Act
            var summary = await receivablesServices.GetSummaryAsync(new ReceivableFilterDTO { IssueDate = "2023-01-05" });

            // Assert
            Assert.Equal(1, summary.NumberOfOpenReceivables);
            Assert.Equal(4, summary.NumberOfClosedReceivables);
            Assert.Equal(1, summary.NumberOfCancelledReceivables);
            Assert.Equal(450, summary.ValueOfOpenReceivables);
            Assert.Equal(8400, summary.ValueOfClosedReceivables);
            Assert.Equal(3000, summary.ValueOfCancelledReceivables);
            Assert.Equal(50, summary.ValueOfPaidOpenReceivables);
            Assert.Equal(8400, summary.ValueOfPaidClosedReceivables);
            Assert.Equal(3000, summary.ValueOfPaidCancelledReceivables);
            Assert.Equal(3, summary.NumberOfDebtors);
        }

        [Fact]
        public async Task GetSummaryAsync_ShouldReturnSummaryForAClosedDate()
        {
            // Arrange
            var receivables = Data.GetReceivablesForSummary().AsAsyncQueryable();
            var receivablesRepositoryMock = new Mock<IReceivablesRepository>();
            receivablesRepositoryMock.Setup(repo => repo.ReadAll()).Returns(receivables);

            var receivablesServices = new ReceivablesServices(mapper, receivablesRepositoryMock.Object);

            // Act
            var summary = await receivablesServices.GetSummaryAsync(new ReceivableFilterDTO { ClosedDate = "2023-01-25" });

            // Assert
            Assert.Equal(0, summary.NumberOfOpenReceivables);
            Assert.Equal(4, summary.NumberOfClosedReceivables);
            Assert.Equal(0, summary.NumberOfCancelledReceivables);
            Assert.Equal(0, summary.ValueOfOpenReceivables);
            Assert.Equal(8400, summary.ValueOfClosedReceivables);
            Assert.Equal(0, summary.ValueOfCancelledReceivables);
            Assert.Equal(0, summary.ValueOfPaidOpenReceivables);
            Assert.Equal(8400, summary.ValueOfPaidClosedReceivables);
            Assert.Equal(0, summary.ValueOfPaidCancelledReceivables);
            Assert.Equal(2, summary.NumberOfDebtors);
        }
    }
}
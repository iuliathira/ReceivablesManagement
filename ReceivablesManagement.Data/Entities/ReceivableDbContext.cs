using Microsoft.EntityFrameworkCore;

namespace ReceivablesManagement.Data.Entities
{
    public class ReceivableDbContext: DbContext
	{
		public ReceivableDbContext(DbContextOptions options): base(options)
		{
		}

		public DbSet<Receivable> Receivables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receivable>().HasData(
                new Receivable
                {
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880773"),
                    Reference = "REF_2023_1",
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

                },
                new Receivable
                {
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880775"),
                    Reference = "REF_2023_2",
                    CurrencyCode = "USD",
                    IssueDate = "2023-01-07",
                    OpeningValue = 2600,
                    PaidValue = 2000,
                    DueDate = "2023-02-08",
                    ClosedDate = null,
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
                },
                new Receivable
                {
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880771"),
                    Reference = "REF_2023_3",
                    CurrencyCode = "USD",
                    IssueDate = "2023-01-07",
                    OpeningValue = 2800,
                    PaidValue = 2800,
                    DueDate = "2023-02-08",
                    ClosedDate = null,
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
                },
                new Receivable
                {
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880772"),
                    Reference = "REF_2023_4",
                    CurrencyCode = "USD",
                    IssueDate = "2023-01-07",
                    OpeningValue = 5000.5M,
                    PaidValue = 5000.5M,
                    DueDate = "2023-02-08",
                    ClosedDate = null,
                    Cancelled = true,
                    DebtorName = "LibraTech",
                    DebtorReference = "SV_REF",
                    DebtorAddress1 = "Main Street 15",
                    DebtorAddress2 = "Building 5, ap. 22",
                    DebtorTown = "Cluj",
                    DebtorState = "Romania",
                    DebtorZip = "400657",
                    DebtorCountryCode = "RO",
                    DebtorRegistrationNumber = "RO3197676"
                },
                new Receivable
                {
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880776"),
                    Reference = "REF_2023_5",
                    CurrencyCode = "USD",
                    IssueDate = "2023-01-07",
                    OpeningValue = 100.55M,
                    PaidValue = 100M,
                    DueDate = "2023-02-08",
                    ClosedDate = "2023-02-06",
                    Cancelled = false,
                    DebtorName = "TestVision",
                    DebtorReference = "SV_REF",
                    DebtorAddress1 = "Main Street 15",
                    DebtorAddress2 = "Building 5, ap. 22",
                    DebtorTown = "Cluj",
                    DebtorState = "Romania",
                    DebtorZip = "400657",
                    DebtorCountryCode = "RO",
                    DebtorRegistrationNumber = "RO3197676"
                }
            );
        }
    }
}


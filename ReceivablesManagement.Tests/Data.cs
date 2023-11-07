using ReceivablesManagement.Business.DTOs;
using ReceivablesManagement.Data.Entities;

namespace ReceivablesManagement.Tests
{
    public static class Data
	{
		public static List<ReceivableDTO> GetDefaultReceivableDTOs()
		{
            return new List<ReceivableDTO>
            {
                new ReceivableDTO
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
                new ReceivableDTO
                {
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880774"),
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
                new ReceivableDTO
                {
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880775"),
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
            };
        }
        public static ReceivableDTO GetSingleReceivableDTO()
        {
            return new ReceivableDTO
            {
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
            };
        }
        public static List<Receivable> GetReceivablesForSummary()
        {
            return new List<Receivable>()
            {
                new Receivable
                {
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880771"),
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
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880772"),
                    Reference = "REF_2023_1",
                    CurrencyCode = "USD",
                    IssueDate = "2023-02-05",
                    OpeningValue = 200.55M,
                    PaidValue = 200.55M,
                    DueDate = "2023-02-30",
                    ClosedDate = "2023-02-25",
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
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880773"),
                    Reference = "REF_2023_1",
                    CurrencyCode = "USD",
                    IssueDate = "2023-01-05",
                    OpeningValue = 3000,
                    PaidValue = 3000,
                    DueDate = "2023-01-30",
                    ClosedDate = "2023-01-29",
                    Cancelled = true,
                    DebtorName = "LibraVision",
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
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880774"),
                    Reference = "REF_2023_1",
                    CurrencyCode = "USD",
                    IssueDate = "2023-03-05",
                    OpeningValue = 2999.99M,
                    PaidValue = 2000,
                    DueDate = "2023-04-30",
                    ClosedDate = null,
                    Cancelled = false,
                    DebtorName = "LibraVision",
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
                    Reference = "REF_2023_1",
                    CurrencyCode = "USD",
                    IssueDate = "2023-05-05",
                    OpeningValue = 2100,
                    PaidValue = 2100,
                    DueDate = "2023-06-30",
                    ClosedDate = "2023-05-25",
                    Cancelled = false,
                    DebtorName = "ITQ",
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
                    Reference = "REF_2023_1",
                    CurrencyCode = "USD",
                    IssueDate = "2023-01-05",
                    OpeningValue = 450,
                    PaidValue = 50,
                    DueDate = "2023-03-30",
                    ClosedDate = null,
                    Cancelled = false,
                    DebtorName = "ITQ",
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
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880777"),
                    Reference = "REF_2023_1",
                    CurrencyCode = "USD",
                    IssueDate = "2023-01-05",
                    OpeningValue = 2100,
                    PaidValue = 2100,
                    DueDate = "2023-01-30",
                    ClosedDate = "2023-01-25",
                    Cancelled = false,
                    DebtorName = "ITQ",
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
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880761"),
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
                    Id = new Guid("f9908fe3-0f2a-4737-9c5d-ecc1f7880771"),
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
                }
            };
        }
    }
}


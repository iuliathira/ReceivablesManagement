namespace ReceivablesManagement.Business.DTOs
{
    public class ReceivableSummaryDTO
	{
        public int NumberOfOpenReceivables { get; set; }
        public int NumberOfClosedReceivables { get; set; }
        public int NumberOfCancelledReceivables { get; set; }
        public decimal ValueOfOpenReceivables { get; set; }
        public decimal ValueOfClosedReceivables { get; set; }
        public decimal ValueOfCancelledReceivables { get; set; }
        public decimal ValueOfPaidOpenReceivables { get; set; }
        public decimal ValueOfPaidClosedReceivables { get; set; }
        public decimal ValueOfPaidCancelledReceivables { get; set; }
        public int NumberOfDebtors { get; set; }
    }
}

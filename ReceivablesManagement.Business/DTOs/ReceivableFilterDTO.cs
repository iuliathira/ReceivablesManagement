namespace ReceivablesManagement.Business.DTOs
{
    public class ReceivableFilterDTO
	{
		public string? IssueDate { get; set; }
        public string? ClosedDate { get; set; }
		public string? DebtorName { get; set; }
    }
}

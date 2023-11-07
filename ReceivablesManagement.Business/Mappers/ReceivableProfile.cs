using AutoMapper;
using ReceivablesManagement.Business.DTOs;
using ReceivablesManagement.Data.Entities;

namespace ReceivablesManagement.Business.Mappers
{
    public class ReceivableProfile: Profile
	{
		public ReceivableProfile()
		{
			CreateMap<ReceivableDTO, Receivable>();
			CreateMap<Receivable, ReceivableDTO>();
		}
	}
}


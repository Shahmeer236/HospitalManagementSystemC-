using AutoMapper;

public class BillProfile : Profile
{
    public BillProfile()
    {
        CreateMap<Bill, BillDto>();
        CreateMap<Bill, BillForListing>();
        CreateMap<BillForCreation, Bill>();
        CreateMap<BillForUpdation, Bill>();
    }
}

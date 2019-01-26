using AutoMapper;
using MediatrTutorial.Domain;
using MediatrTutorial.Dto;
using MediatrTutorial.Features.Customer.Commands.CreateCustomer;
using System;

namespace MediatrTutorial.Infrastructure.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(c => c.RegistrationDate, opt =>
                    opt.MapFrom(_ => DateTime.Now));

            CreateMap<Customer, CustomerDto>()
                .ForMember(cd => cd.RegistrationDate, opt =>
                    opt.MapFrom(c => c.RegistrationDate.ToShortDateString()));
        }
    }
}
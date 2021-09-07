using AutoMapper;
using SampleAutoMapper.DTO;
using SampleAutoMapper.Model;
using System;

namespace SampleAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleConfig();

            //ExistObject();

            //PropertyNameNotIdentical();

            //ObjectsWithDifferentStructure();
        }

        public static void SimpleConfig()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AuthorModel, AuthorDTO>();
            });

            IMapper iMapper = config.CreateMapper();

            var source = new AuthorModel().GetAuthorModelMock();

            var destination = iMapper.Map<AuthorModel, AuthorDTO>(source);

            Print(destination);
        }

        // If the destination object already exists, you can use the statement below instead.
        public static void ExistObject()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AuthorModel, AuthorDTO>();
            });

            IMapper iMapper = config.CreateMapper();

            var source = new AuthorModel().GetAuthorModelMock();

            var destination = new AuthorDTO();

            iMapper.Map(source, destination);

            Print(destination);
        }

        public static void PropertyNameNotIdentical()
        {
            // If the property names are not identical, then you must let AutoMapper know how the properties should be mapped.
            // Assuming that we want to map the two properties Contact and ContactDetails,
            // the following example illustrates how this can be achieved.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorModel, AuthorDTO>()
                .ForMember(destination => destination.ContactDetails,
               opts => opts.MapFrom(source => source.Contact));
            });

            IMapper iMapper = config.CreateMapper();
            var source = new AuthorModel().GetAuthorModelMock();

            var destination = iMapper.Map<AuthorModel, AuthorDTO>(source);

            Print(destination);
        }

        //  Projections are used to map source values to a destination
        //  that does not match the structure of the source
        public static void ObjectsWithDifferentStructure()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorModel, AuthorDTO>()
                   .ForMember(
                        destination => destination.City,
                        opt => opt.MapFrom(src => src.AddressModel.City)
                   )
                   .ForMember(
                        destination => destination.State,
                        opt => opt.MapFrom(src => src.AddressModel.State)
                   )
                   .ForMember(
                        destination => destination.Country,
                        opt => opt.MapFrom(src => src.AddressModel.Country)
                   );

            });

            IMapper iMapper = config.CreateMapper();

            var source = new AuthorModel().GetAuthorModelMock();

            var destination = iMapper.Map<AuthorModel, AuthorDTO>(source);

            Print(destination);
        }

        public static void Print(AuthorDTO authorDTO)
        {
            Console.WriteLine("Id: " + authorDTO.Id);
            Console.WriteLine("Author Name: " + authorDTO.FirstName + " " + authorDTO.LastName);
            Console.WriteLine("Contact Detail: " + authorDTO.ContactDetails);
            Console.WriteLine("Address: " + authorDTO.Address);
            Console.WriteLine("Country: " + authorDTO.Country);
            Console.WriteLine("State: " + authorDTO.State);
            Console.WriteLine("City: " + authorDTO.City);
        }

    }
}

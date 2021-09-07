using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAutoMapper.Model
{
    public class AuthorModel
    {
        public int Id { get; set; }
       
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }

        public string Contact { get; set; }

        public AddressModel AddressModel
        {
            get; set;
        }


        public AuthorModel GetAuthorModelMock()
        {
            var source = new AuthorModel();

            source.Id = 123;
            source.Address = "Av Central";
            source.FirstName = "Milton";
            source.LastName = "Quirino";
            source.Contact = "me@gmail.com";
            source.AddressModel = new AddressModel()
            {
                City = "Sao Paulo",
                Country = "Brazil",
                State = "SP"
            };

            return source;
        }
    }
}

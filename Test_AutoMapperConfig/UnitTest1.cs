using AutoMapper;
using Models.AuthModels;
using Models.Entities;
using NUnit.Framework;
using SP_AutoMapperConfig;
using System.Reflection;

namespace Test_AutoMapperConfig
{
    [TestFixture]
    public class MappingTests
    {
        [Test]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetAssembly(typeof(SP_AutoMapperAssembly))));
            config.AssertConfigurationIsValid();
        }

        [TestCase("123456789", ExpectedResult = 123456789)]
        public decimal? AutoMapper_ConvertFromByte_IsValid(
            string phonenumber)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AuthProfile>());
            var mapper = config.CreateMapper();
            var RegisterModel = new RegisterModel
            {
                PhoneNumber = phonenumber
            };
            var user = mapper.Map<RegisterModel, User>(RegisterModel);
            return user.PhoneNumber;
        }
    }
}
using Models.AuthModels;
using Models.Entities;

namespace TestAutoMapperConfiguration
{
    [TestClass]
    public class AuthProfileTests
    {
        [TestMethod]
        public void TestPhoneNumberMapping()
        {
            var RegisterModel = new RegisterModel
            {
                PhoneNumber = "123456789"
            };

        }
    }
}
using Moq.AutoMock;


namespace AlfaSoft.Contacts.Business.Tests
{
    public class BaseTest
    {
        public readonly AutoMocker mocker;

        public BaseTest()
        {
            mocker = new AutoMocker();
        }
    }
}

using Xunit;

namespace Moq.PartialFromInstance.Tests
{
    public class PartialFromInstanceTest
    {
        [Fact]
        public void PartialMoqTest()
        {
            // ARRANGE
            var actual = new Foo
            {
                StringProp = "Actual",
                IntProp = 42
            };

            var mock = new Mock<IFoo>();

            //ACT
            var setup = mock.Setup(x => x.StringProp);
            
            setup.Returns("Mocked");

            var mock2 = Mock.Get<IFoo>(actual);

            mock2.Setup(x => x.IntProp).Returns(25);

            //ASSERT
            Assert.Equal(
                "Actual",
                mock2.Object.StringProp);

            Assert.Equal(
                25,
                mock2.Object.IntProp);

            Assert.Equal(
                "Mocked",
                mock.Object.StringProp);
        }
    }

    public interface IFoo 
    {
        string StringProp { get; }

        int IntProp { get; }
    }

    public class Foo : IFoo
    {
        public string StringProp { get; set; }
        public int IntProp { get; set; }
    }
}

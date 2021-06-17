using CL.Model;
using Xunit;

namespace UT_Modele
{
    public class Test_Card
    {
        [Theory]
        [InlineData("My ask", "My answer", "My ask", "My answer")]
        [InlineData("My ask", null, "My ask",null)]
        [InlineData(null,"My answer",null,"My answer")]
        public void CheckParameters(string inputAsk, string inputAnswer, string expectedAsk,string expectedAnswer)
        {
            Card card = new(inputAsk, inputAnswer);
            Assert.Equal(expectedAsk, card.Ask);
            Assert.Equal(expectedAnswer, card.Answer);
        }
    }
}

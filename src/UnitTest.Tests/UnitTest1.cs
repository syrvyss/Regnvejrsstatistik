using Xunit;
using Regnvejrsstatistik;

namespace UnitTest.Tests {
    public class UnitTest1 {
        [Fact]
        public void Statistics_Average_True()
        {
            double[] values = { 1.3, 60.4, 6.99 };
            Statistics stat1 = new Statistics(values);
            Assert.Equal(stat1.Average(), 22.896666666666665);
        }

        [Fact]
        public void Statistics_Min_True()
        {
            double[] values = { 1.3, 60.4, 6.99 };
            Statistics stat1 = new Statistics(values);
            Assert.Equal(stat1.Min(), 1.3);
        }

        [Fact]
        public void Statistics_Max_True()
        {
            double[] values = { 1.3, 60.4, 6.99 };
            Statistics stat1 = new Statistics(values);
            Assert.Equal(stat1.Max(), 60.4);
        }

        [Fact]
        public void Statistics_Median_True()
        {
            double[] values = { 1.3, 60.4, 6.99 };
            Statistics stat1 = new Statistics(values);
            Assert.Equal(stat1.Median(), 6.99);
        }
    }
};
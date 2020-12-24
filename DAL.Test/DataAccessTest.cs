using System;
using DAL;
using Xunit;

namespace DAL.Test
{
    public class DataAccessTest
    {
        private IDataAccess dacc;

        public DataAccessTest()
        {
            this.dacc = new DataAccess();
        }

        [Fact]
        public void GetFilesTest()
        {
            int expected = 2;
            Assert.Equal(expected, dacc.GetOrders().Count);
        }
    }
}

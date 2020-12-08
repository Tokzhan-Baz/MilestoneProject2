using Microsoft.AspNetCore.Mvc;
using MilestoneProject2.Services;

using System;
using System.Threading.Tasks;
using Xunit;

namespace MilestoneProject2.tests.TestMethods
{
    public class MathTest
    {
        [Fact]
        public void Setup()
        {

        }
        [Fact]
        public int TestSum()
        {
            var math = new MathBL();
            int result = math.sum(100,100);
            return result;

        }
    }
}

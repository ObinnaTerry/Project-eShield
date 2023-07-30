using eShield_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace eShield.Test.eShield_APITests.UtilsTests
{
    public class ExamCodeTests
    {
        public class GenerateCodeMethod
        {
            [Fact]
            public void CallMethod_RetrunsLenSix()
            {
                string examCode = ExamCode.GenerateCode();

                Assert.Equal(6, examCode.Length);
            } 
        }
    }
}

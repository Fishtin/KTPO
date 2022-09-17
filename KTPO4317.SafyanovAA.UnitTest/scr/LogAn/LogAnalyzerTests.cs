using KTPO4317.SafyanovAA.Lib.src.LogAn;
using NUnit.Framework;
using System;

namespace KTPO4317.SafyanovAA.UnitTest.scr.LogAn
{
    //BBBBBvdszvsdavasdd
    //bbbbb
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse() 
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.False(result);
        }
        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue() 
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("Filewithbadextension.SAA");
            Assert.True(result);
        }
        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithbadextension.saa");
            Assert.True(result);
        }
        [TestCase("filewithbadextension.saa")]
        [TestCase("filewithbadextension.Saa")]
        public void IsValidLogFileName_ValidExtension_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(file);
            Assert.True(result);
        }
        [Test]
        public void IsValidFileName_EmptyFileName_Throws() 
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));
            StringAssert.Contains("имя фаила должно быть задано", ex.Message);
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.saa", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            analyzer.IsValidLogFileName(file);
            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);
        }

    }

}

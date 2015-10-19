using NUnit.Framework;

namespace Exercise_2_2_2.tests
{
    public class CsvParserTest
    {



        [Test]
        public void ParseLine_WithOnePlainField_ReturnField()
        {
            var result = CsvParser.ParseLine("1234");

            Assert.AreEqual("1234", result[0]);
        }

        [Test]
        public void ParseLine_WithThreePlainFields_ReturnFields()
        {
            var result = CsvParser.ParseLine("1,A,2.4");

            Assert.AreEqual("1", result[0]);
            Assert.AreEqual("A", result[1]);
            Assert.AreEqual("2.4", result[2]);
        }

        [Test]
        public void ParseLine_WithOneQuotedField_ReturnField()
        {
            var result = CsvParser.ParseLine("\"1234\"");

            Assert.AreEqual("1234", result[0]);
        }

        [Test]
        public void ParseLine_WithOneQuotedFieldWithEscapedQuotes_ReturnField()
        {
            var result = CsvParser.ParseLine("\"12\"\"34\"");

            Assert.AreEqual("12\"34", result[0]);
        }

        [Test]
        public void ParseLine_WithOneQuotedFieldWithEscapedQuoteAsFirstLetter_ReturnField()
        {
            var result = CsvParser.ParseLine("\"\"\"1234\"");

            Assert.AreEqual("\"1234", result[0]);
        }

        [Test]
        public void ParseLine_WithOneQuotedFieldWithEscapedDoubleQuoteAsFirstLetter_ReturnField()
        {
            var result = CsvParser.ParseLine("\"\"\"\"\"1234\"");

            Assert.AreEqual("\"\"1234", result[0]);
        }

        [Test]
        public void ParseLine_WithThreeQuotedFields_ReturnFields()
        {
            var result = CsvParser.ParseLine("\"1\",\"A\",\"2.4\"");

            Assert.AreEqual("1", result[0]);
            Assert.AreEqual("A", result[1]);
            Assert.AreEqual("2.4", result[2]);
        }

        [Test]
        public void ParseLine_WithThreeMixedFields_ReturnFields()
        {
            var result = CsvParser.ParseLine("1,\"A\",\"2.4\"");

            Assert.AreEqual("1", result[0]);
            Assert.AreEqual("A", result[1]);
            Assert.AreEqual("2.4", result[2]);
        }
    }
}
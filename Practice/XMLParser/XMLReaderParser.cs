// <copyright file="XMLReaderParser.cs" company="NA">
//     All rights reserved.
// </copyright>
namespace Practice.XMLParser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// Manages xml file using XmlTextReader
    /// </summary>
    public class XMLReaderParser : IXmlParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XMLReaderParser"/> class.
        /// </summary>
        public XMLReaderParser()
        {
            this.TestCases = new List<TestCase>();
        }

        /// <summary>
        /// Gets or sets xml file path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets collection of testCases
        /// </summary>
        public IList<TestCase> TestCases { get; set; }

        /// <summary>
        /// Parses xml file using <see cref="XmlTextReader"/> class.
        /// </summary>
        public void ParseXml()
        {
            if (this.FilePath == null || string.IsNullOrEmpty(this.FilePath))
            {
                throw new ArgumentNullException("File Path can not be null");
            }

            using (XmlTextReader xtr = new XmlTextReader(this.FilePath))
            {
                xtr.WhitespaceHandling = WhitespaceHandling.None;
                xtr.Read(); // Reads Suite

                while (!xtr.EOF)
                {
                    if (xtr.Name.Equals("suite") && !xtr.IsStartElement())
                    {
                        break;
                    }

                    while (xtr.Name != "testcase" || !xtr.IsStartElement())
                    {
                        xtr.Read();
                    }

                    TestCase tc = new TestCase();
                    tc.Id = xtr.GetAttribute("id");
                    tc.Kind = xtr.GetAttribute("kind");

                    xtr.Read(); //// input tag
                    xtr.Read(); //// args1 tag

                    tc.Arg1 = xtr.ReadElementContentAsString();
                    xtr.Read(); //// arg2 tag

                    tc.Arg2 = xtr.ReadContentAsString();

                    xtr.Read(); //// input end tag
                    xtr.Read(); ////expected element

                    tc.Expected = xtr.ReadElementContentAsString();

                    this.TestCases.Add(tc);
                    xtr.Read();
                }
            }
        }
    }
}

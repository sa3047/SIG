// <copyright file="IXmlParser.cs" company="NA">
//     All rights reserved.
// </copyright>
namespace Practice.XMLParser
{
    /// <summary>
    /// Interface for xml file parser
    /// </summary>
    public interface IXmlParser
    {
        /// <summary>
        /// Gets or sets xml file path
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Parses xml file
        /// </summary>
        void ParseXml();
    }
}

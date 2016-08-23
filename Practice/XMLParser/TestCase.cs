// <copyright file="TestCase.cs" company="NA">
//     All rights reserved.
// </copyright>
namespace Practice.XMLParser
{
    /// <summary>
    /// Manages test case
    /// </summary>
    public class TestCase
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Kind
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets argument 1
        /// </summary>
        public string Arg1 { get; set; }

        /// <summary>
        /// Gets or sets argument 2
        /// </summary>
        public string Arg2 { get; set; }

        /// <summary>
        /// Gets or sets Expected
        /// </summary>
        public string Expected { get; set; }
    }
}

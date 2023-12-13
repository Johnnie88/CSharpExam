namespace CsharpExam.Api.Entities
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The order model.
    /// </summary>
    [DataContract]
    public class OrderModel
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the order name.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
namespace FsMapper.Tests.Dto
{
    public class Sale
    {
        protected Customer Customer { get; }

        public Sale(Customer customer)
        {
            Customer = customer;
        }
    }
}
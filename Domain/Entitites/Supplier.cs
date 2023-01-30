

namespace Domain.Entitites
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int Phone { get; set; }

        public Supplier()
        {

        }
        public Supplier(int id, string companyName, int phone)
        {
            Id = id;
            CompanyName = companyName;
            Phone = phone;
                
        }
    }
}

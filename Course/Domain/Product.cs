using EFCoreCourse.ValueObjects;

namespace EFCoreCourse.Domain
{
    public class Product
    {
        public int Id {get; set;}
        public string BarCode {get; set;}
        public string Description {get; set;}
        public decimal Value {get; set;}
        public ProductType ProductType {get; set;}
        public bool Status {get; set;}

    }
}
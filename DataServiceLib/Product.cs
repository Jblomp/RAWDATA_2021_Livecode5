using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }
        public Category Category { get; set; }
        //public ICollection<OrderDetails> OrderDetails { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, CategoryId = {CategoryId}, UnitPrice = {UnitPrice}, QuantityPerUnit = {QuantityPerUnit}," +
                   $" UnitsInStock = {UnitsInStock}, Category = {Category}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(c => c.Orders.Sum(o => o.Total) > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            return customers.Select(c => new Tuple<Customer, IEnumerable<Supplier>>
                (c, suppliers.Where(s => s.City == c.City && s.Country == c.Country)).ToValueTuple());
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            return customers.GroupJoin(suppliers,
                customer => new { customer.Country, customer.City },
                supplier => new { supplier.Country, supplier.City },
                (supplier, group) => (supplier, group));
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(c => c.Orders.Length != 0).ToList().FindAll(c => c.Orders.Sum(o => o.Total) > limit);
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            return customers.Where(c => c.Orders.Length != 0).Select(c =>
                new Tuple<Customer, DateTime>(c, c.Orders.Min(order => order.OrderDate)).ToValueTuple());
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            return customers.Where(c => c.Orders.Length != 0).Select(c =>
                new Tuple<Customer, DateTime>(c, c.Orders.Min(order => order.OrderDate)).ToValueTuple())
                .OrderBy(c => c.Item2.Year)
                .ThenBy(c => c.Item2.Month)
                .ThenByDescending(c => c.Item1.CustomerID);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            return customers.Where(customer => int.TryParse(customer.PostalCode,out int res) != true ||
                                               string.IsNullOrEmpty(customer.Region) ||
                                               (!customer.Phone.Contains("(") &&
                                                !customer.Phone.Contains(")"))).ToList();
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */
            //var a = products.GroupBy(p => new {p.Category, p.UnitsInStock, p.UnitPrice})
            //    .Select(gr => new
            //    {
            //        gr.Key.Category,
            //        (from u in gr
            //                group u by u.UnitsInStock into uis
            //                    select uis),

            //    });
            var b = from product in products
                group product by product.Category
                into grp
                select new
                {
                    Category = grp.Key,
                    UnitsInStock = from gr in grp 
                        group gr by new {gr.UnitsInStock, gr.UnitPrice} into g
                        orderby g.Key.UnitPrice
                            select new
                            {
                                g.Key.UnitsInStock,
                                Price = g.Key.UnitPrice
                            }
                };

            return b;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            throw new NotImplementedException();
        }
    }
}
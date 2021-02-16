using Api.Models;
using Foundation.ObjectHydrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Repository
    {
        public static Repository Instance { get; } = new Repository();
        public IList<CustomerDTO> Customers { get; set; }
        public Repository()
        {
            Hydrator<CustomerDTO> hydrator = new Hydrator<CustomerDTO>();
            Customers = hydrator.GetList(5);

            Random random = new Random();
            Hydrator<OrdersDTO> ordersHydratos =
                new Hydrator<OrdersDTO>();
            foreach(var customer in Customers)
            {
                customer.Orders =
                    ordersHydratos.GetList(random.Next(1, 10));
            }
        }
    }
}

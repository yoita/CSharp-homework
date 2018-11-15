using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Goods milk = new Goods(1, "Milk", 69.9);
                Goods eggs = new Goods(2, "eggs", 4.99);
                Goods apple = new Goods(3, "apple", 5.59);

                OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
                OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
                OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);
                Order order3 = new Order(3, customer2);
                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);
                order1.AddDetails(orderDetails3);
                //order1.AddOrderDetails(orderDetails3);
                order2.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails3);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);

                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByCustomerName:'Customer2'");
                orders = os.QueryByCustomerName("Customer2");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByGoodsName:'apple'");
                orders = os.QueryByGoodsName("apple");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("Remove order(id=2) and qurey all");
                os.RemoveOrder(2);
                os.QueryAllOrders().ForEach(
                    od => Console.WriteLine(od));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        class Customer
        {

            /// <summary>
            /// customer's identifier
            /// </summary>
            public uint Id { get; set; }

            /// <summary>
            /// customer's name
            /// </summary>
            public string Name { get; set; }


            /// <summary>
            /// Customer constructor
            /// </summary>
            /// <param name="id">customer id</param>
            /// <param name="name">customer name </param>
            public Customer(uint id, string name)
            {
                this.Id = id;
                this.Name = name;
            }

            /// <summary>
            /// override ToString
            /// </summary>
            /// <returns>string:message of the Customer object</returns>
            public override string ToString()
            {
                return $"customerId:{Id}, CustomerName:{Name}";
            }
        }

        class Goods
        {

            private double price;

            /// <summary>
            /// Goods constuctor
            /// </summary>
            /// <param name="id">goods id</param>
            /// <param name="name">goods name</param>
            /// <param name="value">>goods value</param>
            public Goods(uint id, string name, double value)
            {
                Id = id;
                Name = name;
                Price = value;
            }

            /// <summary>
            /// property : goods id
            /// </summary>
            public uint Id { get; set; }

            /// <summary>
            /// property : goods name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// property : goods value
            /// </summary>
            public double Price
            {
                get { return price; }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException("value must >= 0!");
                    price = value;
                }
            }

            /// <summary>
            /// override ToString
            /// </summary>
            /// <returns>string:message of the Goods object</returns>
            public override string ToString()
            {
                return $"Id:{Id}, Name:{Name}, Value:{Price}";
            }
        }

        class Order
        {

            private List<OrderDetail> details = new List<OrderDetail>();

            /// <summary>
            /// Order constructor
            /// </summary>
            /// <param name="orderId">order id</param>
            /// <param name="customer">who orders goods</param>
            public Order(uint orderId, Customer customer)
            {
                Id = orderId;
                Customer = customer;
            }

            /// <summary>
            /// order id
            /// </summary>
            public uint Id { get; set; }

            /// <summary>
            /// the man who orders goods
            /// </summary>
            public Customer Customer { get; set; }


            public List<OrderDetail> Details
            {
                get => this.details;
            }

            /// <summary>
            /// add new orderDetail to order
            /// </summary>
            /// <param name="orderDetail">the new orderDetail which will be added</param>
            public void AddDetails(OrderDetail orderDetail)
            {
                if (this.Details.Contains(orderDetail))
                {
                    throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
                }
                details.Add(orderDetail);
            }

            /// <summary>
            /// remove orderDetail by orderDetailId from order
            /// </summary>
            /// <param name="orderDetailId">id of the orderDetail which will be removed</param>
            public void RemoveDetails(uint orderDetailId)
            {
                details.RemoveAll(d => d.Id == orderDetailId);
            }

            /// <summary>
            /// override ToString
            /// </summary>
            /// <returns>string:message of the Order object</returns>
            public override string ToString()
            {
                string result = "================================================================================\n";
                result += $"orderId:{Id}, customer:({Customer})";
                details.ForEach(od => result += "\n\t" + od);
                result += "\n================================================================================";
                return result;
            }
        }

        class OrderDetail
        {
            /// <summary>
            /// OrderDetail constructor
            /// </summary>
            /// <param name="id">orderDetail's id</param>
            /// <param name="goods">orderDetail's goods</param>
            /// <param name="quantity">goods quantity</param>
            public OrderDetail(uint id, Goods goods, uint quantity)
            {
                this.Id = id;
                this.Goods = goods;
                this.Quantity = quantity;
            }
            /// <summary>
            /// OrderDetail's id
            /// </summary>
            public uint Id { get; set; }

            /// <summary>
            /// orderDetail's goods
            /// </summary>
            public Goods Goods { get; set; }

            /// <summary>
            /// goods quantity
            /// </summary>
            public uint Quantity { get; set; }

            public override bool Equals(object obj)
            {
                var detail = obj as OrderDetail;
                return detail != null &&
                    Goods.Id == detail.Goods.Id &&
                    Quantity == detail.Quantity;
            }

            public override int GetHashCode()
            {
                var hashCode = 1522631281;
                hashCode = hashCode * -1521134295 + Goods.Name.GetHashCode();
                hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
                return hashCode;
            }

            /// <summary>
            /// override ToString
            /// </summary>
            /// <returns>string:message of the OrderDetail object</returns>
            public override string ToString()
            {
                string result = "";
                result += $"orderDetailId:{Id}:  ";
                result += Goods + $", quantity:{Quantity}";
                return result;
            }
        }

        class OrderService
        {

            private Dictionary<uint, Order> orderDict;
            /// <summary>
            /// OrderService constructor
            /// </summary>
            public OrderService()
            {
                orderDict = new Dictionary<uint, Order>();
            }

            /// <summary>
            /// add new order
            /// </summary>
            /// <param name="order">the order will be added</param>
            public void AddOrder(Order order)
            {
                if (orderDict.ContainsKey(order.Id))
                    throw new Exception($"order-{order.Id} is already existed!");
                orderDict[order.Id] = order;
            }

            /// <summary>
            /// cancel order
            /// </summary>
            /// <param name="orderId">id of the order which will be canceled</param> 
            public void RemoveOrder(uint orderId)
            {
                orderDict.Remove(orderId);
            }

            /// <summary>
            /// query all orders
            /// </summary>
            /// <returns>List<Order>:all the orders</returns> 
            public List<Order> QueryAllOrders()
            {
                return orderDict.Values.ToList();
            }

            /// <summary>
            /// query by orderId
            /// </summary>
            /// <param name="orderId">id of the order to find</param>
            /// <returns>List<Order></returns> 
            public Order GetById(uint orderId)
            {
                return orderDict[orderId];
            }

            /// <summary>
            /// query by goodsName
            /// </summary>
            /// <param name="goodsName">the name of goods in order's orderDetail</param>
            /// <returns></returns> 
            public List<Order> QueryByGoodsName(string goodsName)
            {
                List<Order> result = new List<Order>();
                foreach (Order order in orderDict.Values)
                {
                    foreach (OrderDetail detail in order.Details)
                    {
                        if (detail.Goods.Name == goodsName)
                        {
                            result.Add(order);
                            break;
                        }
                    }
                }
                return result;
            }

            /// <summary>
            /// query by customerName
            /// </summary>
            /// <param name="customerName">customer name</param>
            /// <returns></returns> 
            public List<Order> QueryByCustomerName(string customerName)
            {
                var query = orderDict.Values
                    .Where(order => order.Customer.Name == customerName);
                return query.ToList();
            }

            /// <summary>
            /// edit order's customer
            /// </summary>
            /// <param name="orderId"> id of the order whoes customer will be update</param>
            /// <param name="newCustomer">the new customer of the order which will be update</param> 
            public void UpdateCustomer(uint orderId, Customer newCustomer)
            {
                if (orderDict.ContainsKey(orderId))
                {
                    orderDict[orderId].Customer = newCustomer;
                }
                else
                {
                    throw new Exception($"order-{orderId} is not existed!");
                }
            }

            /*other edit function with write in the future.*/
        }
    }
}
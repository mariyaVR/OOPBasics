using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;
            }
        }

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> BagOfProducts => this.bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public void BuyProducts(Product product)
        {
            if (product.Cost > this.money)
            {
                throw new InvalidOperationException($"{this.name} can't afford {product.Name}");
            }

            this.money -= product.Cost;
            this.bagOfProducts.Add(product);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var peopleCotainer = new Dictionary<string, Person>();
            var productContainer = new Dictionary<string, Product>();

            string[] people = Console.ReadLine()
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var currentPerson in people)
                {
                    var tokens = currentPerson.Split('=');
                    var name = tokens[0];
                    var money = decimal.Parse(tokens[1]);

                    var person = new Person(name, money);
                    peopleCotainer.Add(name, person);
                }

                var products = Console.ReadLine()
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var currentProduct in products)
                {
                    var tokens = currentProduct.Split('=');
                    var name = tokens[0];
                    var price = decimal.Parse(tokens[1]);

                    var product = new Product(name, price);
                    productContainer.Add(name, product);
                }

                var command = Console.ReadLine();

                while (!command.Equals("END"))
                {
                    var tokens = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var personName = tokens[0];
                    var productName = tokens[1];

                    try
                    {
                        Person person = peopleCotainer[personName];
                        Product product = productContainer[productName];
                        person.BuyProducts(product);

                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }

                    command = Console.ReadLine();
                }

                foreach (string person in peopleCotainer.Keys)
                {
                    string items = string.Join(", ", peopleCotainer[person].BagOfProducts);
                    string result = !peopleCotainer[person].BagOfProducts.Any() ? "Nothing bought" : items;

                    Console.WriteLine($"{person} - {result}");
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

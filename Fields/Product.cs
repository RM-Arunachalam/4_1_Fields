namespace Fields
{
    public class Product
    {
        public static string mode = "Online";//static field
        public int id; //instance fields
        public readonly string dateOfPurchase;//readonly instance field
        public string name;
        public double cost;
        public int quantityInStock;
        private int _productIMEI;//private field
        protected int prodWarranty;
        internal bool availability;
        protected internal string country;
        public const int prodTaxNumber = 100;//const field
        public double tax;

        public Product() { 
            dateOfPurchase = DateTime.Now.ToShortDateString();//MM-DD-YYYY
        }
        public Product(string dateOfPurch)
        {
            dateOfPurchase=dateOfPurch;//initailizing readonly field with constructor parameter
        }
        public void Mode()
        {
            System.Console.WriteLine(mode);//no need of classname also when accessing static field
        }
    }

    public class SubProduct : Product
    {
        public void Method()
        {
            System.Console.WriteLine(id);//can access public field
            System.Console.WriteLine(prodWarranty);//can access protected field
            System.Console.WriteLine(availability);//can access internal field
            System.Console.WriteLine(country);//can access protected internal  field
            //System.Console.WriteLine(_productIMEI);//can't access the private field in other classes
        }
    }

    public class OtherClassSameAssembly
    {
        public void Method()
        {
            Product lp=new Product();//can't prevent private field being stored inside object 
            System.Console.WriteLine(lp.id);//can access public field in other classes
            // System.Console.WriteLine(lp.prodWarranty); //can't access the protected field in other than child classes
            System.Console.WriteLine(lp.availability);//can access internal field in other classes
            //System.Console.WriteLine(lp._productIMEI);//can't access the private field in other classes
            System.Console.WriteLine(lp.country);//can access protected internal  field
        }
    }
}

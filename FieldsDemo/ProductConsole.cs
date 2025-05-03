using Fields;

class Sample
{
    public static void Main(string [] args)
    {
        Product laptop = new Product();
        laptop.cost = 80000.78;
        laptop.id = 176809;
        laptop.name = "hp 15";
        laptop.quantityInStock = 3;
        laptop.Mode();//Online [accessing static field inside same class method without need of class name ]
        //laptop._productIMEI  //can't access the private field in other classes
        Console.WriteLine("Static field->"+Product.mode);//Online //accessing static field with classname
        Console.WriteLine("constant field" + Product.prodTaxNumber);//100 accessing constant field
        Console.WriteLine("laptop dop:"+laptop.dateOfPurchase);//28-11-2024 //accessing readonly field
        
        Product mobile = new Product("18-07-1999");
        mobile.cost = 26000.8;
        mobile.id = 1709;
        mobile.name = "oppo 65";
        mobile.quantityInStock = 2;
        Console.WriteLine("mobile dop:" + mobile.dateOfPurchase);//18-07-1999 //accessing readonly field

        Product book = new Product();
        book.cost = 900.8;
        book.id = 1709;
        book.name = "pooniyin selvan";
        book.quantityInStock = 1;

        System.Console.WriteLine("laptop cost:"+laptop.cost);//80000.78
        System.Console.WriteLine("lap QIS:"+laptop.quantityInStock);//3

        double totalcost = book.cost + laptop.cost + mobile.cost;
        System.Console.WriteLine("total cost :"+totalcost);//106902.38
        System.Console.WriteLine("highest product cost : "+HighestProductCost(book,laptop,mobile));//80000.78

        LocalConstantsDemo();

        SubProduct sp = new SubProduct();
        sp.name = "hp 15";
        sp.SubProductMethod();

        OtherClassSameAssembly os = new OtherClassSameAssembly();
        os.OtherClassSameAssembly_Method();

        InternationalProduct ip = new InternationalProduct();
        ip.name = "hp 150";
        ip.InternationalProductMethod();

        OtherClassOtherAssembly oc = new OtherClassOtherAssembly();
        oc.OtherClassOtherAssembly_Method();

    }

    private static void LocalConstantsDemo()
    {
        const double pi = 3.14;//local constant
        System.Console.WriteLine(pi);//3.14
    }

    public class InternationalProduct : Product
    {
        public void InternationalProductMethod()
        {
            System.Console.WriteLine("InternationalProductMethod-Other assembly,child class method:");
            System.Console.WriteLine(name);//accessing public field
            System.Console.WriteLine(prodWarranty);//accessing protected field
            //System.Console.WriteLine(availability);//can't access the internal field in other assemblies
            //System.Console.WriteLine(_productIMEI);//can't access the private field in other classes
           // System.Console.WriteLine(billNo);//can't access private protected field in other classes
            System.Console.WriteLine("country=>"+country);//can access protected internal  field in child classes
        }
    }


    public class OtherClassOtherAssembly
    {
        public void OtherClassOtherAssembly_Method()
        {
            System.Console.WriteLine("OtherClassOtherAssembly_Method:");
            Product lp = new Product();//can't prevent private field being stored inside object 
            lp.name = "Samsung 176";

            System.Console.WriteLine(lp.name);//accessing public field
            // System.Console.WriteLine(lp.prodWarranty); //can't access the protected field in other than child classes
            // System.Console.WriteLine(lp.availability);//can't access the internal field in other assemblies
            //System.Console.WriteLine(lp._productIMEI);//can't access the private field in other classes
            //System.Console.WriteLine(lp.billNo);//can't access private protected field in other classes
            //System.Console.WriteLine(lp.country);//can't access protected internal  field in other classes
        }
    }

    /// <summary>
    /// Find Highest product cost
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <returns>double Cost</returns>
    public static double HighestProductCost(Product p1, Product p2, Product p3)
    {
        double highest;
        if (p1.cost >= p2.cost)
        {
            if (p1.cost >= p3.cost)
                highest = p1.cost;
            else
                highest = p3.cost;
        }
        else
        {
            if (p2.cost >= p3.cost)
                highest = p2.cost;
            else
                highest = p3.cost;
        }
        return highest;
    }
}
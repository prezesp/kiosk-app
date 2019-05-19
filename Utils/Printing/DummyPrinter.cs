using System;

namespace KioskApp.Utils.Printing
{
    class DummyPrinter : IPrinter
    {
        public bool Print(IPrintable printable) 
        {
            Console.WriteLine("testowy wydruk");
            return true;
        }
    }
}
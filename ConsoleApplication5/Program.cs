using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackUp.Lib;

namespace BackUp
{
    public class Program
    {
        static void Main(string[] args)
        {

            Flash f1 = new Flash("Kingston","ahdgjhg2653",2000, typeUSB.USB1);
            ServiceStorage.addFlash(f1);
            ServiceStorage.addFlash(new Flash("Sumsung","hags7364",4000, typeUSB.USB2));
            ServiceStorage.addFlash(new Flash("Sumsung", "gh464", 8000, typeUSB.USB3));

            Console.WriteLine("Enter V Information: "); 
            double t= double.Parse(Console.ReadLine());
            ServiceStorage.getCountDevice(TypeDevice.Flash, t);
        }
    }
}

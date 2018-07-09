using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUp.Lib
{
    public enum TypeDevice { Flash, DVD, HDD }
    public class ServiceStorage
    {
        static List<Flash> flashes;
        static ServiceStorage()
        {
            flashes = new List<Flash>();
        }

        public static void addFlash(Flash flash)
        {
            flashes.Add(flash);
        }

        public static double getMemoryDevice()
        {
            double totalMemory = flashes.Sum(s => s.getMemory());
            Console.WriteLine("объем всех носителей = {0}", totalMemory);
            return totalMemory;
        }

        public static double getFreeMemoryDevice()
        {
            double totalMemory = flashes.Sum(s => s.getFreeMemory());
            Console.WriteLine("Free объем всех носителей = {0}", totalMemory);
            return totalMemory;
        }

        public static void getCountDevice(TypeDevice typeDevice, double sizeData)
        {
            double total = 0;
            switch (typeDevice)
            {
                case TypeDevice.Flash:
                    {
                        int i = 1;
                        foreach (Flash item in flashes)
                        {
                            total = Math.Floor(sizeData / item.memory);
                            Console.WriteLine(" {0}.{1} \t({2})\t- {3} gb: {4} sht", i++, item.name, item.model, item.memory, total);
                        }

                        Console.WriteLine("Choose variant: ");
                        i = Int32.Parse(Console.ReadLine());

                    }
                    break;
                case TypeDevice.DVD:
                    {

                    }
                    break;
                case TypeDevice.HDD:
                    {

                    }
                    break;

            }
        }

        public static void getTimeToCopy(TypeDevice typeDevice, int variant, double sizeData)
        {
            switch (typeDevice)
            {
                case TypeDevice.Flash:
                    {
                        Flash t = flashes[variant - 1];
                        int countDevice = 23;

                        Flash[] flashesD = new Flash[countDevice];
                        for (int i = 0; i < countDevice; i++)
                        {
                            flashesD[i] = t;
                            if (i == countDevice - 1)
                                flashesD[i].copyData(sizeData);

                            double currentData = flashesD[i].memory;
                            flashesD[i].copyData(flashesD[i].memory);
                        }
                    }
                    break;
                case TypeDevice.DVD:
                    break;
                case TypeDevice.HDD:
                    break;
                default:
                    break;
            }
        }
    }
}

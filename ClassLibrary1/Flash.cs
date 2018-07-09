using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackUp.Lib
{
    public class Flash: Storage
    {
        public Flash(): this(0,typeUSB.USB1) { }
        public Flash(double memory, typeUSB typeUSB) :this("","",0.0, typeUSB.USB1) { }
        public Flash(string name, string model, double memory, typeUSB typeUSB)
        {
            this.memory = memory;
            this.typeUSB = typeUSB;
            freeMemory = memory;
        }
        public typeUSB typeUSB { get; set; }
        public double memory { get; set; }

        public override double getMemory()
        {

            return memory;
        }
        public double freeMemory { get; private set; }
        public override double getFreeMemory()
        {
            return freeMemory;
        }
        public override bool copyData(double memoryData)
        {
            if (getFreeMemory() <= memoryData)
            {
               freeMemory -= memoryData;
                Console.WriteLine("Copy process");
                for (int i = 0; i < getTimeToCopy(memoryData).Minutes; i++)
                {
                    Thread.Sleep(getTimeToCopy(memoryData).Milliseconds);
                    Console.WriteLine(".");
                }
                Console.WriteLine("Copy finished");

                return true;
            }
            else
            {
                Console.WriteLine("{0}  is too large for {1} flashcard",memoryData,getFreeMemory());
                return false;
            }        
        }

        protected override TimeSpan getTimeToCopy(double memoryData)
        {            
            return TimeSpan.FromSeconds(memory/(int)typeUSB);
        }

    }
}

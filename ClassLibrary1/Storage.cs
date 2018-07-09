using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUp.Lib
{
    public enum typeUSB{ USB1=12,USB2=480, USB3=5000 }

    public enum typeDVD { SideA=5,SideB=9}
  public abstract  class Storage
    {
        public string name { get; set; }
        public string model { get; set; }

        public abstract double getMemory();
        public abstract bool copyData(double memoryData);
        public abstract double getFreeMemory();

        public virtual void BackUpInfo()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Name: \t{0}", name);
            Console.WriteLine("Model: \t{0}",model);
            Console.WriteLine("------------------------------------------");
        }

        protected abstract TimeSpan getTimeToCopy(double memoryData);
    }
}

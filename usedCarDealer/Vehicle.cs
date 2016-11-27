using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usedCarDealer
{
    public class Vehicle
    {
        public string make, model, color;
        public int purchasePrice;
        public float hstPaid;
    }

    public static class Inventory
    {
        public static List<Vehicle> vehList = new List<Vehicle>();
        public static float totalProfit;
        public static float hstCollected;
    }


    public class Compact:Vehicle
    {
        public bool isHatchBack;
    }

    public class Pickup:Vehicle
    {
        public float axleRatio;
    }


  
}

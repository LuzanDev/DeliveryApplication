using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApplication
{
    internal class Service
    {
        private static List<PackagingMaterial> materials;
        public static Image RightArrow { get; } = Image.FromFile(@"D:\arrmore.png");
        public static Image LefttArrow { get; } = Image.FromFile(@"D:\arrdown.png");
        public static string SityLocation { get; } = "Дніпро (місто)";
        public static string StockLocation { get; } = "Відділення №2: вул. Ламана, 2";
        public static List<PackagingMaterial> Materials
        {
            get { return materials; }
        }


        public Service()
        {
            materials = DataBaseControl.GetPackagings();
        }

        public static int CalcShippingCost(ParcelCategory category, Location local, float weight, int speed)
        {
            string nameColumn = ConvertToStringParcelCategory(category);
            int price = DataBaseControl.GetPriceDelivery(nameColumn,(int)local);
            if (category == ParcelCategory.huge)
            {
                price += CalcMore30Weight(weight);
            }
            if (speed > 0)
            {
                price += 20; //FastDelivery
            }
            return price;
        }

        private static int CalcMore30Weight(float weight)
        {
            int money = 0;
            weight -= 30;
            weight /= 10;
            while (weight > 0)
            {
                money += 15;
                weight--;
            }
            return money;
        }

        private static string ConvertToStringParcelCategory(ParcelCategory category)
        {
            string categoryName = "";
            if (category == ParcelCategory.documentation)
            {
                categoryName = "DocumentType";
            }
            else if (category == ParcelCategory.small)
            {
                categoryName = "SmallType";
            }
            else if (category == ParcelCategory.average)
            {
                categoryName = "AverageType";
            }
            else if (category == ParcelCategory.big)
            {
                categoryName = "BigType";
            }
            else if (category == ParcelCategory.huge)
            {
                categoryName = "HugeType";
            }
            return categoryName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
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
        private static DataTable currParcel;

        public static DataTable CurrentStockPackage
        {
            get { return currParcel; }
            private set { currParcel = value; }
        }

        public static List<PackagingMaterial> Materials
        {
            get { return materials; }
        }


        public Service()
        {
            materials = DataBaseControl.GetPackagings();
            currParcel = DataBaseControl.GetParcelCurrentStock();
            UnloadParcel();
        }

        private void UnloadParcel()
        {
            char[] simvols = { 'A', 'B', 'C', 'D', 'E', 'F' };
            Random rndchar = new Random();
            Random rndnumbers = new Random();

            foreach (DataRow row in currParcel.Rows)
            {
                int randomSimvols = rndchar.Next(0, 6);
                int randomNumbers = rndnumbers.Next(0, 31);
                string cell = simvols[randomSimvols] + "0" + randomNumbers.ToString();

                row["PDLocation"] = cell;
            }
        }

        public static int CalcShippingCost(ParcelCategory category, Location local, float weight, int speed)
        {
            string nameColumn = ConvertToStringParcelCategory(category);
            int price = DataBaseControl.GetPriceDelivery(nameColumn, (int)local);
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

        public static string CorrectNumber(string str)
        {
            return $"+38 ({str.Substring(0, 3)}) {str.Substring(3, 3)} {str.Substring(6, 2)} {str.Substring(8, 2)}";
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

        public static DataRow GetRowByUsingID(int parcelID)
        {
            DataRow rowsID = null;
            foreach (DataRow row in currParcel.Rows)
            {
                if (row["PDID"].ToString().Equals(parcelID.ToString()))
                {
                    rowsID = row;
                    break;
                }
            }
            return rowsID;
        }
    }
}

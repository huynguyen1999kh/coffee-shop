using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Menu
    {
        private string foodName;
        private int count;
        private float price;
        private float totalPrice;

        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

        public Menu(string food, int count, float price, float total = 0)
        {
            this.foodName = food;
            this.count = count;
            this.price = price;
            this.totalPrice = total;
        }

        public Menu(DataRow data)
        {
            this.foodName = data["name"].ToString();
            this.count = (int) data["count"];
            this.price = (float) double.Parse(data["price"].ToString());
            this.totalPrice = (float)double.Parse(data["price"].ToString()) * (int)data["count"];
        }
    }
}

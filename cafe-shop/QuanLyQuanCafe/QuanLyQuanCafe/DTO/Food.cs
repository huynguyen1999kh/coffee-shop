using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Food
    {
        private string name;
        private int id;
        private int idCatetory;
        private float price;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public int IdCatetory { get => idCatetory; set => idCatetory = value; }
        public float Price { get => price; set => price = value; }

        public Food(string name, int id, int idcatetory, float price)
        {
            this.name = name;
            this.id = id;
            this.idCatetory = idcatetory;
            this.price = price;
        }

        public Food(DataRow data)
        {
            this.name = data["name"].ToString();
            this.id = (int)data["id"];
            this.idCatetory = (int)data["idCatetory"];
            this.price = (float)double.Parse(data["price"].ToString());
        }
    }
}

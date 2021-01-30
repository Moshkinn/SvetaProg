﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Check
    {
        private int id;
        private string name;
        private int user;
        private int price;
        private DateTime date;
        private int type;
        public Check(int id, string name, int user , int price, DateTime date, int type)
        {
            this.id = id;
            this.name = name;
            this.user = user;
            this.price = price;
            this.date = date;
            this.type = type;
        }
        public Check(string name, int user, int price, int type)
        {
            this.name = name;
            this.user = user;
            this.price = price;
            this.date = DateTime.Now;
            this.type = type;
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int User
        {
            get { return this.user; }
            set { this.user = value; }
        }
        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}

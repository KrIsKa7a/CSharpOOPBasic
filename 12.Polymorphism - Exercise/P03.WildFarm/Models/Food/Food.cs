﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03.WildFarm.Models.Food
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}

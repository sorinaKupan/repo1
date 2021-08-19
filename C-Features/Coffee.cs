// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace C_Features
{
    internal class Coffee
    {
        public Coffee()
        {

        }
        public Coffee(string type)
        {
            this.CoffeeType = type;
        }
        public string CoffeeType { get; set; }
    }
}
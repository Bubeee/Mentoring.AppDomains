﻿using System;

namespace SomeTestAssembly
{
    public class Calculator : MarshalByRefObject
    {
        public double Add(double a, double b) 
        {
            return a + b;
        }

        public double Subtract(double a, double b) 
        {
            return a - b;
        }
        public double Multiply(double a, double b) 
        {
            return a * b;
        }
        public double Divide(double a, double b) 
        {
            return a / b;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Transaction
    {
    private float val;
    private DateTime date;

    public void setVal(float val) { this.val = val; }
    public void setDate(DateTime date) { this.date = date; }
    public float getVal() { return val; } 
    public DateTime getDate() { return date; }
    }
    
    

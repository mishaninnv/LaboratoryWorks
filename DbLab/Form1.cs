﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DbLab
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            string connectionString = @"Data Source=|DataDirectory|\Постояльцы.mdb";
            
        }

    }
}
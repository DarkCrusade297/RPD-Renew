﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPD_Renew
{
    public partial class Viewer : Form
    {
        SqlConnection sql;
        public Viewer()
        {
            InitializeComponent();
        }
    }
}

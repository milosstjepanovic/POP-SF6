﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POP_SF_06_2016_GUI.GUI
{
    /// <summary>
    /// Interaction logic for ProdavacWindow.xaml
    /// </summary>
    public partial class ProdavacWindow : Window
    {
        public ProdavacWindow()
        {
            InitializeComponent();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

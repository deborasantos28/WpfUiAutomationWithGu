﻿using System;
using System.Windows;

namespace WpfUiAutomationWithGu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSayHello(object sender, RoutedEventArgs e)
        {
            txtResult.Text = $"Hello {txtName.Text}";
        }
    }
}

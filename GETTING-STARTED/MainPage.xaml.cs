﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GETTING_STARTED
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // https://docs.microsoft.com/en-us/windows/uwp/get-started/display-customers-in-list-learning-track

        public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();

        public MainPage()
        {
            this.InitializeComponent();

            // Add some customers
            this.Customers.Add(new Customer() { Name = "NAME1" });
            this.Customers.Add(new Customer() { Name = "NAME2" });
            this.Customers.Add(new Customer() { Name = "NAME3" });
        }
    }
}

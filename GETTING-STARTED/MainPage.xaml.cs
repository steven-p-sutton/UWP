﻿using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsTaskSnippets.AppSettings; // LIBRARY

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

        private AppSettings _AppSettings = new AppSettings(AppSettings.Type.Roaming);

        // XMAL binds to these
        string _AssociateName = string.Empty;
        //string _TargetInstallDate = string.Empty;
        DateTimeOffset _TargetInstallDate = DateTime.Now;
        string _InstallTime = string.Empty;

        public MainPage()
        {
            this.InitializeComponent();

            // FIXED PAGE CONTENT
            // https://docs.microsoft.com/en-us/windows/uwp/get-started/display-customers-in-list-learning-track

            // Add some customers
            this.Customers.Add(new Customer() { Name = "NAME1" });
            this.Customers.Add(new Customer() { Name = "NAME2" });
            this.Customers.Add(new Customer() { Name = "NAME3" });

            //// DYNAMIC PAGE CONTENT 
            //// https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/listview-and-gridview

            //// Add some customers
            //this.Customers.Add(new Customer() { Name = "NAME1" });
            //this.Customers.Add(new Customer() { Name = "NAME2" });
            //this.Customers.Add(new Customer() { Name = "NAME3" });

            //// Create a new ListView (or GridView) for the UI
            //ListView ContactsLV = new ListView();
            //ContactsLV = new ListView();

            //// Add content by setting ItemsSource
            //ContactsLV.ItemsSource = Customers;

            //// Add the ListView to a parent container in the visual tree (that you created in the corresponding XAML file)
            //NameStack.Children.Add(ContactsLV);

            //// Style ListView
            //ContactsLV.VerticalAlignment = VerticalAlignment.Center;
            //ContactsLV.HorizontalAlignment = HorizontalAlignment.Center;

            ////for (int i = 0; i < NameStack.Children.Count; i++)
            ////{
            ////    NameStack.Children[i].AccessKey.ToString();
            ////}

            // Read settings 
            _AssociateName = _AppSettings.GetSetting("AssociateName");
            _TargetInstallDate = DateTimeOffset.Parse(_AppSettings.GetSetting("TargetInstallDate"));

            _InstallTime = "InstallTime";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _AppSettings.SaveSetting("AssociateName", _AssociateName);
            _AppSettings.SaveSetting("TargetInstallDate", _TargetInstallDate.ToString());
        }
    }


}

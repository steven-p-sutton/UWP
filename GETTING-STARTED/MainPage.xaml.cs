﻿using System;
using System.Collections.Generic;
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

        // Homegrown class in LIBRARY to encapsulate the .Core Settings API
        // https://docs.microsoft.com/en-us/windows/uwp/get-started/settings-learning-track

        private AppSettings _AppSettings = new AppSettings(AppSettings.Type.Roaming);

        // Homegrown class in LIBRARY to encapsulate the .Core File API 
        // https://docs.microsoft.com/en-us/windows/uwp/get-started/fileio-learning-track

        private AppFiles _AppFiles = new AppFiles();

        // XMAL binds to these
        string _AssociateName = string.Empty;
        DateTimeOffset _TargetInstallDate = DateTime.Now;
        TimeSpan _InstallTime = TimeSpan.Zero;

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

            try
            {
                // Read settings 
                _AssociateName = _AppSettings.GetSetting("AssociateName");
            }
            catch
            {
                _AssociateName = string.Empty;
            }

            try
            {
                _TargetInstallDate = DateTimeOffset.Parse(_AppSettings.GetSetting("TargetInstallDate"));
            }
            catch
            {
                _TargetInstallDate = DateTime.Today;
            }

            try
            {
                //_InstallTime = "InstallTime";
                _InstallTime = TimeSpan.Parse(_AppSettings.GetSetting("InstallTime"));
            }
            catch
            {
                _InstallTime = TimeSpan.Zero;
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _AppSettings.SaveSetting("AssociateName", _AssociateName);
            _AppSettings.SaveSetting("TargetInstallDate", _TargetInstallDate.ToString());
            _AppSettings.SaveSetting("InstallTime", _InstallTime.ToString());

            _AppFiles.WriteFileAsync();
            _AppFiles.ReadFileAsync();
        }
    }

    public class AppFiles
    {
        public AppFiles()
        {
        }
        public async System.Threading.Tasks.Task WriteFileAsync()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.CreateFileAsync
            (
                "test.txt",
                Windows.Storage.CreationCollisionOption.OpenIfExists
            );

            await Windows.Storage.FileIO.WriteTextAsync(file, "Example of writing a string\r\n");

            // Append a list of strings, one per line, to the file
            var listOfStrings = new List<string> { "line1", "line2", "line3" };
            await Windows.Storage.FileIO.AppendLinesAsync(file, listOfStrings); // each entry in the list is written to the file on its own line.
        }
        public async System.Threading.Tasks.Task ReadFileAsync()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync("test.txt");

            string text = await Windows.Storage.FileIO.ReadTextAsync(file);
            // You can also read each line of the file into individual strings in a collection with 
            // IList<string> contents = await Windows.Storage.FileIO.ReadLinesAsync(sampleFile);
        }
    }
}

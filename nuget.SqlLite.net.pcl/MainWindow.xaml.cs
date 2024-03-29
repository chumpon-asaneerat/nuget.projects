﻿#region Using

using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

#endregion

using SQLite;

namespace nuget.SqlLite.net.pcl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Run();
        }

        #endregion

        #region Private Methods

        class Role
        {
            public string RoleId { get; set; }
        }

        private void Run()
        {
            // Note: native dll need to manual copy from 
            // SQLitePCLRaw.lib.e_sqlite3.2.1.2 in runtimes folder
            var _db = new SQLiteConnection("./data/TA.db");
            var role = _db.Query<Role>("SELECT * FROM Role WHERE RoleId = $id", "ADMINS").FirstOrDefault();
            if (null != role)
            {
                Console.WriteLine($"Hello, {role.RoleId}!");
            }
            else
            {
                Console.WriteLine($"No one here!");
            }
            _db.Close();
            _db  = null;

        }

        #endregion
    }
}

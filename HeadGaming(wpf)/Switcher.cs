﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace HeadGaming_wpf_
{
    public static class Switcher
    {
        public static MainWindow pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }
    }
}
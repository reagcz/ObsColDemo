﻿using System;
using System.Diagnostics;
using System.Windows.Controls;

using MahApps.Metro.Controls;

using ObsTest.Contracts.Views;

namespace ObsTest.Views
{
    public partial class ShellWindow : MetroWindow, IShellWindow
    {
        public ShellWindow()
        {
            InitializeComponent();
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();
    }
}

﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace MailSender.Controls
{
    /// <summary>
    /// Логика взаимодействия для TabItemsSwitcher.xaml
    /// </summary>
    public partial class TabItemsSwitcher
    {
        public event EventHandler LeftButtonClick;
        public event EventHandler RightButtonClick;

        #region Видимость правой и левой кнопок
        public bool LeftButtonVisible                               
        {
            get => LeftButton.Visibility == Visibility;
            set => LeftButton.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public bool RightButtonVisible
        {
            get => RightButton.Visibility == Visibility;
            set => RightButton.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion

        public TabItemsSwitcher() => InitializeComponent();

        /// <summary>
        /// Нажатие кнопки перехода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(e.Source is Button button)) return;

            switch (button.Name)
            {
                case "LeftButton":
                    LeftButtonClick?.Invoke(this, EventArgs.Empty);
                    break;

                case "RightButton":
                    RightButtonClick?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }
    }
}

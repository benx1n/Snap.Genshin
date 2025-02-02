﻿using DGP.Genshin.Helpers;
using DGP.Genshin.Pages;
using ModernWpf.Controls;
using ModernWpf.Media.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DGP.Genshin.Services
{
    public class NavigationService
    {
        private readonly Frame frame;
        private readonly NavigationView navigationView;
        private readonly Stack<NavigationViewItem> backItemStack = new Stack<NavigationViewItem>();

        private NavigationViewItem selected;

        public NavigationService(Window window, NavigationView navigationView, Frame frame)
        {
            Current = Current == null ? this : throw new InvalidOperationException($"{nameof(NavigationService)}的实例在运行期间仅允许创建一次");
            this.navigationView = navigationView;
            this.frame = frame;

            this.navigationView.ItemInvoked += this.OnItemInvoked;
        }

        public static NavigationService Current;

        public void SyncTabWith(Type pageType)
        {
            if (pageType == typeof(SettingsPage) || pageType == null)
            {
                this.navigationView.SelectedItem = this.navigationView.SettingsItem;
            }
            else
            {
                NavigationViewItem target = this.navigationView.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(menuItem => ((Type)menuItem.GetValue(NavHelper.NavigateToProperty)) == pageType);
                this.navigationView.SelectedItem = target;
            }

            this.selected = this.navigationView.SelectedItem as NavigationViewItem;
        }

        public bool Navigate(Type pageType, bool isSyncTabRequested = false, object data = null, NavigationTransitionInfo info = null)
        {
            if (this.frame.Content?.GetType() == pageType)
            {
                return false;
            }
            if (isSyncTabRequested)
            {
                this.SyncTabWith(pageType);
            }
            this.backItemStack.Push(this.selected);
            bool result = this.frame.Navigate(pageType, data, info);
            this.frame.RemoveBackEntry();
            return result;
        }
        public bool Navigate<T>(bool isSyncTabRequested = false, object data = null, NavigationTransitionInfo info = null) where T : System.Windows.Controls.Page => this.Navigate(typeof(T), isSyncTabRequested, data, info);

        private void OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            this.selected = this.navigationView.SelectedItem as NavigationViewItem;
            if (args.IsSettingsInvoked)
            {
                this.Navigate<SettingsPage>();
            }
            else
            {
                this.Navigate(this.selected.GetValue(NavHelper.NavigateToProperty) as Type);
            }
        }
    }
}

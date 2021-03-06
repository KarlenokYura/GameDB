﻿#pragma checksum "..\..\Location.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81B3B9970F9F11BA6450099681DDACB78E3E921F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GameDB;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GameDB {
    
    
    /// <summary>
    /// Location
    /// </summary>
    public partial class Location : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Location.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border locationBorder;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Location.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image locationIcon;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Location.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock locationName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Location.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock locationMinLevel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Location.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock locationMaxLevel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Location.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock locationDimension;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Location.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock locationWay;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Location.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button locateButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Location.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button monstersButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Location.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button npcsButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GameDB;component/location.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Location.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\Location.xaml"
            ((GameDB.Location)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.LocationMouseEnter);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Location.xaml"
            ((GameDB.Location)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.LocationMouseLeave);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Location.xaml"
            ((GameDB.Location)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.locationBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.locationIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.locationName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.locationMinLevel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.locationMaxLevel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.locationDimension = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.locationWay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.locateButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Location.xaml"
            this.locateButton.Click += new System.Windows.RoutedEventHandler(this.LocateClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.monstersButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Location.xaml"
            this.monstersButton.Click += new System.Windows.RoutedEventHandler(this.MonstersClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.npcsButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Location.xaml"
            this.npcsButton.Click += new System.Windows.RoutedEventHandler(this.NPCsClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


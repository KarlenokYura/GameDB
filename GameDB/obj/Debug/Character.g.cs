﻿#pragma checksum "..\..\Character.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8080B4CFD10EFB2BA68FE8220108F2B07443553E"
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
    /// Character
    /// </summary>
    public partial class Character : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Character.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border characterBorder;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Character.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image characterIcon;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Character.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock characterName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Character.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock characterRace;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Character.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock characterClass;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Character.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock characterLocation;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Character.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock characterLevel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Character.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button playButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Character.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button changeButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Character.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
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
            System.Uri resourceLocater = new System.Uri("/GameDB;component/character.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Character.xaml"
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
            
            #line 8 "..\..\Character.xaml"
            ((GameDB.Character)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.CharacterMouseEnter);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Character.xaml"
            ((GameDB.Character)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.CharacterMouseLeave);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Character.xaml"
            ((GameDB.Character)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.characterBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.characterIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.characterName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.characterRace = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.characterClass = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.characterLocation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.characterLevel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.playButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Character.xaml"
            this.playButton.Click += new System.Windows.RoutedEventHandler(this.PlayClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.changeButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Character.xaml"
            this.changeButton.Click += new System.Windows.RoutedEventHandler(this.ChangeClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Character.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.DeleteClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


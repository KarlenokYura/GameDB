﻿#pragma checksum "..\..\NPC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D8BE7EDBDE07BA4E24DA5C5277C05AD49476688D"
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
    /// NPC
    /// </summary>
    public partial class NPC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\NPC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border npcBorder;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\NPC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image npcIcon;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NPC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock npcName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\NPC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock npcRace;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\NPC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock npcProfession;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\NPC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock npcLocation;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\NPC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock npcLevel;
        
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
            System.Uri resourceLocater = new System.Uri("/GameDB;component/npc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NPC.xaml"
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
            
            #line 8 "..\..\NPC.xaml"
            ((GameDB.NPC)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.NPCMouseEnter);
            
            #line default
            #line hidden
            
            #line 8 "..\..\NPC.xaml"
            ((GameDB.NPC)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.NPCMouseLeave);
            
            #line default
            #line hidden
            
            #line 8 "..\..\NPC.xaml"
            ((GameDB.NPC)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.npcBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.npcIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.npcName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.npcRace = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.npcProfession = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.npcLocation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.npcLevel = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


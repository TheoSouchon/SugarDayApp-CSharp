﻿#pragma checksum "..\..\..\..\AjouterIngredient.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "649C943F60670899689072A363329D350DB84DD0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using CsharpCode;
using SugarDay;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace SugarDay {
    
    
    /// <summary>
    /// AjouterIngredient
    /// </summary>
    public partial class AjouterIngredient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\AjouterIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridTotal;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\AjouterIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\AjouterIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Aliment_nom;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\AjouterIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Titre2;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\AjouterIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Titre3;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\AjouterIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Quantité_Ing;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\AjouterIngredient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Unité_select;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SugarDay;component/ajouteringredient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\AjouterIngredient.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GridTotal = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Image = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.Aliment_nom = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Titre2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Titre3 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Quantité_Ing = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\..\AjouterIngredient.xaml"
            this.Quantité_Ing.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.QuantiteIng_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Unité_select = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            
            #line 56 "..\..\..\..\AjouterIngredient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Ajout_confirmation);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

#pragma checksum "..\..\..\..\..\Components\Authorization\RegisterComponent.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "870477D82F388086571229B3EB4EA8A4DB2663ED"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DEDSEC.WPF.Components.Common;
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


namespace DEDSEC.WPF.Components.Authorization {
    
    
    /// <summary>
    /// RegisterComponent
    /// </summary>
    public partial class RegisterComponent : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\..\..\Components\Authorization\RegisterComponent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxNickname;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\Components\Authorization\RegisterComponent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DEDSEC.WPF.Components.Common.BindablePasswordBox textBoxPassword;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\Components\Authorization\RegisterComponent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DEDSEC.WPF.Components.Common.BindablePasswordBox textBoxConfirmPassword;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\..\Components\Authorization\RegisterComponent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DEDSEC.WPF.Components.Common.BindablePasswordBox textBoxAdministrationCode;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DEDSEC.WPF;component/components/authorization/registercomponent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Components\Authorization\RegisterComponent.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBoxNickname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.textBoxPassword = ((DEDSEC.WPF.Components.Common.BindablePasswordBox)(target));
            return;
            case 3:
            this.textBoxConfirmPassword = ((DEDSEC.WPF.Components.Common.BindablePasswordBox)(target));
            return;
            case 4:
            this.textBoxAdministrationCode = ((DEDSEC.WPF.Components.Common.BindablePasswordBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


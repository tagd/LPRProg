﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterEtUI.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SeaShell")]
        public global::System.Drawing.Color dyslBackground {
            get {
                return ((global::System.Drawing.Color)(this["dyslBackground"]));
            }
            set {
                this["dyslBackground"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Gray")]
        public global::System.Drawing.Color nonDysBack {
            get {
                return ((global::System.Drawing.Color)(this["nonDysBack"]));
            }
            set {
                this["nonDysBack"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("nonDysBack")]
        public string SelectedBackground {
            get {
                return ((string)(this["SelectedBackground"]));
            }
            set {
                this["SelectedBackground"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Microsoft Sans Serif, 8.25pt")]
        public global::System.Drawing.Font nonDysFont {
            get {
                return ((global::System.Drawing.Font)(this["nonDysFont"]));
            }
            set {
                this["nonDysFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Microsoft Sans Serif, 14.25pt")]
        public global::System.Drawing.Font dyslFont {
            get {
                return ((global::System.Drawing.Font)(this["dyslFont"]));
            }
            set {
                this["dyslFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("nonDysFont")]
        public string SelectedFont {
            get {
                return ((string)(this["SelectedFont"]));
            }
            set {
                this["SelectedFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\LPRProg\\v1.2\\MasterEtUI\\Pl" +
            "ateRecognitionDatabase.mdf;Integrated Security=True")]
        public string SQLConnectionStr {
            get {
                return ((string)(this["SQLConnectionStr"]));
            }
            set {
                this["SQLConnectionStr"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("G:\\LPRProg\\v1.2\\")]
        public string ProjectPath {
            get {
                return ((string)(this["ProjectPath"]));
            }
            set {
                this["ProjectPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CPPFontPath {
            get {
                return ((string)(this["CPPFontPath"]));
            }
            set {
                this["CPPFontPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CPPImgPath {
            get {
                return ((string)(this["CPPImgPath"]));
            }
            set {
                this["CPPImgPath"] = value;
            }
        }
    }
}

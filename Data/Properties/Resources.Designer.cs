﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Data.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to admin@gmail.com.
        /// </summary>
        internal static string adminEmail {
            get {
                return ResourceManager.GetString("adminEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Admin123#.
        /// </summary>
        internal static string adminPassword {
            get {
                return ResourceManager.GetString("adminPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Admin.
        /// </summary>
        internal static string adminRoleName {
            get {
                return ResourceManager.GetString("adminRoleName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Change cannot be made since target entity has foreign entities.
        /// </summary>
        internal static string CascadeDeleteException {
            get {
                return ResourceManager.GetString("CascadeDeleteException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Source object wasn&apos;t provided..
        /// </summary>
        internal static string ItemNotProvidedExceptionMessage {
            get {
                return ResourceManager.GetString("ItemNotProvidedExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Authorization Required.
        /// </summary>
        internal static string NotAuthorizedException {
            get {
                return ResourceManager.GetString("NotAuthorizedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specified entity not found..
        /// </summary>
        internal static string NotFoundExceptionMessage {
            get {
                return ResourceManager.GetString("NotFoundExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User.
        /// </summary>
        internal static string userRoleName {
            get {
                return ResourceManager.GetString("userRoleName", resourceCulture);
            }
        }
    }
}
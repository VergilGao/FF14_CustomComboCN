/*
 * filename: ParentComboAttribute.cs
 * maintainer: VergilGao
 * description:
 *  父连击，只有当父连击启用时此连击才可用
 */

using System;

namespace CustomComboPlugin.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class ParentComboAttribute : Attribute
    {
        public ParentComboAttribute(ushort parentID)
        {
            ParentID = parentID;
        }

        public ushort ParentID { get; }
    }
}
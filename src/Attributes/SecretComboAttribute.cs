/*
 * filename: ObsoluteComboAttribute.cs
 * maintainer: VergilGao
 * description:
 *  将连击标记为秘密
 */

using System;

namespace CustomComboPlugin.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class SecretComboAttribute : Attribute
    {
    }
}
/*
 * filename: ObsoluteComboAttribute.cs
 * maintainer: VergilGao
 * description:
 *  将连击标记为过期，版本更新后维护者没有时间维护
 */

using System;

namespace CustomComboPlugin.Attributes
{
    /// <summary>
    /// 将连击标记为过期
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class ObsoluteComboAttribute : Attribute
    {
    }
}
/*
 * filename: CustomComboInfoAttribute.cs
 * maintainer: VergilGao
 * description:
 *  连击的基本信息
 */

using System;

namespace CustomComboPlugin.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class CustomComboInfoAttribute : Attribute
    {
        public CustomComboInfoAttribute(string name, string description, byte jobId, ushort comboId, int order)
        {
            Name = name;
            Description = description;
            JobId = jobId;
            ComboId = comboId;
            Order = order;
        }

        public string Name { get; }
        public string Description { get; }
        public byte JobId { get; }
        public ushort ComboId { get; }
        public int Order { get; }
    }
}
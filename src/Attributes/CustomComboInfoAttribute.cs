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
        public CustomComboInfoAttribute(string name, string description, byte jobID, ushort comboID, int order)
        {
            Name = name;
            Description = description;
            JobID = jobID;
            ComboID = comboID;
            Order = order;
        }

        public string Name { get; }
        public string Description { get; }
        public byte JobID { get; }
        public ushort ComboID { get; }
        public int Order { get; }
    }
}
/*
 * filename: ConflictToGroupAttribute.cs
 * maintainer: VergilGao
 * description:
 *  与某个连击相互冲突
 *  可能与不同的连击相互冲突
 */

using System;

namespace CustomComboPlugin.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    internal sealed class ConflictComboAttribute : Attribute
    {
        public ConflictComboAttribute(ushort conflictId)
        {
            ConflictId = conflictId;
        }

        public ushort ConflictId { get; }
    }
}
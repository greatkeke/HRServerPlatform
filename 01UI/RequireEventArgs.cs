using System;

namespace _01UI
{
    internal class RequireEventArgs : EventArgs
    {
        internal Guid ID { get; set; }
        internal String Title { get; set; }
    }
}
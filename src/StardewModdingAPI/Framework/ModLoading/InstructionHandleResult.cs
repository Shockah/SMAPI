namespace StardewModdingAPI.Framework.ModLoading
{
    /// <summary>Indicates how an instruction was handled.</summary>
    internal enum InstructionHandleResult
    {
        /// <summary>No special handling is needed.</summary>
        None,

        /// <summary>The instruction was successfully rewritten for compatibility.</summary>
        Rewritten,

        /// <summary>The instruction is not compatible and can't be rewritten for compatibility.</summary>
        NotCompatible
    }
}

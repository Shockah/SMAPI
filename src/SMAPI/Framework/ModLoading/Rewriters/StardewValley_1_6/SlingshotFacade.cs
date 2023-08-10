using System.Diagnostics.CodeAnalysis;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley.Tools;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="Slingshot"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class SlingshotFacade : Slingshot
    {
        /*********
        ** Public methods
        *********/
        public static Slingshot Constructor(int which = 32)
        {
            return new Slingshot(which.ToString());
        }


        /*********
        ** Private methods
        *********/
        private SlingshotFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

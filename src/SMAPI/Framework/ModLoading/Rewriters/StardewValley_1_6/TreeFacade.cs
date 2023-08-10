using System.Diagnostics.CodeAnalysis;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.TerrainFeatures;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="Tree"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class TreeFacade : Tree
    {
        /*********
        ** Public methods
        *********/
        public static Tree Constructor(int which)
        {
            return new Tree(which.ToString());
        }

        public static Tree Constructor(int which, int growthStage)
        {
            return new Tree(which.ToString(), growthStage);
        }

        public bool fertilize(GameLocation location)
        {
            return base.fertilize();
        }


        /*********
        ** Private methods
        *********/
        private TreeFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

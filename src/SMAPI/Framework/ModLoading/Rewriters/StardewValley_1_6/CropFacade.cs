using System.Diagnostics.CodeAnalysis;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="Crop"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class CropFacade : Crop
    {
        /*********
        ** Public methods
        *********/
        public static Crop Constructor(bool forageCrop, int which, int tileX, int tileY)
        {
            return new Crop(forageCrop, which.ToString(), tileX, tileY, Game1.currentLocation);
        }

        public static Crop Constructor(int seedIndex, int tileX, int tileY)
        {
            return new Crop(seedIndex.ToString(), tileX, tileY, Game1.currentLocation);
        }


        /*********
        ** Private methods
        *********/
        private CropFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

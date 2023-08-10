using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.TerrainFeatures;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="HoeDirt"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class HoeDirtFacade : HoeDirt
    {
        /*********
        ** Public methods
        *********/
        public void destroyCrop(Vector2 tileLocation, bool showAnimation, GameLocation location)
        {
            base.destroyCrop(showAnimation);
        }

        public bool paddyWaterCheck(GameLocation location, Vector2 tile_location)
        {
            return base.paddyWaterCheck();
        }

        public bool plant(int index, int tileX, int tileY, Farmer who, bool isFertilizer, GameLocation location)
        {
            return base.plant(index.ToString(), who, isFertilizer);
        }


        /*********
        ** Private methods
        *********/
        private HoeDirtFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

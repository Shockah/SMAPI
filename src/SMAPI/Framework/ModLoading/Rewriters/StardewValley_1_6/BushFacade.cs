using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.TerrainFeatures;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="Bush"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class BushFacade : Bush
    {
        /*********
        ** Public methods
        *********/
        public bool inBloom(string season, int dayOfMonth)
        {
            // call new method if possible
            if (season == Game1.currentSeason && dayOfMonth == Game1.dayOfMonth)
                return this.inBloom();

            // else mimic old behavior with 1.6 features
            if (this.size == Bush.greenTeaBush)
            {
                return
                    this.getAge() >= Bush.daysToMatureGreenTeaBush
                    && dayOfMonth >= 22
                    && (season != "winter" || this.IsSheltered());
            }

            switch (season)
            {
                case "spring":
                    return dayOfMonth > 14 && dayOfMonth < 19;

                case "fall":
                    return dayOfMonth > 7 && dayOfMonth < 12;

                default:
                    return false;
            }
        }

        public bool isDestroyable(GameLocation location, Vector2 tile)
        {
            return base.isDestroyable();
        }


        /*********
        ** Private methods
        *********/
        private BushFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

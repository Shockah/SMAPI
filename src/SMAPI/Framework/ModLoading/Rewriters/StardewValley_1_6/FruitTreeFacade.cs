using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Netcode;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6.Internal;
using StardewValley;
using StardewValley.TerrainFeatures;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="FruitTree"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class FruitTreeFacade : FruitTree
    {
        /*********
        ** Accessors
        *********/
        public NetString fruitSeason
        {
            get
            {
                List<Season>? seasons = this.GetData()?.Seasons;
                string value = seasons?.Count > 0
                    ? string.Join(",", seasons)
                    : string.Empty;

                return new ReadOnlyValueToNetString($"{nameof(FruitTree)}.{nameof(this.fruitSeason)}", value);
            }
        }


        /*********
        ** Private methods
        *********/
        private FruitTreeFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

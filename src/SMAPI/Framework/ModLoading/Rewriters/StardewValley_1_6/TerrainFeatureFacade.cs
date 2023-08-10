using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.TerrainFeatures;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="TerrainFeature"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class TerrainFeatureFacade : TerrainFeature
    {
        /*********
        ** Public methods
        *********/
        public virtual void dayUpdate(GameLocation environment, Vector2 tileLocation)
        {
            base.dayUpdate();
        }

        public Rectangle getBoundingBox(Vector2 tileLocation)
        {
            return base.getBoundingBox();
        }

        public virtual bool performToolAction(Tool t, int damage, Vector2 tileLocation, GameLocation location)
        {
            return base.performToolAction(t, damage, tileLocation);
        }

        public virtual bool performUseAction(Vector2 tileLocation, GameLocation location)
        {
            return base.performUseAction(tileLocation);
        }


        /*********
        ** Private methods
        *********/
        private TerrainFeatureFacade()
            : base(false)
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

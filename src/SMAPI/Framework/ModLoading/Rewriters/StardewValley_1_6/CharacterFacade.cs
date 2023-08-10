using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="Character"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class CharacterFacade : Character
    {
        /*********
        ** Public methods
        *********/
        public int getStandingX()
        {
            return this.StandingPixel.X;
        }

        public int getStandingY()
        {
            return this.StandingPixel.Y;
        }

        public Point getStandingXY()
        {
            return this.StandingPixel;
        }

        public Vector2 getTileLocation()
        {
            return this.Tile;
        }

        public Point getTileLocationPoint()
        {
            return this.TilePoint;
        }

        public int getTileX()
        {
            return this.TilePoint.X;
        }

        public int getTileY()
        {
            return this.TilePoint.Y;
        }


        /*********
        ** Private methods
        *********/
        private CharacterFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

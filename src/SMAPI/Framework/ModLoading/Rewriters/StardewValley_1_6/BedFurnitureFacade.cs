using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.Objects;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="BedFurniture"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class BedFurnitureFacade : BedFurniture
    {
        /*********
        ** Public methods
        *********/
        public static BedFurniture Constructor(int which, Vector2 tile, int initialRotations)
        {
            return new BedFurniture(which.ToString(), tile, initialRotations);
        }

        public static BedFurniture Constructor(int which, Vector2 tile)
        {
            return new BedFurniture(which.ToString(), tile);
        }

        public bool CanModifyBed(GameLocation location, Farmer who)
        {
            return this.CanModifyBed(who);
        }

        public bool IsBeingSleptIn(GameLocation location)
        {
            return this.IsBeingSleptIn();
        }


        /*********
        ** Private methods
        *********/
        private BedFurnitureFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

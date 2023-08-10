using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.Objects;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="Furniture"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class FurnitureFacade : Furniture
    {
        /*********
        ** Public methods
        *********/
        public static Furniture Constructor(int which, Vector2 tile, int initialRotations)
        {
            return new Furniture(which.ToString(), tile, initialRotations);
        }

        public static Furniture Constructor(int which, Vector2 tile)
        {
            return new Furniture(which.ToString(), tile);
        }

        public void AddLightGlow(GameLocation location)
        {
            this.AddLightGlow();
        }

        public void addLights(GameLocation environment)
        {
            this.addLights();
        }

        public static Furniture GetFurnitureInstance(int index, Vector2? position = null)
        {
            return Furniture.GetFurnitureInstance(index.ToString(), position);
        }

        public void removeLights(GameLocation environment)
        {
            this.removeLights();
        }

        public void RemoveLightGlow(GameLocation location)
        {
            this.RemoveLightGlow();
        }

        public void setFireplace(GameLocation location, bool playSound = true, bool broadcast = false)
        {
            this.setFireplace(playSound, broadcast);
        }


        /*********
        ** Private methods
        *********/
        private FurnitureFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

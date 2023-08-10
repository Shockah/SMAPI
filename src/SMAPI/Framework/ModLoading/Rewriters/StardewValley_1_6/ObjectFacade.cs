using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using SObject = StardewValley.Object;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="SObject"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "IdentifierTypo", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "ParameterHidesMember", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    [SuppressMessage("ReSharper", "UnusedParameter.Local", Justification = SuppressReasons.MatchesOriginal)]
    public class ObjectFacade : SObject
    {
        /*********
        ** Public methods
        *********/
        public static SObject Constructor(Vector2 tileLocation, int parentSheetIndex, bool isRecipe = false)
        {
            return new SObject(tileLocation, parentSheetIndex.ToString(), isRecipe);
        }

        public static SObject Constructor(int parentSheetIndex, int initialStack, bool isRecipe = false, int price = -1, int quality = 0)
        {
            return new SObject(parentSheetIndex.ToString(), initialStack, isRecipe, price, quality);
        }

        public static SObject Constructor(Vector2 tileLocation, int parentSheetIndex, int initialStack)
        {
            SObject obj = Constructor(tileLocation, parentSheetIndex, null, true, true, false, false);
            obj.stack.Value = initialStack;
            return obj;
        }

        public static SObject Constructor(Vector2 tileLocation, int parentSheetIndex, string? Givenname, bool canBeSetDown, bool canBeGrabbed, bool isHoedirt, bool isSpawnedObject)
        {
            SObject obj = new SObject(parentSheetIndex.ToString(), 1);

            if (Givenname != null && obj.name is (null or "Error Item"))
                obj.name = Givenname;

            obj.tileLocation.Value = tileLocation;
            obj.canBeSetDown.Value = canBeSetDown;
            obj.canBeGrabbed.Value = canBeGrabbed;
            obj.isSpawnedObject.Value = isSpawnedObject;

            return obj;
        }

        public void ApplySprinkler(GameLocation location, Vector2 tile)
        {
            this.ApplySprinkler(tile);
        }

        public void DayUpdate(GameLocation location)
        {
            this.DayUpdate();
        }

        public Rectangle getBoundingBox(Vector2 tileLocation)
        {
            return base.GetBoundingBoxAt((int)tileLocation.X, (int)tileLocation.Y);
        }

        public bool isForage(GameLocation location)
        {
            return this.isForage();
        }

        public bool minutesElapsed(int minutes, GameLocation environment)
        {
            return this.minutesElapsed(minutes);
        }

        public bool onExplosion(Farmer who, GameLocation location)
        {
            return this.onExplosion(who);
        }

        public void performRemoveAction(Vector2 tileLocation, GameLocation environment)
        {
            this.performRemoveAction();
        }

        public bool performToolAction(Tool t, GameLocation location)
        {
            return this.performToolAction(t);
        }

        public void updateWhenCurrentLocation(GameTime time, GameLocation environment)
        {
            this.updateWhenCurrentLocation(time);
        }


        /*********
        ** Private methods
        *********/
        private ObjectFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

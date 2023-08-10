using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Netcode;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.Audio;
using StardewValley.Extensions;
using StardewValley.Objects;
using xTile.Dimensions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="GameLocation"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "IdentifierTypo", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "ParameterHidesMember", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "PossibleLossOfFraction", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class GameLocationFacade : GameLocation
    {
        /*********
        ** Public methods
        *********/
        public NetCollection<NPC> getCharacters()
        {
            return this.characters;
        }

        public virtual int getExtraMillisecondsPerInGameMinuteForThisLocation()
        {
            return base.ExtraMillisecondsPerInGameMinute;
        }

        public int getNumberBuildingsConstructed(string name)
        {
            return base.getNumberBuildingsConstructed(name, false);
        }

        public string GetSeasonForLocation()
        {
            return this.GetSeasonKey();
        }

        public bool isTileLocationOpenIgnoreFrontLayers(Location tile)
        {
            return this.map.RequireLayer("Buildings").Tiles[tile.X, tile.Y] == null && !this.isWaterTile(tile.X, tile.Y);
        }

        public bool isTileLocationTotallyClearAndPlaceable(int x, int y)
        {
            return this.isTileLocationTotallyClearAndPlaceable(new Vector2(x, y));
        }

        public bool isTileLocationTotallyClearAndPlaceable(Vector2 v)
        {
            Vector2 pixel = new Vector2((v.X * Game1.tileSize) + Game1.tileSize / 2, (v.Y * Game1.tileSize) + Game1.tileSize / 2);
            foreach (Furniture f in this.furniture)
            {
                if (f.furniture_type != Furniture.rug && !f.isPassable() && f.GetBoundingBox().Contains((int)pixel.X, (int)pixel.Y) && !f.AllowPlacementOnThisTile((int)v.X, (int)v.Y))
                    return false;
            }

            return this.isTileOnMap(v) && !this.isTileOccupied(v) && this.isTilePassable(new Location((int)v.X, (int)v.Y), Game1.viewport) && base.isTilePlaceable(v);
        }

        public bool isTileLocationTotallyClearAndPlaceableIgnoreFloors(Vector2 v)
        {
            return this.isTileOnMap(v) && !this.isTileOccupiedIgnoreFloors(v) && this.isTilePassable(new Location((int)v.X, (int)v.Y), Game1.viewport) && base.isTilePlaceable(v);
        }

        public bool isTileOccupied(Vector2 tileLocation, string characterToIgnore = "", bool ignoreAllCharacters = false)
        {
            CollisionMask mask = ignoreAllCharacters ? CollisionMask.All & ~CollisionMask.Characters & ~CollisionMask.Farmers : CollisionMask.All;
            return base.IsTileOccupiedBy(tileLocation, mask);
        }

        public bool isTileOccupiedForPlacement(Vector2 tileLocation, Object? toPlace = null)
        {
            return base.CanItemBePlacedHere(tileLocation, toPlace != null && toPlace.isPassable());
        }

        public bool isTileOccupiedIgnoreFloors(Vector2 tileLocation, string characterToIgnore = "")
        {
            return base.IsTileOccupiedBy(tileLocation, CollisionMask.Buildings | CollisionMask.Furniture | CollisionMask.Objects | CollisionMask.Characters | CollisionMask.TerrainFeatures, ignorePassables: CollisionMask.Flooring);
        }

        public void localSound(string audioName)
        {
            base.localSound(audioName);
        }

        public void localSoundAt(string audioName, Vector2 position)
        {
            base.localSound(audioName, position);
        }

        public void playSound(string audioName, SoundContext soundContext = SoundContext.Default)
        {
            base.playSound(audioName, context: soundContext);
        }

        public void playSoundAt(string audioName, Vector2 position, SoundContext soundContext = SoundContext.Default)
        {
            base.playSound(audioName, position, context: soundContext);
        }

        public void playSoundPitched(string audioName, int pitch, SoundContext soundContext = SoundContext.Default)
        {
            base.playSound(audioName, pitch: pitch, context: soundContext);
        }


        /*********
        ** Private methods
        *********/
        private GameLocationFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

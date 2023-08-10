using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Netcode;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6.Internal;
using StardewValley;
using StardewValley.Objects;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="Chest"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "IdentifierTypo", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    [SuppressMessage("ReSharper", "UnusedParameter.Local", Justification = SuppressReasons.MatchesOriginal)]
    public class ChestFacade : Chest
    {
        /*********
        ** Accessors
        *********/
        public NetObjectList<Item> items => InventoryToNetObjectList.GetCachedWrapperFor(base.Items);


        /*********
        ** Public methods
        *********/
        public static Chest Constructor(bool playerChest, Vector2 tileLocation, int parentSheetIndex = 130)
        {
            return new Chest(playerChest, tileLocation, parentSheetIndex.ToString());
        }

        public static Chest Constructor(bool playerChest, int parentSheedIndex = 130)
        {
            return new Chest(playerChest, parentSheedIndex.ToString());
        }

        public static Chest Constructor(Vector2 location)
        {
            return new Chest { TileLocation = location };
        }

        public ChestFacade(int parent_sheet_index, Vector2 tile_location, int starting_lid_frame, int lid_frame_count)
            : base(parent_sheet_index.ToString(), tile_location, starting_lid_frame, lid_frame_count) { }

        public ChestFacade(int coins, List<Item> items, Vector2 location, bool giftbox = false, int giftboxIndex = 0)
            : base(items, location, giftbox, giftboxIndex) { }

        public void destroyAndDropContents(Vector2 pointToDropAt, GameLocation location)
        {
            this.destroyAndDropContents(pointToDropAt);
        }

        public void dumpContents(GameLocation location)
        {
            this.dumpContents();
        }


        /*********
        ** Private methods
        *********/
        private ChestFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

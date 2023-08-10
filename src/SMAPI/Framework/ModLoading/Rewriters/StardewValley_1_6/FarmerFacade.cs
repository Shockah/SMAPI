using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Netcode;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6.Internal;
using StardewValley;

#pragma warning disable CS0618 // Type or member is obsolete: this is backwards-compatibility code.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="Farmer"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class FarmerFacade : Farmer
    {
        /*********
        ** Accessors
        *********/
        public NetObjectList<Item> items => InventoryToNetObjectList.GetCachedWrapperFor(base.Items);

        public new IList<Item> Items
        {
            get => base.Items;
            set => base.Items.OverwriteWith(value);
        }


        /*********
        ** Public methods
        *********/
        public void addQuest(int questID)
        {
            this.addQuest(questID.ToString());
        }

        public void changePants(Color color)
        {
            this.changePantsColor(color);
        }

        public void changePantStyle(int whichPants, bool is_customization_screen = false)
        {
            base.changePantStyle(whichPants.ToString());
        }

        public void changeShirt(int whichShirt, bool is_customization_screen = false)
        {
            this.changeShirt(whichShirt.ToString());
        }

        public void changeShoeColor(int which)
        {
            this.changeShoeColor(which.ToString());
        }

        public void completeQuest(int questID)
        {
            this.completeQuest(questID.ToString());
        }

        public bool couldInventoryAcceptThisObject(int index, int stack, int quality = 0)
        {
            return this.couldInventoryAcceptThisItem(index.ToString(), stack, quality);
        }

        public int GetEffectsOfRingMultiplier(int ring_index)
        {
            return this.GetEffectsOfRingMultiplier(ring_index.ToString());
        }

        public int getItemCount(int item_index, int min_price = 0)
        {
            // minPrice field was always ignored

            return base.getItemCount(item_index.ToString());
        }

        public bool hasBuff(int whichBuff)
        {
            return this.hasBuff(whichBuff.ToString());
        }

        public bool hasItemInInventory(int itemIndex, int quantity, int minPrice = 0)
        {
            // minPrice field was always ignored

            switch (itemIndex)
            {
                case 858:
                    return this.QiGems >= quantity;

                case 73:
                    return Game1.netWorldState.Value.GoldenWalnuts >= quantity;

                default:
                    return this.getItemCount(ItemRegistry.type_object + itemIndex) >= quantity;
            }
        }

        public bool hasQuest(int id)
        {
            return this.hasQuest(id.ToString());
        }

        public bool isWearingRing(int ringIndex)
        {
            return this.isWearingRing(ringIndex.ToString());
        }

        public bool removeItemsFromInventory(int index, int stack)
        {
            if (this.hasItemInInventory(index, stack))
            {
                switch (index)
                {
                    case 858:
                        this.QiGems -= stack;
                        return true;

                    case 73:
                        Game1.netWorldState.Value.GoldenWalnuts -= stack;
                        return true;

                    default:
                        for (int i = 0; i < base.Items.Count; i++)
                        {
                            if (base.Items[i] is Object obj && obj.parentSheetIndex == index)
                            {
                                if (obj.Stack > stack)
                                {
                                    obj.Stack -= stack;
                                    return true;
                                }

                                stack -= obj.Stack;
                                base.Items[i] = null;
                            }

                            if (stack <= 0)
                                return true;
                        }
                        return false;
                }
            }

            return false;
        }

        public void removeQuest(int questID)
        {
            this.removeQuest(questID.ToString());
        }


        /*********
        ** Private methods
        *********/
        private FarmerFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

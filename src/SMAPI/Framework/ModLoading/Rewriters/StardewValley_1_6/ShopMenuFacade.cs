using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.Menus;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="ShopMenu"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "IdentifierTypo", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class ShopMenuFacade : ShopMenu
    {
        /*********
        ** Public methods
        *********/
        public static ShopMenu Constructor(Dictionary<ISalable, int[]> itemPriceAndStock, int currency = 0, string? who = null, Func<ISalable, Farmer, int, bool>? on_purchase = null, Func<ISalable, bool>? on_sell = null, string? context = null)
        {
            return new ShopMenu(ShopMenuFacade.GetShopId(context), ShopMenuFacade.ToItemStockInformation(itemPriceAndStock), currency, who, on_purchase, on_sell, playOpenSound: true);
        }

        public static ShopMenu Constructor(List<ISalable> itemsForSale, int currency = 0, string? who = null, Func<ISalable, Farmer, int, bool>? on_purchase = null, Func<ISalable, bool>? on_sell = null, string? context = null)
        {
            return new ShopMenu(ShopMenuFacade.GetShopId(context), itemsForSale, currency, who, on_purchase, on_sell, playOpenSound: true);
        }


        /*********
        ** Private methods
        *********/
        private ShopMenuFacade()
            : base(null, null, null)
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }

        private static string GetShopId(string? context)
        {
            return string.IsNullOrWhiteSpace(context)
                ? "legacy_mod_code_" + Guid.NewGuid().ToString("N")
                : context;
        }

        private static Dictionary<ISalable, ItemStockInformation> ToItemStockInformation(Dictionary<ISalable, int[]>? itemPriceAndStock)
        {
            Dictionary<ISalable, ItemStockInformation> stock = new();

            if (itemPriceAndStock != null)
            {
                foreach (var pair in itemPriceAndStock)
                    stock[pair.Key] = new ItemStockInformation(pair.Value[0], pair.Value[1]);
            }

            return stock;
        }
    }
}

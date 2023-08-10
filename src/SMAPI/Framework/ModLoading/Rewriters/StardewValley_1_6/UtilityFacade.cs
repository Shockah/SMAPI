using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.Extensions;

#pragma warning disable CS0618 // Type or member is obsolete: this is backwards-compatibility code.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="Utility"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class UtilityFacade
    {
        /*********
        ** Public methods
        *********/
        public static DisposableList<NPC> getAllCharacters()
        {
            return new DisposableList<NPC>(Utility.getAllCharacters());
        }

        public static List<NPC> getAllCharacters(List<NPC> list)
        {
            list.AddRange(Utility.getAllCharacters());
            return list;
        }

        public static T GetRandom<T>(List<T> list, Random? random = null)
        {
            return (random ?? Game1.random).ChooseFrom(list);
        }

        public static bool HasAnyPlayerSeenEvent(int event_number)
        {
            return Utility.HasAnyPlayerSeenEvent(event_number.ToString());
        }

        public static bool HaveAllPlayersSeenEvent(int event_number)
        {
            return Utility.HaveAllPlayersSeenEvent(event_number.ToString());
        }

        public static bool isFestivalDay(int day, string season)
        {
            return
                Utility.TryParseEnum(season, out Season parsedSeason)
                && Utility.isFestivalDay(day, parsedSeason);
        }

        public static bool IsNormalObjectAtParentSheetIndex(Item item, int index)
        {
            return Utility.IsNormalObjectAtParentSheetIndex(item, index.ToString());
        }

        public static int numSilos()
        {
            return Game1.GetNumberBuildingsConstructed("Silo");
        }


        /*********
        ** Private methods
        *********/
        private UtilityFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

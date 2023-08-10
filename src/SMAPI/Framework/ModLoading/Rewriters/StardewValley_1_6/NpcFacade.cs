using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.BellsAndWhistles;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="NPC"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public abstract class NpcFacade : NPC
    {
        /*********
        ** Public methods
        *********/
        public bool isBirthday(string season, int day)
        {
            // call new method if possible
            if (season == Game1.currentSeason && day == Game1.dayOfMonth)
                return this.isBirthday();

            // else replicate old behavior
            return
                this.Birthday_Season != null
                && this.Birthday_Season == season
                && this.Birthday_Day == day;
        }

        public void showTextAboveHead(string Text, int spriteTextColor = -1, int style = NPC.textStyle_none, int duration = 3000, int preTimer = 0)
        {
            Color? color = spriteTextColor != -1 ? SpriteText.getColorFromIndex(spriteTextColor) : null;
            this.showTextAboveHead(Text, color, style, duration, preTimer);
        }


        /*********
        ** Private methods
        *********/
        private NpcFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="HUDMessage"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "IdentifierTypo", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    [SuppressMessage("ReSharper", "UnusedParameter.Local", Justification = SuppressReasons.MatchesOriginal)]
    public class HudMessageFacade : HUDMessage
    {
        /*********
        ** Public methods
        *********/
        public static HUDMessage Constructor(string message, bool achievement)
        {
            return HUDMessage.ForAchievement(message);
        }

        public static HUDMessage Constructor(string type, int number, bool add, Color color, Item? messageSubject = null)
        {
            if (!add)
                number = -number;

            if (type == "Hay" && messageSubject is null)
                return HUDMessage.ForItemGained(ItemRegistry.Create("(O)178"), number);

            return new HUDMessage(null)
            {
                type = type,
                timeLeft = HUDMessage.defaultTime,
                number = number,
                messageSubject = messageSubject
            };
        }

        public static HUDMessage Constructor(string message, Color color, float timeLeft)
        {
            return Constructor(message, color, timeLeft, false);
        }

        public static HUDMessage Constructor(string message, string leaveMeNull)
        {
            return HUDMessage.ForCornerTextbox(message);
        }

        public static HUDMessage Constructor(string message, Color color, float timeLeft, bool fadeIn)
        {
            return new HUDMessage(message, timeLeft, fadeIn);
        }


        /*********
        ** Private methods
        *********/
        private HudMessageFacade()
            : base(null)
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

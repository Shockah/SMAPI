using System.Diagnostics.CodeAnalysis;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="Event"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "IdentifierTypo", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class EventFacade : Event
    {
        /*********
        ** Public methods
        *********/
        public static Event Constructor(string eventString, int eventID = -1, Farmer? farmerActor = null)
        {
            return new Event(eventString, null, eventID != -1 ? eventID.ToString() : null, farmerActor);
        }


        /*********
        ** Private methods
        *********/
        private EventFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

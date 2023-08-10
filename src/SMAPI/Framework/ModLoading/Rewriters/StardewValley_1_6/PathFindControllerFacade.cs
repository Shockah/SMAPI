using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.Pathfinding;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="PathFindController"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "IdentifierTypo", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    [SuppressMessage("ReSharper", "UnusedParameter.Local", Justification = SuppressReasons.MatchesOriginal)]
    public class PathFindControllerFacade : PathFindController
    {
        /*********
        ** Public methods
        *********/
        public static PathFindController Constructor(Character c, GameLocation location, Point endPoint, int finalFacingDirection, bool eraseOldPathController, bool clearMarriageDialogues = true)
        {
            return new PathFindController(c, location, endPoint, finalFacingDirection, clearMarriageDialogues);
        }

        public static PathFindController Constructor(Character c, GameLocation location, isAtEnd endFunction, int finalFacingDirection, bool eraseOldPathController, endBehavior endBehaviorFunction, int limit, Point endPoint, bool clearMarriageDialogues = true)
        {
            return new PathFindController(c, location, endFunction, finalFacingDirection, endBehaviorFunction, limit, endPoint, clearMarriageDialogues);
        }


        /*********
        ** Private methods
        *********/
        private PathFindControllerFacade()
            : base(null, null, Point.Zero, 0)
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley.Extensions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <c>ViewportExtensions</c> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "IdentifierTypo", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class ViewportExtensionsFacade
    {
        /*********
        ** Public methods
        *********/
        public static Rectangle GetTitleSafeArea(Viewport vp)
        {
            return vp.GetTitleSafeArea();
        }

        public static Rectangle ToXna(xTile.Dimensions.Rectangle xrect)
        {
            return new Rectangle(xrect.X, xrect.Y, xrect.Width, xrect.Height);
        }

        public static Vector2 Size(Viewport vp)
        {
            return new Vector2(vp.Width, vp.Height);
        }


        /*********
        ** Private methods
        *********/
        private ViewportExtensionsFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

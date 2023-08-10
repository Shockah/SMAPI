using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley;
using StardewValley.Menus;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="DialogueBox"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public class DialogueBoxFacade : DialogueBox
    {
        /*********
        ** Public methods
        *********/
        public static DialogueBox Constructor(string dialogue, List<Response> responses, int width = 1200)
        {
            return new DialogueBox(dialogue, responses.ToArray(), width);
        }


        /*********
        ** Private methods
        *********/
        public DialogueBoxFacade()
            : base(null as string)
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

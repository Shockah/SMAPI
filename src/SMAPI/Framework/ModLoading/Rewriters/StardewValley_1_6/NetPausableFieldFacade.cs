using System.Diagnostics.CodeAnalysis;
using Netcode;
using StardewModdingAPI.Framework.ModLoading.Framework;
using StardewValley.Network;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member: This is internal code to support rewriters and shouldn't be called directly.

namespace StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6
{
    /// <summary>Maps Stardew Valley 1.5.6's <see cref="NetPausableField{T,TField,TBaseField}"/> methods to their newer form to avoid breaking older mods.</summary>
    /// <remarks>This is public to support SMAPI rewriting and should never be referenced directly by mods. See remarks on <see cref="ReplaceReferencesRewriter"/> for more info.</remarks>
    [SuppressMessage("ReSharper", "IdentifierTypo", Justification = SuppressReasons.MatchesOriginal)]
    [SuppressMessage("ReSharper", "UnusedMember.Global", Justification = SuppressReasons.UsedViaRewriting)]
    public abstract class NetPausableFieldFacade<T, TField, TBaseField> : NetPausableField<T, TField, TBaseField>
        where TBaseField : NetFieldBase<T, TBaseField>, new()
        where TField : TBaseField, new()
    {
        /*********
        ** Public methods
        *********/
        public static T op_Implicit(NetPausableField<T, TField, TBaseField> field)
        {
            return field.Value;
        }


        /*********
        ** Private methods
        *********/
        private NetPausableFieldFacade()
        {
            RewriteHelper.ThrowFakeConstructorCalled();
        }
    }
}

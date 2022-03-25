using System.Collections.Generic;

namespace StardewModdingAPI.Toolkit.Serialization.Models
{
    /// <summary>A mod dependency listed in a mod manifest.</summary>
    public class ManifestDependency : IManifestDependency
    {
        /*********
        ** Accessors
        *********/
        /// <inheritdoc/>
        public string UniqueID { get; set; }

        /// <inheritdoc/>
        public ISemanticVersion MinimumVersion { get; set; }

        /// <inheritdoc/>
        public bool IsRequired { get; set; }

        /// <inheritdoc/>
        public IList<string> ProvidedAssemblies { get; set; }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="uniqueID">The unique mod ID to require.</param>
        /// <param name="minimumVersion">The minimum required version (if any).</param>
        /// <param name="required">Whether the dependency must be installed to use the mod.</param>
        /// <param name="providedAssemblies">The names of the assemblies provided by the dependency.</param>
        public ManifestDependency(string uniqueID, string minimumVersion, bool required = true, IList<string> providedAssemblies = null)
        {
            this.UniqueID = uniqueID;
            this.MinimumVersion = !string.IsNullOrWhiteSpace(minimumVersion)
                ? new SemanticVersion(minimumVersion)
                : null;
            this.IsRequired = required;
            this.ProvidedAssemblies = providedAssemblies is null
                ? new List<string>()
                : new List<string>(providedAssemblies);
        }
    }
}

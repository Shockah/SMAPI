using StardewModdingAPI.Events;
using StardewModdingAPI.Framework;
using StardewModdingAPI.Internal.Patching;
using StardewModdingAPI.Mods.ErrorHandler.Patches;
using StardewValley;

namespace StardewModdingAPI.Mods.ErrorHandler
{
    /// <summary>The main entry point for the mod.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Private methods
        *********/
        /// <summary>Whether custom content was removed from the save data to avoid a crash.</summary>
        private bool IsSaveContentRemoved;


        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            // get SMAPI core types
            IMonitor monitorForGame = SCore.Instance.GetMonitorForGame();

            // apply patches
            HarmonyPatcher.Apply(this.ModManifest.UniqueID, this.Monitor,
                // game patches
                new GameLocationPatcher(monitorForGame),
                new NpcPatcher(monitorForGame),
                new SaveGamePatcher(this.Monitor, this.OnSaveContentRemoved),
                new SpriteBatchPatcher()
            );

            // hook events
            this.Helper.Events.GameLoop.SaveLoaded += this.OnSaveLoaded;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after custom content is removed from the save data to avoid a crash.</summary>
        internal void OnSaveContentRemoved()
        {
            this.IsSaveContentRemoved = true;
        }

        /// <summary>The method invoked when a save is loaded.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void OnSaveLoaded(object? sender, SaveLoadedEventArgs e)
        {
            // show in-game warning for removed save content
            if (this.IsSaveContentRemoved)
            {
                this.IsSaveContentRemoved = false;
                Game1.addHUDMessage(new HUDMessage(this.Helper.Translation.Get("warn.invalid-content-removed"), HUDMessage.error_type));
            }
        }
    }
}

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Netcode;
using StardewModdingAPI.Events;
using StardewModdingAPI.Framework.ModLoading;
using StardewModdingAPI.Framework.ModLoading.Finders;
using StardewModdingAPI.Framework.ModLoading.Rewriters;
using StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_5;
using StardewModdingAPI.Framework.ModLoading.Rewriters.StardewValley_1_6;
using StardewValley;
using StardewValley.Audio;
using StardewValley.BellsAndWhistles;
using StardewValley.Buildings;
using StardewValley.Enchantments;
using StardewValley.Locations;
using StardewValley.Menus;
using StardewValley.Mods;
using StardewValley.Objects;
using StardewValley.Pathfinding;
using StardewValley.SpecialOrders;
using StardewValley.SpecialOrders.Objectives;
using StardewValley.SpecialOrders.Rewards;
using StardewValley.TerrainFeatures;
using StardewValley.Tools;
using SObject = StardewValley.Object;

namespace StardewModdingAPI.Metadata
{
    /// <summary>Provides CIL instruction handlers which rewrite mods for compatibility, and detect low-level mod issues like incompatible code.</summary>
    internal class InstructionMetadata
    {
        /*********
        ** Fields
        *********/
        /// <summary>The assembly names to which to heuristically detect broken references.</summary>
        /// <remarks>The current implementation only works correctly with assemblies that should always be present.</remarks>
        private readonly ISet<string> ValidateReferencesToAssemblies = new HashSet<string> { "StardewModdingAPI", "Stardew Valley", "StardewValley", "Netcode" };


        /*********
        ** Public methods
        *********/
        /// <summary>Get rewriters which detect or fix incompatible CIL instructions in mod assemblies.</summary>
        /// <param name="paranoidMode">Whether to detect paranoid mode issues.</param>
        /// <param name="rewriteMods">Whether to get handlers which rewrite mods for compatibility.</param>
        public IEnumerable<IInstructionHandler> GetHandlers(bool paranoidMode, bool rewriteMods)
        {
            /****
            ** rewrite CIL to fix incompatible code
            ****/
            // rewrite for crossplatform compatibility
            if (rewriteMods)
            {
                // heuristic rewrites
                yield return new HeuristicFieldRewriter(this.ValidateReferencesToAssemblies);
                yield return new HeuristicMethodRewriter(this.ValidateReferencesToAssemblies);

                // specific versions
                yield return new ReplaceReferencesRewriter()
                    /****
                    ** Stardew Valley 1.5
                    ****/
                    // fields moved
                    .MapField("Netcode.NetCollection`1<StardewValley.Objects.Furniture> StardewValley.Locations.DecoratableLocation::furniture", typeof(GameLocation), nameof(GameLocation.furniture))
                    .MapField("Netcode.NetCollection`1<StardewValley.TerrainFeatures.ResourceClump> StardewValley.Farm::resourceClumps", typeof(GameLocation), nameof(GameLocation.resourceClumps))
                    .MapField("Netcode.NetCollection`1<StardewValley.TerrainFeatures.ResourceClump> StardewValley.Locations.MineShaft::resourceClumps", typeof(GameLocation), nameof(GameLocation.resourceClumps))

                    /****
                    ** Stardew Valley 1.5.5
                    ****/
                    // XNA => MonoGame method changes
                    .MapFacade<SpriteBatch, SpriteBatchFacade>()

                    /****
                    ** Stardew Valley 1.6
                    ****/
                    // moved types
                    .MapType("StardewValley.AmethystEnchantment", typeof(AmethystEnchantment))
                    .MapType("StardewValley.AquamarineEnchantment", typeof(AquamarineEnchantment))
                    .MapType("StardewValley.ArchaeologistEnchantment", typeof(ArchaeologistEnchantment))
                    .MapType("StardewValley.ArtfulEnchantment", typeof(ArtfulEnchantment))
                    .MapType("StardewValley.AutoHookEnchantment", typeof(AutoHookEnchantment))
                    .MapType("StardewValley.AxeEnchantment", typeof(AxeEnchantment))
                    .MapType("StardewValley.BaseEnchantment", typeof(BaseEnchantment))
                    .MapType("StardewValley.BaseWeaponEnchantment", typeof(BaseWeaponEnchantment))
                    .MapType("StardewValley.BottomlessEnchantment", typeof(BottomlessEnchantment))
                    .MapType("StardewValley.BugKillerEnchantment", typeof(BugKillerEnchantment))
                    .MapType("StardewValley.CrusaderEnchantment", typeof(CrusaderEnchantment))
                    .MapType("StardewValley.DiamondEnchantment", typeof(DiamondEnchantment))
                    .MapType("StardewValley.EfficientToolEnchantment", typeof(EfficientToolEnchantment))
                    .MapType("StardewValley.EmeraldEnchantment", typeof(EmeraldEnchantment))
                    .MapType("StardewValley.FishingRodEnchantment", typeof(FishingRodEnchantment))
                    .MapType("StardewValley.GalaxySoulEnchantment", typeof(GalaxySoulEnchantment))
                    .MapType("StardewValley.GenerousEnchantment", typeof(GenerousEnchantment))
                    .MapType("StardewValley.HaymakerEnchantment", typeof(HaymakerEnchantment))
                    .MapType("StardewValley.HoeEnchantment", typeof(HoeEnchantment))
                    .MapType("StardewValley.JadeEnchantment", typeof(JadeEnchantment))
                    .MapType("StardewValley.MagicEnchantment", typeof(MagicEnchantment))
                    .MapType("StardewValley.MasterEnchantment", typeof(MasterEnchantment))
                    .MapType("StardewValley.MilkPailEnchantment", typeof(MilkPailEnchantment))
                    .MapType("StardewValley.PanEnchantment", typeof(PanEnchantment))
                    .MapType("StardewValley.PickaxeEnchantment", typeof(PickaxeEnchantment))
                    .MapType("StardewValley.PowerfulEnchantment", typeof(PowerfulEnchantment))
                    .MapType("StardewValley.PreservingEnchantment", typeof(PreservingEnchantment))
                    .MapType("StardewValley.ReachingToolEnchantment", typeof(ReachingToolEnchantment))
                    .MapType("StardewValley.RubyEnchantment", typeof(RubyEnchantment))
                    .MapType("StardewValley.ShavingEnchantment", typeof(ShavingEnchantment))
                    .MapType("StardewValley.ShearsEnchantment", typeof(ShearsEnchantment))
                    .MapType("StardewValley.SwiftToolEnchantment", typeof(SwiftToolEnchantment))
                    .MapType("StardewValley.TopazEnchantment", typeof(TopazEnchantment))
                    .MapType("StardewValley.VampiricEnchantment", typeof(VampiricEnchantment))
                    .MapType("StardewValley.WateringCanEnchantment", typeof(WateringCanEnchantment))

                    .MapType("StardewValley.SpecialOrder", typeof(SpecialOrder))
                    .MapType("StardewValley.SpecialOrder/QuestState", typeof(SpecialOrderStatus))

                    .MapType("StardewValley.CollectObjective", typeof(CollectObjective))
                    .MapType("StardewValley.DeliverObjective", typeof(DeliverObjective))
                    .MapType("StardewValley.DonateObjective", typeof(DonateObjective))
                    .MapType("StardewValley.FishObjective", typeof(FishObjective))
                    .MapType("StardewValley.GiftObjective", typeof(GiftObjective))
                    .MapType("StardewValley.JKScoreObjective", typeof(JKScoreObjective))
                    .MapType("StardewValley.OrderObjective", typeof(OrderObjective))
                    .MapType("StardewValley.ReachMineFloorObjective", typeof(ReachMineFloorObjective))
                    .MapType("StardewValley.ShipObjective", typeof(ShipObjective))
                    .MapType("StardewValley.SlayObjective", typeof(SlayObjective))

                    .MapType("StardewValley.FriendshipReward", typeof(FriendshipReward))
                    .MapType("StardewValley.GemsReward", typeof(GemsReward))
                    .MapType("StardewValley.MailReward", typeof(MailReward))
                    .MapType("StardewValley.MoneyReward", typeof(MoneyReward))
                    .MapType("StardewValley.OrderReward", typeof(OrderReward))
                    .MapType("StardewValley.ResetEventReward", typeof(ResetEventReward))

                    .MapType("StardewValley.IOAudioEngine", typeof(IAudioEngine))
                    .MapType("StardewValley.ModDataDictionary", typeof(ModDataDictionary))
                    .MapType("StardewValley.ModHooks", typeof(ModHooks))
                    .MapType("StardewValley.Network.NetAudio/SoundContext", typeof(SoundContext))
                    .MapType("StardewValley.PathFindController", typeof(PathFindController))

                    // general API changes
                    // note: types are mapped before members, regardless of the order listed here
                    .MapType("StardewValley.Buildings.Mill", typeof(Building))
                    .MapFacade<BedFurniture, BedFurnitureFacade>()
                    .MapFacade<Boots, BootsFacade>()
                    .MapFacade<BreakableContainerFacade, BreakableContainer>()
                    .MapFacade<Buff, BuffFacade>()
                    .MapFacade<Bush, BushFacade>()
                    .MapFacade<Butterfly, ButterflyFacade>()
                    .MapFacade<Building, BuildingFacade>()
                    .MapFacade<CarpenterMenu, CarpenterMenuFacade>()
                    .MapFacade<Cask, CaskFacade>()
                    .MapFacade<Character, CharacterFacade>()
                    .MapFacade<Chest, ChestFacade>()
                    .MapFacade<Clothing, ClothingFacade>()
                    .MapFacade<ColoredObject, ColoredObjectFacade>()
                    .MapFacade<Crop, CropFacade>()
                    .MapFacade<DelayedAction, DelayedActionFacade>()
                    .MapFacade<Dialogue, DialogueFacade>()
                    .MapFacade<DialogueBox, DialogueBoxFacade>()
                    .MapFacade<Event, EventFacade>()
                    .MapFacade<FarmAnimal, FarmAnimalFacade>()
                    .MapFacade<Farmer, FarmerFacade>()
                    .MapFacade<FarmerTeam, FarmerTeamFacade>()
                    .MapFacade<Fence, FenceFacade>()
                    .MapFacade<Forest, ForestFacade>()
                    .MapFacade<Furniture, FurnitureFacade>()
                    .MapFacade<FruitTree, FruitTreeFacade>()
                    .MapFacade<Game1, Game1Facade>()
                    .MapFacade<GameLocation, GameLocationFacade>()
                    .MapFacade<Hat, HatFacade>()
                    .MapFacade<HoeDirt, HoeDirtFacade>()
                    .MapFacade<HUDMessage, HudMessageFacade>()
                    .MapFacade<IClickableMenu, IClickableMenuFacade>()
                    .MapFacade<Item, ItemFacade>()
                    .MapFacade<JunimoHut, JunimoHutFacade>()
                    .MapFacade<LocalizedContentManager, LocalizedContentManager>()
                    .MapFacade<MeleeWeapon, MeleeWeaponFacade>()
                    .MapFacade<NPC, NpcFacade>()
                    .MapFacade<PathFindController, PathFindControllerFacade>()
                    .MapFacade<ResourceClump, ResourceClumpFacade>()
                    .MapFacade<Ring, RingFacade>()
                    .MapFacade<ShopMenu, ShopMenuFacade>()
                    .MapFacade<Slingshot, SlingshotFacade>()
                    .MapFacade<SObject, ObjectFacade>()
                    .MapFacade<SpriteText, SpriteTextFacade>()
                    .MapFacade<StorageFurniture, StorageFurnitureFacade>()
                    .MapFacade<TerrainFeature, TerrainFeatureFacade>()
                    .MapFacade<Tree, TreeFacade>()
                    .MapFacade<Utility, UtilityFacade>()
                    .MapFacade("Microsoft.Xna.Framework.Graphics.ViewportExtensions", typeof(ViewportExtensionsFacade))
                    .MapFacade<WorldDate, WorldDateFacade>()
                    .MapMethod("System.Void StardewValley.BellsAndWhistles.SpriteText::drawString(Microsoft.Xna.Framework.Graphics.SpriteBatch,System.String,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Single,System.Single,System.Boolean,System.Int32,System.String,System.Int32,StardewValley.BellsAndWhistles.SpriteText/ScrollTextAlignment)", typeof(SpriteTextFacade), nameof(SpriteTextFacade.drawString)) // may not get rewritten by the MapFacade above due to the ScrollTextAlignment enum also being de-nested in 1.6 too

                    // BuildableGameLocation merged into GameLocation
                    .MapFacade("StardewValley.Locations.BuildableGameLocation", typeof(BuildableGameLocationFacade))
                    .MapField("Netcode.NetCollection`1<StardewValley.Buildings.Building> StardewValley.Locations.BuildableGameLocation::buildings", typeof(GameLocation), nameof(GameLocation.buildings))

                    // OverlaidDictionary enumerators changed
                    // note: types are mapped before members, regardless of the order listed here
                    .MapType("StardewValley.Network.OverlaidDictionary/KeysCollection", typeof(OverlaidDictionaryFacade.KeysCollection))
                    .MapType("StardewValley.Network.OverlaidDictionary/KeysCollection/Enumerator", typeof(OverlaidDictionaryFacade.KeysCollection.Enumerator))
                    .MapType("StardewValley.Network.OverlaidDictionary/PairsCollection", typeof(OverlaidDictionaryFacade.PairsCollection))
                    .MapType("StardewValley.Network.OverlaidDictionary/PairsCollection/Enumerator", typeof(OverlaidDictionaryFacade.PairsCollection.Enumerator))
                    .MapType("StardewValley.Network.OverlaidDictionary/ValuesCollection", typeof(OverlaidDictionaryFacade.ValuesCollection))
                    .MapType("StardewValley.Network.OverlaidDictionary/ValuesCollection/Enumerator", typeof(OverlaidDictionaryFacade.ValuesCollection.Enumerator))
                    .MapMethod($"{typeof(OverlaidDictionaryFacade).FullName}/{nameof(OverlaidDictionaryFacade.KeysCollection)} StardewValley.Network.OverlaidDictionary::get_Keys()", typeof(OverlaidDictionaryFacade), $"get_{nameof(OverlaidDictionaryFacade.Keys)}")
                    .MapMethod($"{typeof(OverlaidDictionaryFacade).FullName}/{nameof(OverlaidDictionaryFacade.PairsCollection)} StardewValley.Network.OverlaidDictionary::get_Pairs()", typeof(OverlaidDictionaryFacade), $"get_{nameof(OverlaidDictionaryFacade.Pairs)}")
                    .MapMethod($"{typeof(OverlaidDictionaryFacade).FullName}/{nameof(OverlaidDictionaryFacade.ValuesCollection)} StardewValley.Network.OverlaidDictionary::get_Values()", typeof(OverlaidDictionaryFacade), $"get_{nameof(OverlaidDictionaryFacade.Values)}")

                    // implicit NetField conversions removed
                    .MapMethod("!0 Netcode.NetFieldBase`2<Microsoft.Xna.Framework.Color,Netcode.NetColor>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<Color, NetColor>), nameof(NetFieldBaseFacade<Color, NetColor>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<Microsoft.Xna.Framework.Rectangle,Netcode.NetRectangle>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<Rectangle, NetRectangle>), nameof(NetFieldBaseFacade<Rectangle, NetRectangle>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<Microsoft.Xna.Framework.Vector2,Netcode.NetVector2>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<Vector2, NetVector2>), nameof(NetFieldBaseFacade<Vector2, NetVector2>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<StardewValley.Farmer,Netcode.NetRef`1<StardewValley.Farmer>>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<Farmer, NetRef<Farmer>>), nameof(NetFieldBaseFacade<Farmer, NetRef<Farmer>>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<StardewValley.GameLocation,Netcode.NetRef`1<StardewValley.GameLocation>>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<GameLocation, NetRef<GameLocation>>), nameof(NetFieldBaseFacade<GameLocation, NetRef<GameLocation>>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<StardewValley.Object,Netcode.NetRef`1<StardewValley.Object>>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<SObject, NetRef<SObject>>), nameof(NetFieldBaseFacade<SObject, NetRef<SObject>>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<StardewValley.Objects.Chest,Netcode.NetRef`1<StardewValley.Objects.Chest>>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<Chest, NetRef<Chest>>), nameof(NetFieldBaseFacade<Chest, NetRef<Chest>>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<StardewValley.Objects.Hat,Netcode.NetRef`1<StardewValley.Objects.Hat>>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<Hat, NetRef<Hat>>), nameof(NetFieldBaseFacade<Hat, NetRef<Hat>>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<StardewValley.TerrainFeatures.HoeDirt,Netcode.NetRef`1<StardewValley.TerrainFeatures.HoeDirt>>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<HoeDirt, NetRef<HoeDirt>>), nameof(NetFieldBaseFacade<HoeDirt, NetRef<HoeDirt>>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<System.Byte,Netcode.NetByte>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<byte, NetByte>), nameof(NetFieldBaseFacade<byte, NetByte>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<System.Boolean,Netcode.NetBool>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<bool, NetBool>), nameof(NetFieldBaseFacade<bool, NetBool>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<System.Double,Netcode.NetDouble>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<double, NetDouble>), nameof(NetFieldBaseFacade<double, NetDouble>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<System.Int32,Netcode.NetInt>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<int, NetInt>), nameof(NetFieldBaseFacade<int, NetInt>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<System.Int32,Netcode.NetIntDelta>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<int, NetIntDelta>), nameof(NetFieldBaseFacade<int, NetIntDelta>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<System.Single,Netcode.NetFloat>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<float, NetFloat>), nameof(NetFieldBaseFacade<float, NetFloat>.op_Implicit))
                    .MapMethod("!0 Netcode.NetFieldBase`2<System.String,Netcode.NetString>::op_Implicit(Netcode.NetFieldBase`2<!0,!1>)", typeof(NetFieldBaseFacade<string, NetString>), nameof(NetFieldBaseFacade<string, NetString>.op_Implicit))

                    .MapMethod("!0 StardewValley.Network.NetPausableField`3<Microsoft.Xna.Framework.Vector2,Netcode.NetVector2,Netcode.NetVector2>::op_Implicit(StardewValley.Network.NetPausableField`3<!0,!1,!2>)", typeof(NetPausableFieldFacade<Vector2, NetVector2, NetVector2>), nameof(NetPausableFieldFacade<Vector2, NetVector2, NetVector2>.op_Implicit));

                // 32-bit to 64-bit in Stardew Valley 1.5.5
                yield return new ArchitectureAssemblyRewriter();

                // detect Harmony & rewrite for SMAPI 3.12 (Harmony 1.x => 2.0 update)
                yield return new HarmonyRewriter();
            }
            else
                yield return new HarmonyRewriter(shouldRewrite: false);

            /****
            ** detect mod issues
            ****/
            // broken code
            yield return new ReferenceToMissingMemberFinder(this.ValidateReferencesToAssemblies);
            yield return new ReferenceToMemberWithUnexpectedTypeFinder(this.ValidateReferencesToAssemblies);

            // code which may impact game stability
            yield return new FieldFinder(typeof(SaveGame).FullName!, new[] { nameof(SaveGame.serializer), nameof(SaveGame.farmerSerializer), nameof(SaveGame.locationSerializer) }, InstructionHandleResult.DetectedSaveSerializer);
            yield return new EventFinder(typeof(ISpecializedEvents).FullName!, new[] { nameof(ISpecializedEvents.UnvalidatedUpdateTicked), nameof(ISpecializedEvents.UnvalidatedUpdateTicking) }, InstructionHandleResult.DetectedUnvalidatedUpdateTick);

            // direct console access
            yield return new TypeFinder(typeof(System.Console).FullName!, InstructionHandleResult.DetectedConsoleAccess);

            // paranoid issues
            if (paranoidMode)
            {
                // filesystem access
                yield return new TypeFinder(
                    new[]
                    {
                        typeof(System.IO.File).FullName!,
                        typeof(System.IO.FileStream).FullName!,
                        typeof(System.IO.FileInfo).FullName!,
                        typeof(System.IO.Directory).FullName!,
                        typeof(System.IO.DirectoryInfo).FullName!,
                        typeof(System.IO.DriveInfo).FullName!,
                        typeof(System.IO.FileSystemWatcher).FullName!
                    },
                    InstructionHandleResult.DetectedFilesystemAccess
                );

                // shell access
                yield return new TypeFinder(typeof(System.Diagnostics.Process).FullName!, InstructionHandleResult.DetectedShellAccess);
            }
        }
    }
}

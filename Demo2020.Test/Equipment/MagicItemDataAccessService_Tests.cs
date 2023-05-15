using Demo2020.Biz.Equipment.Models;
using Demo2020.Biz.Equipment.Services;
using System.Collections.Generic;
using Xunit;

namespace Demo2020.Test.Equipment
{
    public class MagicItemDataAccessService_Tests
    {
        [Fact]
        public async void GetAllMagicItems_Test()
        {
            MagicItemDataAccessService magicItemApi = new MagicItemDataAccessService();
            List<MagicItemModel> magicItems = await magicItemApi.GetAllMagicItems();

            Assert.NotNull(magicItems);
            Assert.Equal(362, magicItems.Count);

            foreach (MagicItemModel magicItem in magicItems)
            {
                Assert.NotNull(magicItem);
                Assert.NotNull(magicItem.Name);
                Assert.NotEqual(magicItem.Name, string.Empty);
            }
        }

        [Fact]
        public async void GetMagicItem_Test()
        {
            MagicItemDataAccessService magicItemApi = new MagicItemDataAccessService();
            List<MagicItemModel> magicItems = await magicItemApi.GetAllMagicItems();

            Assert.NotNull(magicItems);
            Assert.Equal(362, magicItems.Count);

            MagicItemModel container = null;
            foreach (MagicItemModel magicItem in magicItems)
            {
                container = await magicItemApi.GetMagicItem(magicItem.Name);

                Assert.NotNull(container);
            }
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void GetMagicItemIndividual_Test(string name)
        {
            MagicItemDataAccessService magicItemApi = new MagicItemDataAccessService();
            MagicItemModel magicItem = await magicItemApi.GetMagicItem(name);

            Assert.NotNull(magicItem);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "Adamantine Armor" },
            new object[] { "Ammunition, +1, +2, or +3" },
            new object[] { "Amulet of Health" },
            new object[] { "Amulet of Proof against Detection and Location" },
            new object[] { "Amulet of the Planes" },
            new object[] { "Animated Shield" },
            new object[] { "Apparatus of the Crab" },
            new object[] { "Armor, +1, +2, or +3" },
            new object[] { "Armor of Invulnerability" },
            new object[] { "Armor of Resistance" },
            new object[] { "Armor of Vulnerability" },
            new object[] { "Arrow-Catching Shield" },
            new object[] { "Arrow of Slaying" },
            new object[] { "Bag of Beans" },
            new object[] { "Bag of Devouring" },
            new object[] { "Bag of Holding" },
            new object[] { "Bag of Tricks" },
            new object[] { "Bead of Force" },
            new object[] { "Belt of Dwarvenkind" },
            new object[] { "Belt of Giant Strength" },
            new object[] { "Berserker Axe" },
            new object[] { "Boots of Elvenkind" },
            new object[] { "Boots of Levitation" },
            new object[] { "Boots of Speed" },
            new object[] { "Boots of Striding and Springing" },
            new object[] { "Boots of the Winterlands" },
            new object[] { "Bowl of Commanding Water Elementals" },
            new object[] { "Bracers of Archery" },
            new object[] { "Bracers of Defense" },
            new object[] { "Brazier of Commanding Fire Elementals" },
            new object[] { "Brooch of Shielding" },
            new object[] { "Broom of Flying" },
            new object[] { "Candle of Invocation" },
            new object[] { "Cape of the Mountebank" },
            new object[] { "Carpet of Flying" },
            new object[] { "Censer of Controlling Air Elementals" },
            new object[] { "Chime of Opening" },
            new object[] { "Circlet of Blasting" },
            new object[] { "Cloak of Arachnida" },
            new object[] { "Cloak of Displacement" },
            new object[] { "Cloak of Elvenkind" },
            new object[] { "Cloak of Protection" },
            new object[] { "Cloak of the Bat" },
            new object[] { "Cloak of the Manta Ray" },
            new object[] { "Crystal Ball" },
            new object[] { "Cube of Force" },
            new object[] { "Cubic Gate" },
            new object[] { "Dagger of Venom" },
            new object[] { "Dancing Sword" },
            new object[] { "Decanter of Endless Water" },
            new object[] { "Deck of Illusions" },
            new object[] { "Deck of Many Things" },
            new object[] { "Defender" },
            new object[] { "Demon Armor" },
            new object[] { "Dimensional Shackles" },
            new object[] { "Dragon Scale Mail" },
            new object[] { "Dragon Slayer" },
            new object[] { "Dust of Disappearance" },
            new object[] { "Dust of Dryness" },
            new object[] { "Dust of Sneezing and Choking" },
            new object[] { "Dwarven Plate" },
            new object[] { "Dwarven Thrower" },
            new object[] { "Efficient Quiver" },
            new object[] { "Efreeti Bottle" },
            new object[] { "Elemental Gem" },
            new object[] { "Elven Chain" },
            new object[] { "Eversmoking Bottle" },
            new object[] { "Eyes of Charming" },
            new object[] { "Eyes of Minute Seeing" },
            new object[] { "Eyes of the Eagle" },
            new object[] { "Feather Token" },
            new object[] { "Figurine of Wondrous Power" },
            new object[] { "Flame Tongue" },
            new object[] { "Folding Boat" },
            new object[] { "Frost Brand" },
            new object[] { "Gauntlets of Ogre Power" },
            new object[] { "Gem of Brightness" },
            new object[] { "Gem of Seeing" },
            new object[] { "Giant Slayer" },
            new object[] { "Glamoured Studded Leather Armor" },
            new object[] { "Gloves of Missile Snaring" },
            new object[] { "Gloves of Swimming and Climbing" },
            new object[] { "Goggles of Night" },
            new object[] { "Hammer of Thunderbolts" },
            new object[] { "Handy Haversack" },
            new object[] { "Hat of Disguise" },
            new object[] { "Headband of Intellect" },
            new object[] { "Helm of Brilliance" },
            new object[] { "Helm of Comprehending Languages" },
            new object[] { "Helm of Telepathy" },
            new object[] { "Helm of Teleportation" },
            new object[] { "Holy Avenger" },
            new object[] { "Horn of Blasting" },
            new object[] { "Horn of Valhalla" },
            new object[] { "Horseshoes of a Zephyr" },
            new object[] { "Horseshoes of Speed" },
            new object[] { "Immovable Rod" },
            new object[] { "Instant Fortress" },
            new object[] { "Ioun Stone" },
            new object[] { "Iron Bands of Binding" },
            new object[] { "Iron Flask" },
            new object[] { "Javelin of Lightning" },
            new object[] { "Lantern of Revealing" },
            new object[] { "Luck Blade" },
            new object[] { "Mace of Disruption" },
            new object[] { "Mace of Smiting" },
            new object[] { "Mace of Terror" },
            new object[] { "Mantle of Spell Resistance" },
            new object[] { "Manual of Bodily Health" },
            new object[] { "Manual of Gainful Exercise" },
            new object[] { "Manual of Golems" },
            new object[] { "Manual of Quickness of Action" },
            new object[] { "Marvelous Pigments" },
            new object[] { "Medallion of Thoughts" },
            new object[] { "Mirror of Life Trapping" },
            new object[] { "Mithral Armor" },
            new object[] { "Necklace of Adaptation" },
            new object[] { "Necklace of Fireballs" },
            new object[] { "Necklace of Prayer Beads" },
            new object[] { "Nine Lives Stealer" },
            new object[] { "Oathbow" },
            new object[] { "Oil of Etherealness" },
            new object[] { "Oil of Sharpness" },
            new object[] { "Oil of Slipperiness" },
            new object[] { "Orb of Dragonkind" },
            new object[] { "Pearl of Power" },
            new object[] { "Periapt of Health" },
            new object[] { "Periapt of Proof against Poison" },
            new object[] { "Periapt of Wound Closure" },
            new object[] { "Philter of Love" },
            new object[] { "Pipes of Haunting" },
            new object[] { "Pipes of the Sewers" },
            new object[] { "Plate Armor of Etherealness" },
            new object[] { "Portable Hole" },
            new object[] { "Potion of Animal Friendship" },
            new object[] { "Potion of Clairvoyance" },
            new object[] { "Potion of Climbing" },
            new object[] { "Potion of Diminution" },
            new object[] { "Potion of Flying" },
            new object[] { "Potion of Gaseous Form" },
            new object[] { "Potion of Giant Strength" },
            new object[] { "Potion of Growth" },
            new object[] { "Potion of Healing" },
            new object[] { "Potion of Heroism" },
            new object[] { "Potion of Invisibility" },
            new object[] { "Potion of Mind Reading" },
            new object[] { "Potion of Poison" },
            new object[] { "Potion of Resistance" },
            new object[] { "Potion of Speed" },
            new object[] { "Potion of Water Breathing" },
            new object[] { "Restorative Ointment" },
            new object[] { "Ring of Animal Influence" },
            new object[] { "Ring of Djinni Summoning" },
            new object[] { "Ring of Elemental Command" },
            new object[] { "Ring of Evasion" },
            new object[] { "Ring of Feather Falling" },
            new object[] { "Ring of Free Action" },
            new object[] { "Ring of Invisibility" },
            new object[] { "Ring of Jumping" },
            new object[] { "Ring of Mind Shielding" },
            new object[] { "Ring of Protection" },
            new object[] { "Ring of Regeneration" },
            new object[] { "Ring of Resistance" },
            new object[] { "Ring of Shooting Stars" },
            new object[] { "Ring of Spell Storing" },
            new object[] { "Ring of Spell Turning" },
            new object[] { "Ring of Swimming" },
            new object[] { "Ring of Telekinesis" },
            new object[] { "Ring of the Ram" },
            new object[] { "Ring of Three Wishes" },
            new object[] { "Ring of Warmth" },
            new object[] { "Ring of Water Walking" },
            new object[] { "Ring of X-ray Vision" },
            new object[] { "Robe of Eyes" },
            new object[] { "Robe of Scintillating Colors" },
            new object[] { "Robe of Stars" },
            new object[] { "Robe of the Archmagi" },
            new object[] { "Robe of Useful Items" },
            new object[] { "Rod of Absorption" },
            new object[] { "Rod of Alertness" },
            new object[] { "Rod of Lordly Might" },
            new object[] { "Rod of Rulership" },
            new object[] { "Rod of Security" },
            new object[] { "Rope of Climbing" },
            new object[] { "Rope of Entanglement" },
            new object[] { "Scarab of Protection" },
            new object[] { "Scimitar of Speed" },
            new object[] { "Shield of Missile Attraction" },
            new object[] { "Slippers of Spider Climbing" },
            new object[] { "Sovereign Glue" },
            new object[] { "Spell Scroll" },
            new object[] { "Spellguard Shield" },
            new object[] { "Sphere of Annihilation" },
            new object[] { "Staff of Charming" },
            new object[] { "Staff of Fire" },
            new object[] { "Staff of Frost" },
            new object[] { "Staff of Healing" },
            new object[] { "Staff of Power" },
            new object[] { "Staff of Striking" },
            new object[] { "Staff of Swarming Insects" },
            new object[] { "Staff of the Magi" },
            new object[] { "Staff of the Python" },
            new object[] { "Staff of the Woodlands" },
            new object[] { "Staff of Thunder and Lightning" },
            new object[] { "Staff of Withering" },
            new object[] { "Stone of Controlling Earth Elementals" },
            new object[] { "Stone of Good Luck (Luckstone)" },
            new object[] { "Sun Blade" },
            new object[] { "Sword of Life Stealing" },
            new object[] { "Sword of Sharpness" },
            new object[] { "Sword of Wounding" },
            new object[] { "Talisman of Pure Good" },
            new object[] { "Talisman of the Sphere" },
            new object[] { "Talisman of Ultimate Evil" },
            new object[] { "Tome of Clear Thought" },
            new object[] { "Tome of Leadership and Influence" },
            new object[] { "Tome of Understanding" },
            new object[] { "Trident of Fish Command" },
            new object[] { "Universal Solvent" },
            new object[] { "Vicious Weapon" },
            new object[] { "Vorpal Sword" },
            new object[] { "Wand of Binding" },
            new object[] { "Wand of Enemy Detection" },
            new object[] { "Wand of Fear" },
            new object[] { "Wand of Fireballs" },
            new object[] { "Wand of Lightning Bolts" },
            new object[] { "Wand of Magic Detection" },
            new object[] { "Wand of Magic Missiles" },
            new object[] { "Wand of Paralysis" },
            new object[] { "Wand of Polymorph" },
            new object[] { "Wand of Secrets" },
            new object[] { "Wand of the War Mage, +1, +2, or +3" },
            new object[] { "Wand of Web" },
            new object[] { "Wand of Wonder" },
            new object[] { "Weapon, +1, +2, or +3" },
            new object[] { "Well of Many Worlds" },
            new object[] { "Wind Fan" },
            new object[] { "Winged Boots" },
            new object[] { "Wings of Flying" }
        };
    }
}

using Demo2020.Biz.Equipment.Services;
using Demo2020.Biz.Equipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo2020.Test.Equipment
{
    public class DnD5eEquipmentApi_Tests
    {
        [Fact]
        public async void GetAllEquipment_Test()
        {
            DnD5eEquipmentApi equipmentApi = new DnD5eEquipmentApi();
            List<Biz.Equipment.Models.Equipment> equipments = await equipmentApi.GetAllEquipment();

            Assert.NotNull(equipments);
            Assert.Equal(231, equipments.Count);

            foreach (Biz.Equipment.Models.Equipment equipment in equipments)
            {
                Assert.NotNull(equipment);
                Assert.NotNull(equipment.Name);
                Assert.NotEqual(equipment.Name, string.Empty);
            }
        }

        [Fact]
        public async void GetEquipment_Test()
        {
            DnD5eEquipmentApi equipmentApi = new DnD5eEquipmentApi();
            List<Biz.Equipment.Models.Equipment> equipments = await equipmentApi.GetAllEquipment();

            Assert.NotNull(equipments);
            Assert.Equal(231, equipments.Count);

            Biz.Equipment.Models.Equipment container = null;
            foreach (Biz.Equipment.Models.Equipment equipment in equipments)
            {
                container = await equipmentApi.GetEquipment(equipment.Name);

                Assert.NotNull(container);
            }
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void GetEquipmentIndividual_Test(string name)
        {
            DnD5eEquipmentApi equipmentApi = new DnD5eEquipmentApi();
            Biz.Equipment.Models.Equipment equipment = await equipmentApi.GetEquipment(name);

            Assert.NotNull(equipment);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "Abacus" },
            new object[] { "Abacus" },
            new object[] { "Acid (vial)" },
            new object[] { "Alchemist's fire (flask)" },
            new object[] { "Alchemist's supplies" },
            new object[] { "Amulet" },
            new object[] { "Animal Feed (1 day)" },
            new object[] { "Antitoxin (vial)" },
            new object[] { "Arrow" },
            new object[] { "Backpack" },
            new object[] { "Bagpipes" },
            new object[] { "Ball bearings (bag of 1,000)" },
            new object[] { "Barding: Breastplate" },
            new object[] { "Barding: Chain mail" },
            new object[] { "Barding: Chain shirt" },
            new object[] { "Barding: Half plate" },
            new object[] { "Barding: Hide" },
            new object[] { "Barding: Leather" },
            new object[] { "Barding: Padded" },
            new object[] { "Barding: Plate" },
            new object[] { "Barding: Ring mail" },
            new object[] { "Barding: Scale mail" },
            new object[] { "Barding: Splint" },
            new object[] { "Barding: Studded Leather" },
            new object[] { "Barrel" },
            new object[] { "Basket" },
            new object[] { "Battleaxe" },
            new object[] { "Bedroll" },
            new object[] { "Bell" },
            new object[] { "Bit and bridle" },
            new object[] { "Blanket" },
            new object[] { "Block and tackle" },
            new object[] { "Blowgun" },
            new object[] { "Blowgun needle" },
            new object[] { "Book" },
            new object[] { "Bottle, glass" },
            new object[] { "Breastplate" },
            new object[] { "Brewer's supplies" },
            new object[] { "Bucket" },
            new object[] { "Burglar's Pack" },
            new object[] { "Calligrapher's supplies" },
            new object[] { "Caltrops" },
            new object[] { "Camel" },
            new object[] { "Candle" },
            new object[] { "Carpenter's tools" },
            new object[] { "Carriage" },
            new object[] { "Cart" },
            new object[] { "Cartographer's tools" },
            new object[] { "Case, crossbow bolt" },
            new object[] { "Case, map or scroll" },
            new object[] { "Chain (10 feet)" },
            new object[] { "Chain Mail" },
            new object[] { "Chain Shirt" },
            new object[] { "Chalk (1 piece)" },
            new object[] { "Chariot" },
            new object[] { "Chest" },
            new object[] { "Climber's Kit" },
            new object[] { "Clothes, common" },
            new object[] { "Clothes, costume" },
            new object[] { "Clothes, fine" },
            new object[] { "Clothes, traveler's" },
            new object[] { "Club" },
            new object[] { "Cobbler's tools" },
            new object[] { "Component pouch" },
            new object[] { "Cook's utensils" },
            new object[] { "Crossbow bolt" },
            new object[] { "Crossbow, hand" },
            new object[] { "Crossbow, heavy" },
            new object[] { "Crossbow, light" },
            new object[] { "Crowbar" },
            new object[] { "Crystal" },
            new object[] { "Dagger" },
            new object[] { "Dart" },
            new object[] { "Dice set" },
            new object[] { "Diplomat's Pack" },
            new object[] { "Disguise Kit" },
            new object[] { "Donkey" },
            new object[] { "Drum" },
            new object[] { "Dulcimer" },
            new object[] { "Dungeoneer's Pack" },
            new object[] { "Elephant" },
            new object[] { "Emblem" },
            new object[] { "Entertainer's Pack" },
            new object[] { "Explorer's Pack" },
            new object[] { "Fishing tackle" },
            new object[] { "Flail" },
            new object[] { "Flask or tankard" },
            new object[] { "Flute" },
            new object[] { "Forgery Kit" },
            new object[] { "Galley" },
            new object[] { "Glaive" },
            new object[] { "Glassblower's tools" },
            new object[] { "Grappling hook" },
            new object[] { "Greataxe" },
            new object[] { "Greatclub" },
            new object[] { "Greatsword" },
            new object[] { "Halberd" },
            new object[] { "Half Plate" },
            new object[] { "Hammer" },
            new object[] { "Hammer, sledge" },
            new object[] { "Handaxe" },
            new object[] { "Healer's Kit" },
            new object[] { "Herbalism Kit" },
            new object[] { "Hide" },
            new object[] { "Holy water (flask)" },
            new object[] { "Horn" },
            new object[] { "Horse, draft" },
            new object[] { "Horse, riding" },
            new object[] { "Hourglass" },
            new object[] { "Hunting trap" },
            new object[] { "Ink (1 ounce bottle)" },
            new object[] { "Ink pen" },
            new object[] { "Javelin" },
            new object[] { "Jeweler's tools" },
            new object[] { "Jug or pitcher" },
            new object[] { "Keelboat" },
            new object[] { "Ladder (10-foot)" },
            new object[] { "Lamp" },
            new object[] { "Lance" },
            new object[] { "Lantern, bullseye" },
            new object[] { "Lantern, hooded" },
            new object[] { "Leather" },
            new object[] { "Leatherworker's tools" },
            new object[] { "Light hammer" },
            new object[] { "Lock" },
            new object[] { "Longbow" },
            new object[] { "Longship" },
            new object[] { "Longsword" },
            new object[] { "Lute" },
            new object[] { "Lyre" },
            new object[] { "Mace" },
            new object[] { "Magnifying glass" },
            new object[] { "Manacles" },
            new object[] { "Mason's tools" },
            new object[] { "Mastiff" },
            new object[] { "Maul" },
            new object[] { "Mess Kit" },
            new object[] { "Mirror, steel" },
            new object[] { "Morningstar" },
            new object[] { "Mule" },
            new object[] { "Navigator's tools" },
            new object[] { "Net" },
            new object[] { "Oil (flask)" },
            new object[] { "Orb" },
            new object[] { "Padded" },
            new object[] { "Painter's supplies" },
            new object[] { "Pan flute" },
            new object[] { "Paper (one sheet)" },
            new object[] { "Parchment (one sheet)" },
            new object[] { "Perfume (vial)" },
            new object[] { "Pick, miner's" },
            new object[] { "Pike" },
            new object[] { "Piton" },
            new object[] { "Plate" },
            new object[] { "Playing card set" },
            new object[] { "Poison, basic (vial)" },
            new object[] { "Poisoner's Kit" },
            new object[] { "Pole (10-foot)" },
            new object[] { "Pony" },
            new object[] { "Pot, iron" },
            new object[] { "Potion of healing" },
            new object[] { "Potter's tools" },
            new object[] { "Pouch" },
            new object[] { "Priest's Pack" },
            new object[] { "Quarterstaff" },
            new object[] { "Quiver" },
            new object[] { "Ram, portable" },
            new object[] { "Rapier" },
            new object[] { "Rations (1 day)" },
            new object[] { "Reliquary" },
            new object[] { "Riding" },
            new object[] { "Ring Mail" },
            new object[] { "Robes" },
            new object[] { "Rod" },
            new object[] { "Rope, hempen (50 feet)" },
            new object[] { "Rope, silk (50 feet)" },
            new object[] { "Rowboat" },
            new object[] { "Sack" },
            new object[] { "Saddle, Exotic" },
            new object[] { "Saddle, Military" },
            new object[] { "Saddle, Pack" },
            new object[] { "Saddlebags" },
            new object[] { "Sailing ship" },
            new object[] { "Scale Mail" },
            new object[] { "Scale, merchant's" },
            new object[] { "Scholar's Pack" },
            new object[] { "Scimitar" },
            new object[] { "Sealing wax" },
            new object[] { "Shawm" },
            new object[] { "Shield" },
            new object[] { "Shortbow" },
            new object[] { "Shortsword" },
            new object[] { "Shovel" },
            new object[] { "Sickle" },
            new object[] { "Signal whistle" },
            new object[] { "Signet ring" },
            new object[] { "Sled" },
            new object[] { "Sling" },
            new object[] { "Sling bullet" },
            new object[] { "Smith's tools" },
            new object[] { "Soap" },
            new object[] { "Spear" },
            new object[] { "Spellbook" },
            new object[] { "Spike, iron" },
            new object[] { "Splint" },
            new object[] { "Sprig of mistletoe" },
            new object[] { "Spyglass" },
            new object[] { "Stabling (1 day)" },
            new object[] { "Staff" },
            new object[] { "Studded Leather" },
            new object[] { "Tent, two-person" },
            new object[] { "Thieves' tools" },
            new object[] { "Tinderbox" },
            new object[] { "Tinker's tools" },
            new object[] { "Torch" },
            new object[] { "Totem" },
            new object[] { "Trident" },
            new object[] { "Vial" },
            new object[] { "Viol" },
            new object[] { "Wagon" },
            new object[] { "Wand" },
            new object[] { "War pick" },
            new object[] { "Warhammer" },
            new object[] { "Warhorse" },
            new object[] { "Warship" },
            new object[] { "Waterskin" },
            new object[] { "Weaver's tools" },
            new object[] { "Whetstone" },
            new object[] { "Whip" },
            new object[] { "Woodcarver's tools" },
            new object[] { "Wooden staff" },
            new object[] { "Yew wand" }
        };
    }
}

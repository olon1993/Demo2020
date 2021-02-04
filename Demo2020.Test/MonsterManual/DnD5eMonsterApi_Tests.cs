﻿using Demo2020.Biz.MonsterManual.Models;
using Demo2020.Biz.MonsterManual.Services;
using System.Collections.Generic;
using Xunit;

namespace Demo2020.Test.MonsterManual
{
    public class DnD5eMonsterApi_Tests
    {
        [Fact]
        public async void GetAllMonsters_Test()
        {
            DnD5eMonsterApi monsterApi = new DnD5eMonsterApi();
            List<Monster> monsters = await monsterApi.GetAllMonsters();

            Assert.NotNull(monsters);
            Assert.Equal(332, monsters.Count);

            foreach(Monster monster in monsters)
            {
                Assert.NotNull(monster);
                Assert.NotNull(monster.Name);
                Assert.NotEqual(monster.Name, string.Empty);
            }
        }

        [Fact]
        public async void GetMonster_Test()
        {
            DnD5eMonsterApi monsterApi = new DnD5eMonsterApi();
            List<Monster> monsters = await monsterApi.GetAllMonsters();

            Assert.NotNull(monsters);
            Assert.Equal(332, monsters.Count);

            Monster container = null;
            foreach (Monster monster in monsters)
            {
                container = await monsterApi.GetMonster(monster.Name);

                Assert.NotNull(container);
            }
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async void GetMonsterIndividual_Test(string name)
        {
            DnD5eMonsterApi monsterApi = new DnD5eMonsterApi();
            Monster monster = await monsterApi.GetMonster(name);

            Assert.NotNull(monster);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "Aboleth" },
            new object[] { "Aboleth" },
            new object[] { "Acolyte" },
            new object[] { "Adult Black Dragon" },
            new object[] { "Adult Blue Dragon" },
            new object[] { "Adult Brass Dragon" },
            new object[] { "Adult Bronze Dragon" },
            new object[] { "Adult Copper Dragon" },
            new object[] { "Adult Gold Dragon" },
            new object[] { "Adult Green Dragon" },
            new object[] { "Adult Red Dragon" },
            new object[] { "Adult Silver Dragon" },
            new object[] { "Adult White Dragon" },
            new object[] { "Air Elemental" },
            new object[] { "Ancient Black Dragon" },
            new object[] { "Ancient Blue Dragon" },
            new object[] { "Ancient Brass Dragon" },
            new object[] { "Ancient Bronze Dragon" },
            new object[] { "Ancient Copper Dragon" },
            new object[] { "Ancient Gold Dragon" },
            new object[] { "Ancient Green Dragon" },
            new object[] { "Ancient Red Dragon" },
            new object[] { "Ancient Silver Dragon" },
            new object[] { "Ancient White Dragon" },
            new object[] { "Androsphinx" },
            new object[] { "Animated Armor" },
            new object[] { "Ankheg" },
            new object[] { "Ape" },
            new object[] { "Archmage" },
            new object[] { "Assassin" },
            new object[] { "Awakened Shrub" },
            new object[] { "Awakened Tree" },
            new object[] { "Axe Beak" },
            new object[] { "Azer" },
            new object[] { "Baboon" },
            new object[] { "Badger" },
            new object[] { "Balor" },
            new object[] { "Bandit" },
            new object[] { "Bandit Captain" },
            new object[] { "Barbed Devil" },
            new object[] { "Basilisk" },
            new object[] { "Bat" },
            new object[] { "Bearded Devil" },
            new object[] { "Behir" },
            new object[] { "Berserker" },
            new object[] { "Black Bear" },
            new object[] { "Black Dragon Wyrmling" },
            new object[] { "Black Pudding" },
            new object[] { "Blink Dog" },
            new object[] { "Blood Hawk" },
            new object[] { "Blue Dragon Wyrmling" },
            new object[] { "Boar" },
            new object[] { "Bone Devil" },
            new object[] { "Brass Dragon Wyrmling" },
            new object[] { "Bronze Dragon Wyrmling" },
            new object[] { "Brown Bear" },
            new object[] { "Bugbear" },
            new object[] { "Bulette" },
            new object[] { "Camel" },
            new object[] { "Cat" },
            new object[] { "Centaur" },
            new object[] { "Chain Devil" },
            new object[] { "Chimera" },
            new object[] { "Chuul" },
            new object[] { "Clay Golem" },
            new object[] { "Cloaker" },
            new object[] { "Cloud Giant" },
            new object[] { "Cockatrice" },
            new object[] { "Commoner" },
            new object[] { "Constrictor Snake" },
            new object[] { "Copper Dragon Wyrmling" },
            new object[] { "Couatl" },
            new object[] { "Crab" },
            new object[] { "Crocodile" },
            new object[] { "Cult Fanatic" },
            new object[] { "Cultist" },
            new object[] { "Darkmantle" },
            new object[] { "Death Dog" },
            new object[] { "Deep Gnome (Svirfneblin)" },
            new object[] { "Deer" },
            new object[] { "Deva" },
            new object[] { "Dire Wolf" },
            new object[] { "Djinni" },
            new object[] { "Doppelganger" },
            new object[] { "Draft Horse" },
            new object[] { "Dragon Turtle" },
            new object[] { "Dretch" },
            new object[] { "Drider" },
            new object[] { "Drow" },
            new object[] { "Druid" },
            new object[] { "Dryad" },
            new object[] { "Duergar" },
            new object[] { "Dust Mephit" },
            new object[] { "Eagle" },
            new object[] { "Earth Elemental" },
            new object[] { "Efreeti" },
            new object[] { "Elephant" },
            new object[] { "Elk" },
            new object[] { "Erinyes" },
            new object[] { "Ettercap" },
            new object[] { "Ettin" },
            new object[] { "Fire Elemental" },
            new object[] { "Fire Giant" },
            new object[] { "Flesh Golem" },
            new object[] { "Flying Snake" },
            new object[] { "Flying Sword" },
            new object[] { "Frog" },
            new object[] { "Frost Giant" },
            new object[] { "Gargoyle" },
            new object[] { "Gelatinous Cube" },
            new object[] { "Ghast" },
            new object[] { "Ghost" },
            new object[] { "Ghoul" },
            new object[] { "Giant Ape" },
            new object[] { "Giant Badger" },
            new object[] { "Giant Bat" },
            new object[] { "Giant Boar" },
            new object[] { "Giant Centipede" },
            new object[] { "Giant Constrictor Snake" },
            new object[] { "Giant Crab" },
            new object[] { "Giant Crocodile" },
            new object[] { "Giant Eagle" },
            new object[] { "Giant Elk" },
            new object[] { "Giant Fire Beetle" },
            new object[] { "Giant Frog" },
            new object[] { "Giant Goat" },
            new object[] { "Giant Hyena" },
            new object[] { "Giant Lizard" },
            new object[] { "Giant Octopus" },
            new object[] { "Giant Owl" },
            new object[] { "Giant Poisonous Snake" },
            new object[] { "Giant Rat" },
            new object[] { "Giant Rat (Diseased)" },
            new object[] { "Giant Scorpion" },
            new object[] { "Giant Sea Horse" },
            new object[] { "Giant Shark" },
            new object[] { "Giant Spider" },
            new object[] { "Giant Toad" },
            new object[] { "Giant Vulture" },
            new object[] { "Giant Wasp" },
            new object[] { "Giant Weasel" },
            new object[] { "Giant Wolf Spider" },
            new object[] { "Gibbering Mouther" },
            new object[] { "Glabrezu" },
            new object[] { "Gladiator" },
            new object[] { "Gnoll" },
            new object[] { "Goat" },
            new object[] { "Goblin" },
            new object[] { "Gold Dragon Wyrmling" },
            new object[] { "Gorgon" },
            new object[] { "Gray Ooze" },
            new object[] { "Green Dragon Wyrmling" },
            new object[] { "Green Hag" },
            new object[] { "Grick" },
            new object[] { "Griffon" },
            new object[] { "Grimlock" },
            new object[] { "Guard" },
            new object[] { "Guardian Naga" },
            new object[] { "Gynosphinx" },
            new object[] { "Half-Red Dragon Veteran" },
            new object[] { "Harpy" },
            new object[] { "Hawk" },
            new object[] { "Hell Hound" },
            new object[] { "Hezrou" },
            new object[] { "Hill Giant" },
            new object[] { "Hippogriff" },
            new object[] { "Hobgoblin" },
            new object[] { "Homunculus" },
            new object[] { "Horned Devil" },
            new object[] { "Hunter Shark" },
            new object[] { "Hydra" },
            new object[] { "Hyena" },
            new object[] { "Ice Devil" },
            new object[] { "Ice Mephit" },
            new object[] { "Imp" },
            new object[] { "Invisible Stalker" },
            new object[] { "Iron Golem" },
            new object[] { "Jackal" },
            new object[] { "Killer Whale" },
            new object[] { "Knight" },
            new object[] { "Kobold" },
            new object[] { "Kraken" },
            new object[] { "Lamia" },
            new object[] { "Lemure" },
            new object[] { "Lich" },
            new object[] { "Lion" },
            new object[] { "Lizard" },
            new object[] { "Lizardfolk" },
            new object[] { "Mage" },
            new object[] { "Magma Mephit" },
            new object[] { "Magmin" },
            new object[] { "Mammoth" },
            new object[] { "Manticore" },
            new object[] { "Marilith" },
            new object[] { "Mastiff" },
            new object[] { "Medusa" },
            new object[] { "Merfolk" },
            new object[] { "Merrow" },
            new object[] { "Mimic" },
            new object[] { "Minotaur" },
            new object[] { "Minotaur Skeleton" },
            new object[] { "Mule" },
            new object[] { "Mummy" },
            new object[] { "Mummy Lord" },
            new object[] { "Nalfeshnee" },
            new object[] { "Night Hag" },
            new object[] { "Nightmare" },
            new object[] { "Noble" },
            new object[] { "Ochre Jelly" },
            new object[] { "Octopus" },
            new object[] { "Ogre" },
            new object[] { "Ogre Zombie" },
            new object[] { "Oni" },
            new object[] { "Orc" },
            new object[] { "Otyugh" },
            new object[] { "Owl" },
            new object[] { "Owlbear" },
            new object[] { "Panther" },
            new object[] { "Pegasus" },
            new object[] { "Phase Spider" },
            new object[] { "Pit Fiend" },
            new object[] { "Planetar" },
            new object[] { "Plesiosaurus" },
            new object[] { "Poisonous Snake" },
            new object[] { "Polar Bear" },
            new object[] { "Pony" },
            new object[] { "Priest" },
            new object[] { "Pseudodragon" },
            new object[] { "Purple Worm" },
            new object[] { "Quasit" },
            new object[] { "Quipper" },
            new object[] { "Rakshasa" },
            new object[] { "Rat" },
            new object[] { "Raven" },
            new object[] { "Red Dragon Wyrmling" },
            new object[] { "Reef Shark" },
            new object[] { "Remorhaz" },
            new object[] { "Rhinoceros" },
            new object[] { "Riding Horse" },
            new object[] { "Roc" },
            new object[] { "Roper" },
            new object[] { "Rug of Smothering" },
            new object[] { "Rust Monster" },
            new object[] { "Saber-Toothed Tiger" },
            new object[] { "Sahuagin" },
            new object[] { "Salamander" },
            new object[] { "Satyr" },
            new object[] { "Scorpion" },
            new object[] { "Scout" },
            new object[] { "Sea Hag" },
            new object[] { "Sea Horse" },
            new object[] { "Shadow" },
            new object[] { "Shambling Mound" },
            new object[] { "Shield Guardian" },
            new object[] { "Shrieker" },
            new object[] { "Silver Dragon Wyrmling" },
            new object[] { "Skeleton" },
            new object[] { "Solar" },
            new object[] { "Specter" },
            new object[] { "Spider" },
            new object[] { "Spirit Naga" },
            new object[] { "Sprite" },
            new object[] { "Spy" },
            new object[] { "Steam Mephit" },
            new object[] { "Stirge" },
            new object[] { "Stone Giant" },
            new object[] { "Stone Golem" },
            new object[] { "Storm Giant" },
            new object[] { "Succubus/Incubus" },
            new object[] { "Swarm of Bats" },
            new object[] { "Swarm of Beetles" },
            new object[] { "Swarm of Centipedes" },
            new object[] { "Swarm of Insects" },
            new object[] { "Swarm of Poisonous Snakes" },
            new object[] { "Swarm of Quippers" },
            new object[] { "Swarm of Rats" },
            new object[] { "Swarm of Ravens" },
            new object[] { "Swarm of Spiders" },
            new object[] { "Swarm of Wasps" },
            new object[] { "Tarrasque" },
            new object[] { "Thug" },
            new object[] { "Tiger" },
            new object[] { "Treant" },
            new object[] { "Tribal Warrior" },
            new object[] { "Triceratops" },
            new object[] { "Troll" },
            new object[] { "Tyrannosaurus Rex" },
            new object[] { "Unicorn" },
            new object[] { "Vampire" },
            new object[] { "Vampire Spawn" },
            new object[] { "Veteran" },
            new object[] { "Violet Fungus" },
            new object[] { "Vrock" },
            new object[] { "Vulture" },
            new object[] { "Warhorse" },
            new object[] { "Warhorse Skeleton" },
            new object[] { "Water Elemental" },
            new object[] { "Weasel" },
            new object[] { "Werebear, Bear form" },
            new object[] { "Werebear, Human form" },
            new object[] { "Werebear, Hybrid form" },
            new object[] { "Wereboar, Boar form" },
            new object[] { "Wereboar, Human form" },
            new object[] { "Wereboar, Hybrid form" },
            new object[] { "Wererat, Human form" },
            new object[] { "Wererat, Hybrid form" },
            new object[] { "Wererat, Rat form" },
            new object[] { "Weretiger, Human form" },
            new object[] { "Weretiger, Hybrid form" },
            new object[] { "Weretiger, Tiger form" },
            new object[] { "Werewolf, Human form" },
            new object[] { "Werewolf, Hybrid form" },
            new object[] { "Werewolf, Wolf form" },
            new object[] { "White Dragon Wyrmling" },
            new object[] { "Wight" },
            new object[] { "Will-o'-Wisp" },
            new object[] { "Winter Wolf" },
            new object[] { "Wolf" },
            new object[] { "Worg" },
            new object[] { "Wraith" },
            new object[] { "Wyvern" },
            new object[] { "Xorn" },
            new object[] { "Young Black Dragon" },
            new object[] { "Young Blue Dragon" },
            new object[] { "Young Brass Dragon" },
            new object[] { "Young Bronze Dragon" },
            new object[] { "Young Copper Dragon" },
            new object[] { "Young Gold Dragon" },
            new object[] { "Young Green Dragon" },
            new object[] { "Young Red Dragon" },
            new object[] { "Young Silver Dragon" },
            new object[] { "Young White Dragon" },
            new object[] { "Zombie" }
        };
    }
}
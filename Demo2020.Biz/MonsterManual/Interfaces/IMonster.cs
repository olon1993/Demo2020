using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using System.Collections.Generic;

namespace Demo2020.Biz.MonsterManual.Interfaces
{
    public interface IMonster 
    {
        string Name { get; set; }
        string Size { get; set; }
        string MonsterType { get; set; }
        string MonsterSubtype { get; set; }
        string Alignment { get; set; }
        int ArmorClass { get; set; }
        int HitPoints { get; set; }
        string HitPointsCalculation { get; set; }
        Speed Speed { get; set; }
        int Strength { get; set; }
        int StrengthModifier { get; set; }
        int Dexterity { get; set; }
        int DexterityModifier { get; set; }
        int Constitution { get; set; }
        int ConstitutionModifier { get; set; }
        int Intelligence { get; set; }
        int IntelligenceModifier { get; set; }
        int Wisdom { get; set; }
        int WisdomModifier { get; set; }
        int Charisma { get; set; }
        int CharismaModifier { get; set; }
        bool IsDataComplete { get; set; }
        List<Proficiency> Proficiencies { get; set; }
        double ChallengeRating { get; set; }
        int Xp { get; set; }
    }
}

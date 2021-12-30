using Demo2020.Biz.MonsterManual.Models;
using System.Collections.Generic;
using Xunit;

namespace Demo2020.Test.MonsterManual
{
    public class Monster_Test
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void CalculateModifier_Test(int abilityScore, int correctModifier)
        {
            Monster monster = new Monster();
            monster.Strength = abilityScore;

            Assert.Equal(monster.StrengthModifier, correctModifier);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 1, -5 },
            new object[] { 2, -4 },
            new object[] { 3, -4 },
            new object[] { 4, -3 },
            new object[] { 5, -3 },
            new object[] { 6, -2 },
            new object[] { 7, -2 },
            new object[] { 8, -1 },
            new object[] { 9, -1 },
            new object[] { 10, 0 },
            new object[] { 11, 0 },
            new object[] { 12, 1 },
            new object[] { 13, 1 },
            new object[] { 14, 2 },
            new object[] { 15, 2 },
            new object[] { 16, 3 },
            new object[] { 17, 3 },
            new object[] { 18, 4 },
            new object[] { 19, 4 },
            new object[] { 20, 5 },
            new object[] { 21, 5 },
            new object[] { 22, 6 },
            new object[] { 23, 6 },
            new object[] { 24, 7 },
            new object[] { 25, 7 },
            new object[] { 26, 8 },
            new object[] { 27, 8 },
            new object[] { 28, 9 },
            new object[] { 29, 9 },
            new object[] { 30, 10 },
        };
    }
}

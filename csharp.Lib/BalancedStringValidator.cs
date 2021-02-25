using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.Lib
{
    public static class BalancedStringValidator
    {
        public static bool IsBalanced(this string input, string balancingCharacterPairs)
        {
            var usedOpeningCharacters = new Stack<char>();
            var validOpeningCharacters = balancingCharacterPairs.Where((c, index) => index % 2 == 0);

            var isParenOpened = false;
            foreach (var character in input)
            {
                switch (character)
                {
                    case '(':
                    case '[':
                        isParenOpened = true;
                        break;
                    case ')':
                    case ']':
                        return isParenOpened;
                }
            }
            return !isParenOpened;
        }
    }
}

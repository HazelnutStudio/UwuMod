using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazelnut272.UwuMod
{
    public static class UwuTranslator
    {

        public static string TranslateString(string text, int seed = -1)
        {
            string output = text.ToLower();

            string[] tags = ExtractTags(text);

            // Special Cases
            output = TranslateSpecialCases(output);
            // General letter replacement
            output = LetterReplacement(output);
            // silly faces
            output = InsertFaces(output, seed);

            output = InsertTags(output, tags);

            return output;
        }

        private static string[] ExtractTags(string input)
        {
            List<string> tags = new List<string>();

            bool lookingForClosingBracket = false;
            int indexOfOpeningBracket = -1;

            List<char> characters = input.ToCharArray().ToList();
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i] == '<')
                {
                    lookingForClosingBracket = true;
                    indexOfOpeningBracket = i;
                }

                if (characters[i] == '>' && lookingForClosingBracket)
                {
                    lookingForClosingBracket = false;
                    int charactersToRemove = (i - indexOfOpeningBracket) + 1;

                    List<char> removedCharacters = new List<char>();
                    for (int x = 0; x < charactersToRemove; x++)
                    {
                        removedCharacters.Add(characters[x + indexOfOpeningBracket]);
                    }
                    string tag = String.Join(null, removedCharacters.ToArray());
                    if (tag != null)
                        tags.Add(tag);
                }
            }

            return tags.ToArray();
        }

        private static Dictionary<string, string> SPECIAL_CASES = new Dictionary<string, string>()
        {
            {"to ", "tuwu " }, {"do ", "duwu "}, {"you", "uwu"}, {"th", "d"}, {"can", "cawn"}, {"some", "sowme"}, {"is", "iws"}
        };
        private static string TranslateSpecialCases(string input)
        {
            string output = input;
            foreach (KeyValuePair<string,string> specialCase in SPECIAL_CASES)
            {
                output = output.Replace(specialCase.Key, specialCase.Value);
            }
            return output;
        }

        private static Dictionary<char, char> LETTER_REPLACEMENT = new Dictionary<char, char>()
        {
            {'l', 'w'}, {'r', 'w'}
        };

        private static string LetterReplacement(string input)
        {
            string output = input;
            foreach (KeyValuePair<char,char> replaceableCharacter in LETTER_REPLACEMENT)
            {
                output = output.Replace(replaceableCharacter.Key, replaceableCharacter.Value);
            }
            return output;
        }

        private static string InsertTags(string input, string[] tags)
        {
            string output = input;
            List<char> chars = input.ToCharArray().ToList();

            foreach (string tag in tags)
            {
                string translatedTag = TranslateSpecialCases(tag);
                translatedTag = LetterReplacement(translatedTag);

                output = output.Replace(translatedTag, tag);
            }

            return output;
        }


        private static string[] RANDOM_FACES = { "qwq", ".-.", "Σ:3", "=w=", "@n@", "^_^", ":3", "\\^o^/", "T_T", "^-^", "uwu", "owo", "=^_^=", ":)", ":D", ">.<", ":p", "^^;", "*_+", ";]", "> ~ <", ":>", "c:" };
        private static string InsertFaces(string input, int seed = -1)
        {
            string output = input;
            Random random;
            if(seed == -1)
            {
                random = new Random();
            }
            else
            {
                random = new Random(seed + Main.SessionRN);
            }

            int rand = random.Next(RANDOM_FACES.Length);
            output += $" {RANDOM_FACES[rand]}";
            return output;
            //string face = 
        }
    }
}

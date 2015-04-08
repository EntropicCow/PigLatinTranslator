using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinTranslator
{
    class Translator
    {


        public Translator()
        {

        }

        public StringBuilder translateWords(string input)
        {
            List<string> deconstructedPhrase = new List<string>(); //take the input string and convert it to string list then stringbuilder list.
            List<StringBuilder> workingPhrase = new List<StringBuilder>();
            StringBuilder finalPhrase = new StringBuilder();

            deconstructedPhrase = input.Split(' ').ToList<string>();
            foreach (string temp in deconstructedPhrase)
            {
                workingPhrase.Add(new StringBuilder(temp));
            }

            foreach (StringBuilder temp in workingPhrase)
            { //this is where the "magic" happens
                char[] tempChar = new char[4];
                char[] tempPunct = new char[1];

                if (temp.Length > 1) //check input phrase length, prevents out of range exceptions for short inputs
                {
                    temp.CopyTo(0, tempChar, 0, 1);
                    temp.CopyTo(1, tempChar, 1, 1);
                }
                if (temp.Length > 2)
                {
                    temp.CopyTo(2, tempChar, 2, 1);
                }
                if (temp.Length > 3)
                {
                    temp.CopyTo(3, tempChar, 3, 1);
                }

                temp.CopyTo(temp.Length - 1, tempPunct, 0, 1);
                if ("aeiouAEIOU".Contains(tempChar[0])) // is it a vowel?
                {
                    if (char.IsPunctuation(tempPunct[0])) //check for punctuation
                    {
                        temp.Insert(temp.Length - 1, "way"); //insert "way" before punctuation
                    }
                    else
                    {
                        temp.Append("way"); // append "way" at the end.
                    }

                    finalPhrase.Append(temp); // append finalized word to stringbuilder(no letter is moved so no cap check needed).
                    finalPhrase.Append(" "); //space for next word.

                }
                else if (char.IsLetter(tempChar[0])) //is the first character a letter?
                {
                    if ("ScrscrSkrskrSplsplSprsprStrstrThrthrThwthw".Contains(new string(tempChar, 0, 3))) //check for 3 character consonant cluster
                    {
                        if (char.IsUpper(tempChar[0]))
                        {
                            temp.Remove(3, 1);
                            temp.Insert(3, char.ToUpper(tempChar[3]));
                        }
                        temp.Remove(0, 3);
                        if (char.IsPunctuation(tempPunct[0]))//is there punctuation at the end?
                        {
                            temp.Insert(temp.Length - 1, char.ToLower(tempChar[0])); // insert consonant + "ay" before punctuation
                            temp.Insert(temp.Length - 1, tempChar[1]);
                            temp.Insert(temp.Length - 1, tempChar[2]);
                            temp.Insert(temp.Length - 1, "ay");
                        }
                        else
                        {
                            temp.Insert(temp.Length, char.ToLower(tempChar[0])); //insert the consonant + "ay at the end as lowercase
                            temp.Insert(temp.Length, tempChar[1]);
                            temp.Insert(temp.Length, tempChar[2]);
                            temp.Append("ay");
                        }


                    }
                    else if ("BlblBrbrChchClclCrcrDrdrDwdwFlflFrfrGrgrGlglGngnGwgwKrkrKlklMnmnPhphPnpnQuquRhrhScscSlslSmsmSnsnSpspSwswThthTrtrTwtwWhwhWrwrXyxy".Contains(new string(tempChar, 0, 2))) //check for 2 character consonant cluster
                    {
                        if (char.IsUpper(tempChar[0]))
                        {
                            temp.Remove(2, 1);
                            temp.Insert(2, char.ToUpper(tempChar[2]));
                        }
                        temp.Remove(0, 2);
                        if (char.IsPunctuation(tempPunct[0]))//is there punctuation at the end?
                        {
                            temp.Insert(temp.Length - 1, char.ToLower(tempChar[0])); // insert consonant + "ay" before punctuation
                            temp.Insert(temp.Length - 1, tempChar[1]);
                            temp.Insert(temp.Length - 1, "ay");
                        }
                        else
                        {
                            temp.Insert(temp.Length, char.ToLower(tempChar[0])); //insert the consonant + "ay at the end as lowercase
                            temp.Insert(temp.Length, tempChar[1]);
                            temp.Append("ay");
                        }
                    }
                    else //is it capitalized and single consonant?
                    {
                        if (char.IsUpper(tempChar[0]))
                        {
                            temp.Remove(1, 1);
                            temp.Insert(1, char.ToUpper(tempChar[1])); //remove then re-insert the 2nd letter as uppercase

                        }
                        temp.Remove(0, 1);
                        if (char.IsPunctuation(tempPunct[0]))
                        {
                            temp.Insert(temp.Length - 1, char.ToLower(tempChar[0]));
                            temp.Insert(temp.Length - 1, "ay");
                        }
                        else
                        {//take first letter and reinsert with "ay" at the end.
                            temp.Insert(temp.Length, char.ToLower(tempChar[0]));
                            temp.Append("ay");
                        }
                    }

                    finalPhrase.Append(temp); //appeand finalized word
                    finalPhrase.Append(" "); //space for next word
                }
                else
                {
                    finalPhrase.Append(temp); //append finalized word ( if no punctuation or capitalization found).
                    finalPhrase.Append(" "); //space for next word.
                }

            }
            return finalPhrase; //finally, return the finished phrase
        }


    }
}

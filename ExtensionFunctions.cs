using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SaiPrototype
{
    static class ExtensionFunctions
    {
        /// <summary>
        /// <para>Takes strings and turns them into a similar format so comparisons are easier.</para>
        /// <para>Works by assuming certain things are universally considered the same.</para>
        /// <para>For example, we can assume that in any case someone says "where can I find bla bla bla...",
        /// they could have said "where is bla bla bla...", so we replace "can I find" with "is".</para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Standardize(this string str)
        {
            str = str.TrimAndReduce();
            str = str.ToLower();

            // Standard replacements
            str = Regex.Replace(str, @"can i find", "is");
            str = Regex.Replace(str, @"how do i get to", "where is");
            str = Regex.Replace(str, @"can you tell me ", "");
            str = Regex.Replace(str, @"i want to know ", "");
            str = Regex.Replace(str, @"tell me ", "");


            // contractions
            str = Regex.Replace(str, @"where's|wheres", "where is");
            str = Regex.Replace(str, @"who's|whos", "who is");
            str = Regex.Replace(str, @"what's|whats", "what is");
            str = Regex.Replace(str, @"when's|whens", "when is");
            str = Regex.Replace(str, @"why's|whys", "why is");
            str = Regex.Replace(str, @"how's|hows", "how is");
            
            str = Regex.Replace(str, @"i'm|im", "i am");
            str = Regex.Replace(str, @"you're|youre", "you are");
            str = Regex.Replace(str, @"he's|hes", "he is");
            str = Regex.Replace(str, @"she's|shes", "she is");
            str = Regex.Replace(str, @"it's", "it is");
            str = Regex.Replace(str, @"we're", "we are");
            str = Regex.Replace(str, @"they're|theyre", "they are");




            // remove punctuation
            str = Regex.Replace(str, @"\?", "");
            str = Regex.Replace(str, @"\.", "");
            str = Regex.Replace(str, @"!", "");
            str = Regex.Replace(str, @";", "");
            str = Regex.Replace(str, @",", "");

            return str;
        }
        public static string TrimAndReduce(this string str)
        {
            str = Regex.Replace(str, @"[ ]{2}", " ");

            return str;
        }
    }
}

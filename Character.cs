using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SaiPrototype
{
    /// <summary>
    /// <para>
    /// The Character class is the backbone of the whole thing.
    /// You can create a new character, and using either AddPatternResponse
    /// or AddDirectResponse, you can tell the character how to
    /// respond to certain inputs.</para>
    /// <para>By using AddEquivalencies and AddPatternEquivalencies, you can
    /// make the character consider some phrases the same. For example,
    /// you could have the character consider the phrase "hello" to be
    /// the same as "hi" and "hey".</para>
    /// </summary>
    class Character
    {
        private Dictionary<string,Response> DirectResponse = new Dictionary<string, Response>();
        private Dictionary<string, List<string>> PatternEquivalencies = new Dictionary<string, List<string>>();
        public Character()
        {

        }
        /// <summary>
        /// Gets a response from the character, if a response has been registered
        /// for the given input. Otherwise, throws a NoResponseException.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GetResponse(string input)
        {
            input = input.Standardize();
            if (DirectResponse.ContainsKey(input))
            {
                return DirectResponse[input].text;
            } else
            {
                throw new NoResponseException();
            }
        }
        /// <summary>
        /// Registers a new direct response with this character. Tells
        /// the character that he/she should respond a certain way
        /// when he/she receives a certain input
        /// </summary>
        /// <param name="@in"></param>
        /// <param name="response"></param>
        public void AddDirectResponse(string @in, string response)
        {
            @in = @in.Standardize();
            if (DirectResponse.ContainsKey(@in))
            {
                DirectResponse[@in].text = response;
            } else
            {
                DirectResponse.Add(@in, new Response(response));
            }
        }
        /// <summary>
        /// <para>Makes the character consider two phrases or words to be the same.</para>
        /// For example, if you say AddDirectResponse("hi","hello there"), and then
        /// AddEquivalency("hi","bonjour"), then the character will also respond to
        /// "bonjour" by saying "hello there".
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void AddEquivalency(string a, string b)
        {
            a = a.Standardize();
            b = b.Standardize();
            if (!DirectResponse.ContainsKey(a) && !DirectResponse.ContainsKey(b))
            {
                DirectResponse.Add(a, new Response(""));
                DirectResponse.Add(b, DirectResponse[a]);
                return;
            }
            if (DirectResponse.ContainsKey(a))
            {
                DirectResponse.Add(b, DirectResponse[a]); 
            } else
            if (DirectResponse.ContainsKey(b))
            {
                DirectResponse.Add(a, DirectResponse[b]);
            }
        }
        /// <summary>
        /// Just a way to add multiple equivalencies at once.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="strs"></param>
        public void AddEquivalencies(string a, params string[] strs)
        {
            foreach (string str in strs)
            {
                AddEquivalency(a, str);
            }
        }
        /// <summary>
        /// Returns true if the character considers the two phrases to be equivalent.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool AreEquivalent(string a, string b)
        {
            a = a.Standardize();
            b = b.Standardize();
            if (!DirectResponse.ContainsKey(a) || !DirectResponse.ContainsKey(b))
            {
                return false;
            }
            if (DirectResponse[a].Equals(DirectResponse[b]))
            {
                return true;
            } else
            {
                return false;
            }
        }/// <summary>
        /// <para>Patterns are an interesting part of the Character class. This is how they work:</para>
        /// 
        /// <para>If you use AddDirectResponse("who is bob","bob is the king of bobania"), then the character
        /// will respond only to that exact phrase. Not to something similar, like "can you tell me who bob is?" (which, after
        /// the Standardize function has been called [see ExtensionFunctions.cs], actually ends up being "who bob is").</para>
        /// 
        /// <para>You could of course also do AddDirectResponse("who bob is","bob is the king of bobania"), or just
        /// AddEquivalency("who bob is", "who is bob"), but this can get really tedious if you want your character
        /// to be able to respond to questions about fifty different people.</para>
        /// 
        /// <para>Patterns are a way to take care of equivalent types of questions so you don't have to keep
        /// adding equivalencies for the same kind of question.</para>
        /// 
        /// <para>For example, AddPatternEquivalency("who is $","who $ is") will let you then do 
        /// AddPatternResponse("who is $","bob","bob is the king of bobania"), and that response will also be given
        /// for the phrase "who bob is".</para>
        /// 
        /// <para>You MUST set pattern equivalencies BEFORE you add pattern responses.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void AddPatternEquivalency(string a, string b)
        {
            a = a.Standardize();
            b = b.Standardize();
            if (!PatternEquivalencies.ContainsKey(a) && !PatternEquivalencies.ContainsKey(b))
            {
                PatternEquivalencies.Add(a, new List<string>());
                PatternEquivalencies.Add(b, PatternEquivalencies[a]);
                PatternEquivalencies[a].Add(a);
                PatternEquivalencies[a].Add(b);
                return;
            }
            if (PatternEquivalencies.ContainsKey(a))
            {
                PatternEquivalencies.Add(b, PatternEquivalencies[a]);
                PatternEquivalencies[a].Add(b);
            }
            else
            if (PatternEquivalencies.ContainsKey(b))
            {
                PatternEquivalencies.Add(a, PatternEquivalencies[b]);
                PatternEquivalencies[a].Add(b);
            }
        }
        /// <summary>
        /// Just a way to add multiple pattern equivalencies at once.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="strs"></param>
        public void AddPatternEquivalencies(string a, params string[] strs)
        {
            foreach (string str in strs)
            {
                AddPatternEquivalency(a, str);
            }
        }
        /// <summary>
        /// Returns true if the two patterns are registered as equivalent.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool PatternsAreEquivalent(string a, string b)
        {
            a = a.Standardize();
            b = b.Standardize();
            if (!PatternEquivalencies.ContainsKey(a) || !PatternEquivalencies.ContainsKey(b))
            {
                return false;
            }
            if (PatternEquivalencies[a].Equals(PatternEquivalencies[b]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Patterns that are equivalent to each other all point in the dictionary to the same list.
        /// The list contains all equivalent patterns as strings.
        /// <para>This function retrieves that list.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public List<string> GetPatternList(string a)
        {
            a = a.Standardize();
            if (PatternEquivalencies.ContainsKey(a))
            {
                return PatternEquivalencies[a];
            } else
            {
                throw new NoResponseException();
            }
        }
        /// <summary>
        /// Tells the character how to respond when a statement is given
        /// that matches a pattern.
        /// <para>For example, if the pattern is "who is $", and the val
        /// is "bob", then response will be given as the character's reply to the phrase, "who is bob".</para>
        /// <para>But if "who is $" is equivalent to "who $ is", then the response will
        /// also be given for "who bob is".</para>
        /// </summary>
        /// <param name="pat"></param>
        /// <param name="val"></param>
        /// <param name="response"></param>
        public void AddPatternResponse(string pat,string val,string response)
        {
            List<string> patterns = GetPatternList(pat);
            foreach (string pattern in patterns)
            {
                string statement = Regex.Replace(pattern,@"\$", val);
                AddDirectResponse(statement, response);
            }
        }
        /// <summary>
        /// Just a way to make sure values in the dictionary are stored
        /// and updated by reference, not value. That way, equivalent
        /// phrases all point to the same response object, not just duplicate
        /// string values.
        /// </summary>
        class Response
        {
            public string text;
            public Response(string str)
            {
                text = str;
            }
        }
        
    }
    // just in case we ask for a response that doesn't exist
    class NoResponseException : Exception
    {

    }
}

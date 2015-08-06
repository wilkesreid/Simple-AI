using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiPrototype
{
    /// <summary>
    /// <para>This is the sample program to test out the Character class.
    /// It's a very simple while loop that accepts the user's input 
    /// and uses it to get a response from the character, Bob.</para>
    /// </summary>
    class Program
    {
        // Main method
        static void Main(string[] args)
        {
            // Situation
            wl("The following game is based more around asking questions than responding to what the traveler says. "+
                "He won't understand if you try to make statements. He's better at responding to relevant questions.");
            wl("");
            wl("Type \"exit\" or \"quit\" to leave the game.");
            wl("");
            wl(SampleGame.startSituation);

            string input;
            // Console-like loop
            do
            {
                // Get the user's input each iteration of the loop
                input = rl().Standardize();
                // Attempt to get a response from Bob
                try
                {
                    wl(SampleGame.Traveler.GetResponse(input));
                }
                // If Bob gives no response, handle the exception
                catch (NoResponseException)
                {
                    wl("*The traveler doesn't respond, as if he didn't hear you.*");
                }
                
                // quit loop if user says "quit", or anything equivalent
            } while (!SampleGame.Traveler.AreEquivalent(input,"quit"));
        }
        // Convenient WriteLine method
        public static void wl(object str)
        {
            Console.WriteLine(str);
        }
        // Convenient ReadLine method
        public static string rl()
        {
            return Console.ReadLine();
        }
        // Convenient "wait for user to press a key" method
        public static void WaitForInput()
        {
            Console.ReadKey();
        }
    }
}

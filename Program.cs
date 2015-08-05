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
            // Create test character
            Character Bob = new Character();

            // Customize Bob

            Bob.AddDirectResponse("hello", "hello yourself");
            Bob.AddEquivalencies("hello", "hi", "hey", "sup");
            Bob.AddEquivalencies("exit", "quit");

            Bob.AddPatternEquivalencies("who is $", "who $ is", "who $");
            Bob.AddPatternEquivalencies("where is $", "where $ is", "where $");

            Bob.AddPatternResponse("who is $", "bob", "Bob is the king of Bobania!");
            Bob.AddPatternResponse("where is $", "bob", "I think he's up in his castle ruling over Bobania.");

            string input;
            // Console-like loop
            do
            {
                // Get the user's input each iteration of the loop
                input = rl().Standardize();
                // Attempt to get a response from Bob
                try
                {
                    wl(Bob.GetResponse(input));
                }
                // If Bob gives no response, handle the exception
                catch (NoResponseException)
                {
                    wl("I have no response to that.");
                }
                
                // quit loop if user says "quit", or anything equivalent
            } while (!Bob.AreEquivalent(input,"quit"));
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

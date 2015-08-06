using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiPrototype
{
    static class SampleGame
    {
        public static Character Traveler = new Character();
        public static string startSituation = "You find yourself in a forest. The canopy above is thick, and only lets in enough light to create\nwirey patterns on the leaf-covered " +
            "ground. You see a traveler ahead, and he approaches you, waiting for you to say something.";

        static SampleGame()
        {
            Traveler.AddDirectResponse("hello", "Hello. It's a nice evening for a walk, isn't it?");
            Traveler.AddEquivalencies("hello", "hey", "hi", "sup", "good evening", "goodday");

            Traveler.AddDirectResponse("who are you", "I'm just a traveler. Nobody special");
            Traveler.AddEquivalencies("who are you", "who you are");

            Traveler.AddDirectResponse("what are you doing here", "Now that's none of your business, is it?");
            Traveler.AddEquivalencies("what are you doing here", "what are you up to", "what are you doing","what you are doing here");

            Traveler.AddDirectResponse("where do you come from", "I'm from a faraway land called Drang. I haven't been there in a very long time...");
            Traveler.AddEquivalencies("where do you come from", "where are you from", "where you are from", "where were you born", "where you were born");

            Traveler.AddDirectResponse("where am i", "I'm not sure exactly where we are, to be honest. It's possible this is the land of Sturm...");
            Traveler.AddEquivalencies("where am i", "where is this", "what is this place", "where is this place", "where i am", "where this is", "what this place is");

            Traveler.AddDirectResponse("who am i", "I have no idea who you are. I just met you.");
            Traveler.AddEquivalencies("who am i","who i am","who me");

            Traveler.AddPatternEquivalencies("who is $", "who $ is", "who $");

            Traveler.AddPatternEquivalencies("what is $", "what $ is", "what $");

            Traveler.AddPatternResponse("what is $", "drang", "Drang is a land far away from here. I could only tell you old stories, but I don't feel like reminiscing right at this moment.");
            Traveler.AddPatternResponse("what is $", "sturm", "Sturm is the largest nation on this continent. That's the only reason I suppose we could be in it.");

            Traveler.AddEquivalencies("quit", "exit");
        }
    }
}

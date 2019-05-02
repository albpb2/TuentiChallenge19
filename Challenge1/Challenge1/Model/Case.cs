using System;

namespace Challenge1.Model
{
    public class Case
    {
        private const int PeoplePerTortilla = 2;

        public Case(int onionists, int tasteless)
        {
            Onionists = onionists;
            Tasteless = tasteless;
        }

        public int Onionists { get; set; }

        public int Tasteless { get; set; }

        public int RequiredTortillas => 
            (int)Math.Ceiling((double)Onionists / PeoplePerTortilla) 
            + (int)Math.Ceiling((double)Tasteless / PeoplePerTortilla);
    }
}

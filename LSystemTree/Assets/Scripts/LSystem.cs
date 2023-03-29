using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystem
{
    public List<string> Alphabet { get; set; } = new List<string> { "A", "B" };
    public string Axiom { get; set; } = "A";
    public Dictionary<string, string> Rules { get; set; } = new Dictionary<string, string>() { { "A", "AB"}, { "B", "A"} };
    public int Iteration { get; set; } = 0;
    public string Sentence { get; set; }

    public LSystem() 
    {
        Sentence = Axiom;
    }

    public LSystem(List<string> alphabet, string axiom, Dictionary<string, string> rules) 
    {
        Alphabet = alphabet;
        Axiom = axiom;
        Rules = rules;
        Sentence = Axiom;
    }

    public string IterateForward()
    {
        Iteration++;
        string newSentence = "";
        foreach (char c in Sentence)
        {
            //tfh egyelore deterministic, context-free
            if (Rules.ContainsKey(c.ToString())) newSentence += Rules[c.ToString()];
        }
        Sentence = newSentence;
        return Sentence;
    }


}

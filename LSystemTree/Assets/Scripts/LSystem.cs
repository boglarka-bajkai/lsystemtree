using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystem
{
    public string Axiom { get; set; } = "A";
    public List<Rule> Rules { get; set; } = new List<Rule>() { new Rule("A", "AB"), new Rule("B", "A")};
    public int Iteration { get; set; } = 0;
    public float Angle { get; set; }
    public string Sentence { get; set; }

    public LSystem() 
    {
        Sentence = Axiom;
    }

    public LSystem(string axiom, List<Rule> rules) 
    {
        Axiom = axiom;
        Rules = rules;
        Sentence = Axiom;
    }

    public LSystem(string axiom, List<Rule> rules, float angle)
    {
        Axiom = axiom;
        Rules = rules;
        Sentence = Axiom;
        Angle = angle;
    }

    public string IterateForward()
    {
        Iteration++;
        string newSentence = "";
        foreach (char c in Sentence)
        {
            //tfh egyelore deterministic, context-free
            if (CheckRulesForKey(c.ToString())) newSentence += FindRule(c.ToString());
            else newSentence += c;
        }
        Sentence = newSentence;
        return Sentence;
    }

    public string GetIteration(int iteration)
    {
        Iteration = 0;
        for(int i = 0; i < iteration-1; i++)
            IterateForward();
        return IterateForward();
    }

    private bool CheckRulesForKey(string key)
    {
        foreach(Rule rule in Rules)
            if (rule.start == key) return true;
        return false;
    }

    private string FindRule(string key)
    {
        foreach(Rule rule in Rules)
            if(rule.start == key) return rule.end;
        return null;
    }
}

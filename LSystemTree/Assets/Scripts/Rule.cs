using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule
{
    public string start;
    public string end;
    public float weight;

    public Rule(string start, string end)
    {
        this.start = start;
        this.end = end;
        weight = 1;
    }

    public Rule(string start, string end, float weight)
    {
        this.start = start;
        this.end = end;
        this.weight = weight;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LSystemObjectBehaviour : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _iterationText;
    [SerializeField] private Button _button;

    private LSystem system;

    public void Start()
    {
        //system = new LSystem();
        //CreateFractalBinaryTree();
        //CreateCantorSet();
        //CreateBush();
        CreateFractalPlant();
        _text.SetText(system.Axiom);
    }

    public void ButtonClicked()
    {
        //kill all children
        foreach (Transform child in this.gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        string sentence = system.IterateForward();
        _text.SetText(sentence);
        _iterationText.SetText("Iteration: " + system.Iteration);
        var turtle = gameObject.GetComponent<LTurtle>();
        turtle.ResetPlane(this.gameObject.transform);
        turtle.Sentence = sentence;
        turtle.Angle = 22.5f;
        turtle.Length = 1f;
        turtle.Draw();
    }

    public void CreateFractalBinaryTree()
    {
        string axiom = "0";
        var rules = new List<Rule>() { new Rule("0", "1[0]0"), new Rule("1", "11") };
        system = new LSystem(axiom, rules);
    }

    public void CreateCantorSet()
    {
        string axiom = "A";
        var rules = new List<Rule>() { new Rule("A", "ABA"), new Rule("B", "BBB") };
        system = new LSystem(axiom, rules);
    }

    public void CreateFractalPlant()
    {
        string axiom = "X";
        var rules = new List<Rule>() { new Rule("X", "F+[[X]-X]-F[-FX]+X"), new Rule("F", "FF") };
        system = new LSystem(axiom, rules);
    }

    public void CreateFractalLeaf()
    {
        string axiom = "X";
        var rules = new List<Rule>() { new Rule("F", "FF"), new Rule("X", "F[+X]F[-X]+X") };
        system = new LSystem(axiom, rules);

        //angle: 20
    }

    public void CreateBush()
    {
        string axiom = "A";
        var rules = new List<Rule>() {
            new Rule("A", "[&FL!A]/////'[&FL!A]///////’[&FL!A]"),
            new Rule("F", "S ///// F"),
            new Rule("S", "F L"),
            new Rule("L", "l")
        };
        system = new LSystem(axiom, rules);
    }
}

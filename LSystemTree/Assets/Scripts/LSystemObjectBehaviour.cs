using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LSystemObjectBehaviour : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;

    private LSystem system;

    public void Start()
    {
        //system = new LSystem();
        //CreateFractalBinaryTree();
        //CreateCantorSet();
        CreateBush();
        _text.SetText(system.Axiom);
    }

    public void ButtonClicked()
    {
        _text.SetText(system.IterateForward());
    }

    /*special rules for drawing (from The Algorithmic Beauty of Plants):
         * angle : 25 degree
         * F : draw forward
         * f : move forward
         * - : turn right <angle>
         * + : turn left <angle>
         * ? : pitch up
         * & : pitch down
         * \ : roll left
         * / : roll right
         * | : turn around
         * $ : rotate the turtle to vertical
         * [ : push position and angle / start a branch
         * ] : pop position and angle / complete a branch
        */

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
        var rules = new List<Rule>() { new Rule("X", "F+[[X]-X-F[-FX]+X"), new Rule("F", "FF") };
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
            new Rule("L", "['''??{-f+f+f-|-f+f+f}]")
        };
        float angle = 22.5f;
        system = new LSystem(axiom, rules, angle);
    }
}

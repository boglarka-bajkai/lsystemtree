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
        CreateCantorSet();
        _text.SetText(system.Axiom);
    }

    public void ButtonClicked()
    {
        _text.SetText(system.IterateForward());
    }

    public void CreateFractalBinaryTree()
    {
        string axiom = "0";
        Dictionary<string, string> rules = new Dictionary<string, string>() { { "0", "1[0]0" }, { "1", "11" } };
        system = new LSystem(axiom, rules);
    }

    public void CreateCantorSet()
    {
        string axiom = "A";
        Dictionary<string, string> rules = new Dictionary<string, string>() { { "A", "ABA" }, { "B", "BBB" } };
        system = new LSystem(axiom, rules);
    }

    public void CreateFractalPlant()
    {
        string axiom = "X";
        Dictionary<string, string> rules = new Dictionary<string, string>() { { "X", "F+[[X]-X-F[-FX]+X" }, { "F", "FF" } };
        system = new LSystem(axiom, rules);

        /*special rules for drawing:
         * angle : 25 degree
         * F : draw forward
         * - : turn right <angle>
         * + : turn left <angle>
         * X : doesn't do anything
         * [ : push position and angle
         * ] : pop position and angle
        */
    }

    public void CreateFractalLeaf()
    {
        string axiom = "X";
        Dictionary<string, string> rules = new Dictionary<string, string>() { { "F", "FF" }, { "X", "F[+X]F[-X]+X" } };
        system = new LSystem(axiom, rules);

        //angle: 20
    }
}

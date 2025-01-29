# L-System Tree Generation

An university project to procedurally generate 3D trees in Unity using L-Systems.
All L-System logic is based on the book The Algorithmic Beauty of Plants by Aristid Lindenmayer.

Turtle graphics is used for painting 2D shapes with Unity LineRenderer. 3D turtle graphics is used for constructing 3D shapes, based on yaw, pitch, and roll axes.

![image](https://github.com/user-attachments/assets/ddc11a39-ca18-4cac-9fe5-66bd29c8522f)

Fractal plant. The generated sentence can be viewed on the left.
L-System used:
-	variables: X F
-	constants: + - [ ]
-	axiom: X
-	rules:
    -	X -> F+[[X]-X]-F[-FX]+X
    -	F -> FF
-	angle: 22,5°

![image](https://github.com/user-attachments/assets/b537750a-45eb-40c2-b711-360b36dc8172)

Bush-like structure. The L-System used is the same as the book:

![image](https://github.com/user-attachments/assets/9dbb2650-4816-4118-aec1-8db8f0096280)

(Source: Algorithmic Beauty of Plants, Figure 1.25)

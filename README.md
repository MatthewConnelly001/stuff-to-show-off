# stuff-to-show-off

This is a place where I dump various programs, games, and tools I created for convenient access in interviews or for fun.


## Coffee Machine Simulator

A .NET program I created for a coding challenge when applying for a job. 

This is a program runs a menu that allows the user to input their actions (e.g. insert coin, purchase a type of coffee), and prints the resulting action. 
It accounts for change, user money balance, and stock of coins and coffees in storage.


## Evolution Sim

A sandbox game that I originally made in Game Maker Studio during my childhood. Here, I decided to make a new version with improved AI in Godot. 
The mechanics and controls are unpolished, but the game entirely works at the very least.

It is a top-down game where you are given tools to spawn creatures and pellets which they eat, and change the environment such as where walls are and how many pellets spawn.
Creatures can eat pellets or attack other creatures if large enough. 
The difference in colour between pellets and the creatures that eat them deturmines how much energy they obtain from it.
The AI of creatures is a simple perceptron which is applied on all objects around the creature to deturmine what to travel towards or flee from.
The weights for the AI and physical characteristics (e.g. movement speed) are all randomly mutated after a creature is born, which is done by mitosis when a creature reaches it's appropriate size.


## Planet Defender

The first game using the Godot Engine that I published to Itch.io.

It is a small survival/tower defence game where you defend a 2D planet from asteroids and UFOs while piloting a small tank on the surface.


## Wave Function Collapse Algorithm

An interesting concept for an algorithm to create randomly generated content. The algorithm requires a training input, to which it analyses patterns (usually a 3x3 grid) and prints output image that fits this pattern. 
It does this by starting at a point that has already been deturmined if exists, and permiating all possible neighboring, and does so probabilistically if uncertain.

Resources used:

https://github.com/mxgmn/WaveFunctionCollapse
https://www.youtube.com/watch?v=fnFj3dOKcIQ&t=594s

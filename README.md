# Performance Pattern Exercises

## Instructions

This repository contains various exercises where you can achieve heavy performance improvements by implementing Design Patterns.

[E-Book: Level Up your code with Game Programming Patterns](https://resources.unity.com/games/level-up-your-code-with-game-programming-patterns)

## P1_Pooling

Here, the problem is that GameObjects are Instantiated frequently. These are heavy instructions that can be avoided.

Hints:
- How many objects do you think you'll need?
- What will your game's behaviour be if you need more than anticipated?

## P2_Flyweight

Here, the Trees and their complex seasonal Color Data consume a lot of memory. The memory usage can be drastically reduced.

## P3_DirtyFlag

Here, the Consoles contain multiple parameters. Each time, one of these parameters changes, another parameter needs to be recomputed, which is heavy and can be avoided in many occasions.

## P4_SpatialPartitioning

This one is difficult to solve. We have a big game world and want to find the car that's closest to the player. The solution is Spatial Partitioning. You can try implementing your own Data Structure or find one on the web to use.
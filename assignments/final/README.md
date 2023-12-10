Gretchen Callahan
11/29/23
Game Programming: Design document

Gameplay description:
In my final game I’m looking to create a game similar to Crossy Roads but with my own spin on the concept. The core mechanics of the game will be crossing busy “streets” and avoiding “cars” by moving along the x and z axis’s. (The character won’t be able to rotate, similar to Crossy Roads.) The main challenge in this game will be to collect objects found within your path, and a secondary goal is to get the high score. The game will end if you are struck by any of the objects you are supposed to avoid. Once the game ends you will be prompted to restart the game.

Inputs:
The inputs for this will be from keys on the keyboard. They can use the horizontal and vertical axis’s (ASWD or arrow keys) to move their character around, or use space to jump. The user will use these to get around the scene and complete objectives.

Visual style:
I want the visuals to be “cute”. The background of the game will be more abstract. For example the sky in the distance, won’t have a lot of lines or jarring colors so that not too much attention is drawn to it. The objects that the character will avoid and will collect are going to be more visually stimulating so that they’re more noticeable. The models and scene design I want to use will focus on cats and cat related things.

Audio style:
I plan on having a backtrack that plays on a loop, probably something soothing and not annoying. In addition to the song in the background I’m hoping to implement noises for certain actions or events. Like if the character jumps it can make a sort of grunt noise, or if it gets injured it can demonstrate that with a sound.

Story/theme:
The story of this game will be about a cat(your character) who has lost its friends. As you move and progress through the game you’ll find cat friends and be able to add them to your posse. Your overall goal will be to collect as many cat friends as you can, with a secondary goal of getting the high score—like in Crossy Roads.

Sketches: ![finalProjSketches](https://github.com/gretchencallahan/csc470-fall2023/assets/98057945/ed0a55e3-4643-41e2-a0bd-27f117c5ee9b)

 
Low-bar:
My low-bar will be to get the main aspects of the game working and playable. You will be able to move your character and avoid projectile objects. There will be a finite amount of “streets” to cross, and when you get to the end of them you win. When the game ends(if you die or if you win) you are sent to an endgame screen.

Target:
The target that I expect to hit is to get the main aspects of the game working and imbed the storyline. At the target level of the game you will be tasked with finding cat friends as well as making it as far as you can before you reach the end. And when the game ends you will be prompted with a screen asking if you would like to play again.

High-bar:
My desired high-bar takes everything from the target and adds to it by making the “streets” generate as you character progresses through the game. This way when you play there is no official end, and your score keeps increasing as your play. This is when you can reach high scores, which will be stored and shown to the user. 

Timeline:
1.	Build scene set up, import models. Get character moving with keys, and have random projectiles moving across the screen, in their roads, at random intervals. 
2.	Create title screen and end screen.
3.	Cause the game to end when the character collides with the projectiles and prompt the end screen to show up.
4.	Add the objects that the user is supposed to collect. Demonstrate that they are collected.
5.	Make it possible to start the game over once the game has ended.
6.	Make the roads generate as you progress through the game, making the only way to end the game be hit by projectiles
7.	Keep track of the user’s high score and display it on the screen


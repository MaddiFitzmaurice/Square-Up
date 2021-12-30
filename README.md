CS50'S INTRODUCTION TO GAME DEVELOPMENT FINAL PROJECT
SQUARE UP BY MADALEINE FITZMAURICE 2021

README

  Before completing CS50's Introduction to Computer Science, I was tasked with creating a game from scratch using LOVE2D.
  Knowing how scope can quickly spiral out of control, I instead envisioned part of a game - a final boss battle
  prototype that was complex enough to submit for an introductory course. I was pleased with it, but I didn't have the 
  knowledge or tools to adequately bring my vision to life. While taking this course, I thought I would give it another
  shot. This is Square Up 2.0.

  The concept of Square Up is still a final boss battle... but with more complexity. This complexity comes in the form of
  different mechanics for the player during different stages of the boss fight. The player comes in to battle only to find
  that the boss has control of the gravity in the ship. In zero gravity, the player must evade the boss's sequence of
  varied attacks. Outlasting this, gravity is restored, and the player must navigate around the frame of the ship.
  Barriers that will trap them are to be avoided, and a volley of the player's own attack must happen in order to lower
  the boss's shields. If the shields are lowered, a rare opportunity for the player to launch a big attack occurs. These
  stages repeat until either the player or boss is defeated.

  I set out to future-proof Square Up, making it easily scalable and designer friendly so I could one day come back to
  this game and potentially expand upon it. In order to enact this, I needed to utilise from the course the concept of
  the finite state machine. The Unity game engine was selected because of its user-friendly interface, easily accessible
  assets, and its popularity. However, one challenge encountered was MonoBehaviour's component system. As it is the
  default class that every script derives from, it must always be attached to a GameObject. However, the inspector quickly
  became messy, especially having to attach a State Machine script and a Base Class script to every GameObject. Scriptable
  Objects were no better of a solution, as I found it to be more of a data container for an object rather than something
  applicable to state machines. Therefore, I used my own form of inheritance and excluded MonoBehaviour as the parent
  class. With this technique, I created a hierarchy system of state machines to decouple mechanics, organise an efficient
  flow of code, and make it easily scalable. 

  I started with a GameManager Object at the top of the hierarchy, which had complete control over each state of the game.
  The states were created to mimic stages of a boss battle: StartState, EvadeState, SpongeState, AttackState, and EndState.
  The GameManager script itself was designed as a singleton pattern for easy access where necessary. Next, core
  GameObjects of deep complexity were selected to be influenced directly by the GameManager's current state. These core
  GameObjects were Player, Boss, GameUI, and EnvironmentManager, and each were given their own different states to
  organise and control the flow of code, and to easily add more features to them where necessary. Core GameObjects could
  not directly change the state of the entire game or change other core GameObjects' states directly; they could only
  signal to the GameManager's current state that a state change was necessary. For example, if the Player's health reduced
  to 0, the current state of the Game Manager would constantly check for this in its own Logic Update function and
  promptly change the state of the game to EndState. This created a succinct chain of command, where if the Game Manager's 
  state changed, the new state's entry function would, in one fell swoop, change every other core GameObject's state
  cleanly. 

  By discarding MonoBehaviour in favour of inheritance, another problem arose: these states created for GameObjects, such
  as the Player and the Boss, had no access to important Unity-specific functions such as OnTriggerEnter(). These vital
  functions were necessary for systems such as hit detection, which makes the concept of the game possible. Most
  importantly, however, I needed a way to chain functions together - similar to Tweening and Timers from the course.
  Chaining functions together allowed for sequences such as different Boss attacks, Player's big launch attack, and
  rising and falling platforms. MonoBehaviour offers a solution for chaining functions together in the form of
  IEnumerators and Coroutines, but again, I couldn't access these because of my inheritance structure. I therefore had to
  create a 'core' script that was the DNA of a GameObject. For example, I had a Player script for the Player GameObject,
  and this composed of instantiating its state machine and states, as well as had references to MonoBehaviour-driven
  component scripts such as PlayerAttack and PlayerMovement. By instantiating states and creating references to component
  scripts, I was able to pass the 'core' Player script into its states, where these states could therefore indirectly
  access vital MonoBehaviour functions by calling the 'core' script. In doing this, more scalability, organisation, and
  succinct flow of code was enabled. Creating these 'component scripts' also allowed for a designer-friendly interface in
  the inspector. Data component scripts were made in 'core' GameObject scripts that could influence gameplay and game
  states without designers touching any code in an editor.

  It was such a pleasure undertaking this amazing course! Regardless of whether I pass or fail, this course has given me
  valuable insights into the world of game development and has fuelled my passion for getting into the industry.
  
  Thank you to everyone involved in this course! :)     	



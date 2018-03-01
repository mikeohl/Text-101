// Copyright 2017 Michael J. Ohl
/* TextController manages state in a state-machine controlled
 * simple text adventure game. Story text is written in file.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    // Unity UI Text element
	public Text text;
	
    // Possible states in text display state-machine
	private enum States {
		cell_0, cell_1, cell_helmet, helmet, pirate_0, pirate_1, lock_0, lock_1, 
		corridor_0, corridor_1, corridor_2, corridor_3, corridor_4, launch_bay,
		floor, stairs_0, stairs_1, stairs_2, guard_post_0, guard_post_1
		};

    // Player state
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell_0;
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log(myState);
        switch (myState)
        {
            case States.cell_0:         { cell_0();         break; }
            case States.cell_1:         { cell_1();         break; }
            case States.pirate_0:       { pirate_0();       break; }
            case States.pirate_1:       { pirate_1();       break; }
            case States.lock_0:         { lock_0();         break; }
            case States.lock_1:         { lock_1();         break; }
            case States.helmet:         { helmet();         break; }
            case States.cell_helmet:    { cell_helmet();    break; }
            case States.corridor_0:     { corridor_0();     break; }
            case States.stairs_0:       { stairs_0();       break; }
            case States.floor:          { floor();          break; }
            case States.guard_post_0:   { guard_post_0();   break; }
            case States.corridor_1:     { corridor_1();     break; }
            case States.stairs_1:       { stairs_1();       break; }
            case States.guard_post_1:   { guard_post_1();   break; }
            case States.corridor_2:     { corridor_2();     break; }
            case States.stairs_2:       { stairs_2();       break; }
            case States.corridor_3:     { corridor_3();     break; }
            case States.corridor_4:     { corridor_4();     break; }
            case States.launch_bay:     { launch_bay();     break; }
        }
	}
	
    // Story text for each state
	#region State handler methods
	void cell_0 () {
		text.text = "Your eyes flicker open and you find yourself face down on the " +
					"floor of your cell. You can hear the sounds of explosions as " +
					"the walls and floor shake around you. The emergency alarm is " +
					"almost deafening. As you get to your feet and look around, you " +
					"see pieces of the damaged ship littering the corridor. Burst " +
					"pipes hiss above you, releasing a hot steam. Your cell mate " +
					"lies dead against the cell wall, a pipe impaled through his " +
					"chest.\n\nThis wasn't where you were supposed to be, but justice " +
					"didn't mean the same thing in space as it did on Earth. Your " +
					"trial had been a sham and you were court martialed and sentenced " +
					"to live out the rest of your life aboard this foresaken prison " +
					"freighter. Fate, however, had different plans.\n\n" +
					"Press C to Continue.";
		if 		(Input.GetKeyDown(KeyCode.C)) 	{myState = States.cell_1;}	
	}
	
	void cell_1 () {
		text.text = "There must be some way out of this cell, if only you could find " +
					"a way to unlock the cell door. You glance around your cell once " +
					"more and see a dead pirate leaning against the cell bars. Beside " +
					"him is a keypad lock that controls the cell door. A helmet " +
					"belonging to the pirate lies on the floor next to the body of " +
					"your cell mate.\n\n" +
					"Press P to inspect the Pirate, L to inspect the Lock, and H to inspect the Helmet";
		if 		(Input.GetKeyDown(KeyCode.P)) 	{myState = States.pirate_0;}		
		else if (Input.GetKeyDown(KeyCode.H)) 	{myState = States.helmet;}
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.lock_0;}
	}
	
	void helmet () {
		text.text = "This helmet must have been dislodged from the pirate and rolled " +
					"past the cell bars. It has a large fracture on the left side " +
					"and is crushed beyond use, but the reflective visor is still " +
					"intact.\n\n" +
					"Press T to Take the helmet, or R to Return to looking around your cell.";
		if 		(Input.GetKeyDown(KeyCode.T)) 	{myState = States.cell_helmet;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_1;}
	}
	
	void cell_helmet () {
		text.text = "With the helmet in your hands, you see yourself reflected in the " +
					"visor. You've certainly looked better. You notice that the cell " +
					"is also reflected in the visor behind you and you get an idea...\n\n" +
					"Press P to view the Pirate, or L to view the Lock";
		if 		(Input.GetKeyDown(KeyCode.P)) 	{myState = States.pirate_1;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_1;}
	}
	
	void pirate_0 () {
		text.text = "This pirate clearly took one too many plasma shots to the chest from " +
					"a guard's rifle. Space pirates attacking a prison ship could only " +
					"mean one of two things. These pirates were looking for new recruits or " +
					"for fresh slaves to sell. Either way, you're glad this one met his end.\n\n" +
					"Press R to Return to looking around your cell.";
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell_1;}
	}
	
	void pirate_1 () {
		text.text = "You cringe at the sight of charred flesh from plasma burns on the " +
					"pirate's chest being reflected through the visor. The helmet once " +
					"belong to this pirate. He won't be needing it anymore...\n\n" +
					"Press R to Return to looking around your cell.";
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell_helmet;}
	}
	
	void lock_0 () {
		text.text = "The keypad to unlock the cell requires a four digit combination, but " +
					"unfortunately, you don't know the code. Randomly guessing would be " +
					"futile.\n\n" +
					"Press R to Return to looking around your cell.";
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell_1;}
	}
	
	void lock_1 () {
		text.text = "You place the helmet through the bars, and turn the visor to face " +
					"the keypad. The pirate's blood has dried on the keys, revealing " +
					"fingerprints on the numbers 1, 2, 6, and 7. The code must be a " +
					"combination of those numbers.\n\n" + 
					"Press O to Open the cell door, or R to Return to looking " +
					"around your cell.";
		if 		(Input.GetKeyDown(KeyCode.O)) 	{myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_helmet;}
	}
	
	void corridor_0 () {
		text.text = "You begin to try each possible combination. Finally, you press " +
					"the combination 2 1 6 7 and you hear the buzz of the cell lock " +
					"and the sound of the latch disengaging. You pull open the cell " +
					"door and glance around the corridor. If you're going to escape, " +
					"you'll have to make it to the shuttle launch bay. You see a staircase " +
					"at the end of the corridor to your right and a guard post to " +
					"your left. The floor is covered with debris from the attack.\n\n" +
					"Press S to climb the Stairs, F to inspect the Floor, or G to check the Guard Post"; 
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_0;}
		else if (Input.GetKeyDown(KeyCode.F)) 	{myState = States.floor;}
		else if (Input.GetKeyDown(KeyCode.C)) 	{myState = States.guard_post_0;}
	}
	
	void corridor_1 () {
		text.text = "If you're going to escape, you'll have to make it to the launch " +
					"bay. You see a staircase at the end of the corridor to your right, " +
					"and a guard post to your left. The floor is covered with debris " +
					"from the attack.\n\n" +
					"Press S to climb the Stairs, F to inspect the Floor, or G to check the Guard Post"; 
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_0;}
		else if (Input.GetKeyDown(KeyCode.F)) 	{myState = States.floor;}
		else if (Input.GetKeyDown(KeyCode.G)) 	{myState = States.guard_post_0;}
	}
	
	void stairs_0 () {
		text.text = "As you head up the stairs, you see a sign pointing you to the " +
					"nearest shuttle launch bay. As you approach the launch bay doors, " +
					"you hear the sounds of blaster fire! The prison guards and pirate " +
					"invaders are engaged in a deadly battle just beyond the doors. " +
					"Opening the doors without any armor or weapons would mean certain " +
					"death! \n\n" + 
					"Press R to Return to the corridor.";
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_1;}	
	}
	
	void floor () {
		text.text = "As you search through the debris, you notice a guard buried beneath " +
					"some rubble. After searching his body, you find a key card to the " +
					"guard post on him.\n\n" + 
					"Press R to Return to the corridor, or T to Take the key card from his cold, lifeless body.";
		if 		(Input.GetKeyDown(KeyCode.T))	{myState = States.corridor_2;}
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_1;}	
	}
	
	void guard_post_0 () {
		text.text = "You reach out and pull the handle to the guard post door. It's " +
					"locked. You notice a key card slot next to the door that can open " +
					"the door, but you don't have the key card.\n\n" + 
					"Press R to Return to the corridor.";
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_1;}	
	}
	
	void corridor_2 () {
		text.text = "You grasp the key card to the guard post in your hand. You know the " +
					"only way off this foresaken prison freighter is on one of the shuttles " +
					"in the launch bay. Looking around the the corridor, you see the " +
					"staircase at one end and the guard post at the other.\n\n" +
					"Press S to climb the Stairs, or G to check the Guard Post"; 
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_1;}
		else if (Input.GetKeyDown(KeyCode.G)) 	{myState = States.guard_post_1;}
	}		
	
	void stairs_1 () { 
		text.text = "You climb the stairs to the launch bay and a plasma blast blows " +
					"a hole in the launch bay doors!!! The battle between the prison " +
					"guards and pirates has escalated and is moving in your direction! " +
					"Soon you will be caught in the cross-fire with no way to defend " +
					"yourself!\n\n" + 
					"Press R to Return to the corridor. ";
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_3;}	
	}
	
	void guard_post_1() {
		text.text = "You swipe the key card at the guard post. As you enter, you smell " +
					"the charred flesh of guards, massacred by the detonation of a " +
					"pirate's plasma grenade. In the corner, you see the guard lockers. " +
					"Plasma rifles and armor lay on the floor in front of them, knocked " +
					"from their locker in the blast.\n\n" + 
					"Press R to Return to the corridor, or E to Equip the armor and rifle.";
		if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_3;}
		else if (Input.GetKeyDown(KeyCode.E))	{myState = States.corridor_4;}	
	}
	
	void corridor_3 () {
		text.text = "You grasp the key card to the guard post in your hand. You know the " +
					"only way off this foresaken prison freighter is on one of the shuttles " +
					"in the launch bay. Looking around the the corridor, you see the " +
					"staircase at one end and the guard post at the other.\n\n" +
					"Press S to climb the Stairs, or G to check the Guard Post"; 
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_2;}
		else if (Input.GetKeyDown(KeyCode.G)) 	{myState = States.guard_post_1;}
	}		
	
	void stairs_2 () {
		text.text = "As you climb up the stairs and reach the launch bay, the sounds of " +
					"blaster fire grow more intense. Plamsa blasts shoot through the " +
					"hole in the launch bay doors, nearly striking you! You will not " +
					"survive a dash to the launch bay shuttles unprotected and unarmed, " +
					"and the fight is moving closer in your direction. Time is running out!\n\n" +
					"Press R to return to the corridor... ";
		if (Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_3;}	
	}
	
	void corridor_4 () {
		text.text = "With the armor equiped and your rifle loaded, you know this is your " +
					"only chance to escape. You exit the guard post, glance up the stairs " +
					"toward the launch bay, and take a deep breath. It's now or never!\n\n" + 
					"Press U to Unequip the armor and rifle, or F to Finish the Fight and continue to the Launch Bay. ";
		if 		(Input.GetKeyDown(KeyCode.U))	{myState = States.guard_post_1;}
		else if (Input.GetKeyDown(KeyCode.F))	{myState = States.launch_bay;}	
	}		
	
	void launch_bay () {
		text.text = "You sprint up the stairs and dive through the hole in the launch bay " +
					"doors! Rolling to your knees, you spray plamsa fire in the direction of " +
					"the pirates. As the pirates return fire, you duck behind a crate. " +
					"Glancing toward the shuttles, you realize that there is only one " +
					"guard left. He motions for you to make a break for the last " +
					"remaining shuttle. You nod and begin to sprint. As the guard sprints " +
					"next to you, he is struck by plasma fire and stumbles into you. You " +
					"hold him up as a human shield, his armor and body being torn apart " +
					"by plasma blasts as you return fire. Finally, as you reach the shuttle " +
					"doors, you toss the lifeless, plasma shredded body aside and slam the " +
					"doors closed. As fast as you can, you ignite the engines and throw " +
					"the throttle forward. The shuttle jerks and blasts out of the launch " +
					"bay, plasma fire from the pirates ricocheting off the deflectors. " +
					"You've done it! You glance around the cockpit and wonder what's next!?!\n\n" + 
					"Press P to Play again... ";
		if (Input.GetKeyDown(KeyCode.P))	{myState = States.cell_0;}	
	}
	#endregion
}

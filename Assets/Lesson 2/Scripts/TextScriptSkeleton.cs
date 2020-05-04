using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Animations;

public class TextScript : MonoBehaviour
{
	//.txt file with your story
	
	//the GameObjects in your scene/prefabs
	//text,image e.g.
	public Text displayText;
	//button
	
	private StoryCompiler storyCompiler = new StoryCompiler(); //custom created StoryCompiler class
	
	//StoryCompiler class should break down the raw text from the txt file
	//it should also keep track of the flow of the story
	
	private bool awaitingChoice = false;//when true, user shouldnt be allowed to progress story

    // Start is called before the first frame update
    void Start()
    {
		//make storyCompiler compile story
    }
	
    // Update is called once per frame
    void Update() {
		//if user presses space, storyCompiler should progress the story
		
		//change the text, check for any image that matches the title, create buttons for any choices the player has
		//use displayImage.color = Color.clear; if theres no image
		
		//if getButtonTitles() returns something create buttons
        
		//check if game has ended?
    }
	
	void createChoiceButtons(List<string> buttonTitles) {
		//function to create the buttons for the choices
		for (int i = 0; i<buttonTitles.Count-1; i++) {
			string buttonTitle = buttonTitles[i];
			//create the button, name it 'choice'
			//set the text in the button
			
			//adjusts the buttons y-position based on the number of buttons created so far (hint: use recttransform)
			//Vector2 buttonPosition = choice.GetComponent<RectTransform>().anchoredPosition
			//this might be useful - but read abt what anchoredPosition is!
			
			//adding listener to button, ie when button is clicked, call the function ChoiceOnClick with the input temp
			string temp = storyCompiler.getAfterFromText(buttonTitle);
			choice.onClick.AddListener(delegate {ChoiceOnClick(temp);});
		}
	}
	
	void ChoiceOnClick(string titleToSearchFor) {//when button is clicked, destroy all buttons, progress story based on choice
		//find all buttons
		//destroy them
		awaitingChoice = false;//where should awaiting choice be made true?
		storyCompiler.clearButtonTitles();
		displayText.text = storyCompiler.ProgressStory(titleToSearchFor);
	}
}



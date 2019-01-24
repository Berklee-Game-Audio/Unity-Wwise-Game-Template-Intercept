using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioClipDatabase : MonoSingleton<AudioClipDatabase> {
	public List<AudioClip> keySounds;
	public AudioClip attachingPaperSound;
	public AudioClip horrorSting;

	//private List<FMOD.Studio.EventInstance> myFmodEvents;
	//private List<string> myFmodEventNames;

	private void Awake (){
		//arrayOfInts = new List<int>();
		//myFmodEvents = new List<FMOD.Studio.EventInstance>();
		//myFmodEventNames = new List<string>();
	}


	public void PlayKeySound () {
		//PlaySound(keySounds[Random.Range(0, keySounds.Count)]);
		AkSoundEngine.PostEvent ("sfx_typing", GameObject.Find("WwiseGlobal"));
		//FMOD.Studio.EventInstance sfxEvent;
		//sfxEvent = FMODUnity.RuntimeManager.CreateInstance("event:/sfx_typing"); 
		//sfxEvent.start ();
	}

	public void PlayAttachingPaperSound () {
		//PlaySound(attachingPaperSound);
		AkSoundEngine.PostEvent ("sfx_paper", GameObject.Find("WwiseGlobal"));
		//FMOD.Studio.EventInstance sfxEvent;
		//sfxEvent = FMODUnity.RuntimeManager.CreateInstance("event:/sfx_paper"); 
		//sfxEvent.start ();
	}

	public void PlayHorrorSting () {
		//PlaySound(horrorSting);
		AkSoundEngine.PostEvent ("mx_horror_stinger", GameObject.Find("WwiseGlobal"));
		//FMOD.Studio.EventInstance sfxEvent;
		//sfxEvent = FMODUnity.RuntimeManager.CreateInstance("event:/sfx_horrorSting"); 
		//sfxEvent.start ();
	}

	private void PlaySound (AudioClip audioClip, float volume = 1) {
		GameObject tempGO = new GameObject("Audio: "+audioClip.name); // create the temp object
		tempGO.transform.SetParent(transform);
		AudioSource audioSource = tempGO.AddComponent<AudioSource>(); // add an audio source
		audioSource.clip = audioClip; // define the clip
		audioSource.spatialBlend = 0;
		audioSource.Play(); // start the sound
		Destroy(tempGO, audioClip.length); // destroy object after clip duration
	}

	public void AnalyzeAudioTag (string theTag){
		Debug.Log ("AnalyzeAudioTag: " + theTag);

		string[] splitArray = theTag.Split(' ');

		Debug.Log ("the number of splits is: " + splitArray.Length);
		Debug.Log (splitArray [0]);
		Debug.Log (splitArray [1]);
		//Debug.Log (splitArray [2]);
		//Debug.Log (splitArray [3]);

		if (splitArray [1] == "wwiseEvent" && splitArray.Length >= 3) {
			//FmodInkEvent(splitArray [2], splitArray [3]);
			Debug.Log ("wwiseEvent recognized: " + splitArray [2]);
			AkSoundEngine.PostEvent (splitArray [2], GameObject.Find("WwiseGlobal"));
		}


		if (splitArray [1] == "fmodValue" && splitArray.Length > 4) {
			//FmodInkValue (splitArray [2], splitArray [3], splitArray [4]);
			Debug.Log ("fmodValue recognized: " + splitArray [1]);
		}
			
	}

	private void FmodInkEvent(string whichEvent, string startStop){
		if (startStop == "start") {

			//FMOD.Studio.EventInstance fmodEvent;
			//fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/" + whichEvent); 
			//fmodEvent.start ();

			Debug.Log ("FmodInkEvent: " + whichEvent + " " + startStop);

			//Debug.Log ("The fmodEvent is: " + fmodEvent);

			//this.myFmodEvents.Add (fmodEvent);

			//this.myFmodEventNames.Add (whichEvent);

		}

		if (startStop == "stop") {
			//look through the current things that have started
			//for(int i = 0; i < myFmodEvents.Count; i++) {
				//Debug.Log("Creating enemy number: " + i);
			//	if (myFmodEventNames [i] == whichEvent) {
			//		myFmodEvents[i].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			//	}

			//}

		}

	}

	private void FmodInkValue(string whichEvent, string whichParameter, string theValue){

		//for(int i = 0; i < myFmodEvents.Count; i++) {
			//Debug.Log("Creating enemy number: " + i);
			//if (myFmodEventNames [i] == whichEvent) {
				//myFmodEvents[i].stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			//	FMOD.Studio.ParameterInstance myFmodParameter; 
			//	myFmodEvents[i].getParameter(whichParameter, out myFmodParameter);
			//	myFmodParameter.setValue(float.Parse(theValue, System.Globalization.CultureInfo.InvariantCulture.NumberFormat));
			//}

		//}
			

	}
		
}

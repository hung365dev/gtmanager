using UnityEngine;
using System.Collections;
using Utils;

public class MusicManager : MonoBehaviour {

	public AudioSource musicTrack;
	public AudioSource buttonPlayer;
	public float stepSize = 0.002f;
	public static MusicManager REF;
	void Start () {
		REF = this;
		musicTrack = this.GetComponent<AudioSource>();
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnLevelWasLoaded(int aLevelLoaded) {
		if(Application.loadedLevelName=="Garage"||Application.loadedLevelName=="MainMenu"||Application.loadedLevelName=="SplashScreen") {
			fadeInMusic();
		} else {
			fadeOutMusic();
		}
	}
	public void playSound(string aSound) {
		if(SaveGameUtils.SOUNDS_ON) {
			AudioClip clip = (AudioClip) Resources.Load ("Sounds/"+aSound);
			if(clip!=null) {
				this.buttonPlayer.volume = 0.5f;
				this.buttonPlayer.PlayOneShot(clip);
			}
		}
	}
	public void fadeInMusic() {
		if(SaveGameUtils.MUSIC_ON) {
			this.StopAllCoroutines();
			StartCoroutine(fadeIn());
		} else {
			fadeOutMusic();
		}
	}
	
	public void fadeOutMusic() {
		this.StopAllCoroutines();
		StartCoroutine(fadeOut());
	}
	private IEnumerator fadeOut() {
		if(musicTrack!=null) {
			if(musicTrack.isPlaying) {
				while(musicTrack.volume>0f) {
					musicTrack.volume -= this.stepSize;
					yield return new WaitForEndOfFrame();
				}
				if(musicTrack.volume==0f) {
					musicTrack.Stop();
				}
			}
		}
	}
	private IEnumerator fadeIn() {
		if(musicTrack!=null) {
			if(!musicTrack.isPlaying)
				musicTrack.Play();
			while(musicTrack.volume<1f) {
				musicTrack.volume += this.stepSize;
				yield return new WaitForEndOfFrame();
			}
		
		}
	}
	
}

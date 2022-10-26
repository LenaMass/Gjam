using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
	
   public AudioSource audioSource;

   public AudioClip steps , solvepuzzle, opendoor, press , press2 ,Shelfmovm,stoneDoor;


    private void Start()
	{
      audioSource = GetComponent<AudioSource>();
	}
    
	public void PlayPlayerStep()
	{
    audioSource.PlayOneShot(steps);
	}
	
    public void PlaySolvePuzzle()
	{
    audioSource.PlayOneShot(solvepuzzle);
	}
    public void PlayOpenDoor()
	{
    audioSource.PlayOneShot(opendoor);
	}
	public void PlayPreeskey1()
	{
		audioSource.PlayOneShot(press);
	}

	public void PlayPreeskey2()
	{
		audioSource.PlayOneShot(press2);
	}
	public void PlayShelfmovement()
	{
		audioSource.PlayOneShot(Shelfmovm);
	}
	public void PlayOpenStoneDoor()
	{
    audioSource.PlayOneShot(stoneDoor);
	}
}
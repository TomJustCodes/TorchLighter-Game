using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action : MonoBehaviour
{
    public GameManger GameManger;

    public GameObject Door;
    public Animator pressed;
    public AudioSource click;

    [SerializeField]
    private TMPro.TMP_Text Interact;

    [SerializeField]
    private Transform SpawnPoint;

    public bool NearButton;
    
    //get components
    void Start()
    {
        click = GetComponent<AudioSource>();
        pressed = GetComponent<Animator>();
        Interact.enabled = false;//sets pop up off
        SpawnPoint = transform.Find("SpawnPoint");

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && NearButton == true)//input and checks if near button
        {
            Debug.Log("f");
            GameManger.lastpoint = SpawnPoint;
            Door.SetActive(false);

            pressed.SetBool("Clicked", true);
            click.Play();
            
        }
        else
        {
            //turn animations off
            pressed.SetBool("Clicked", false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("interact");
        if (other.gameObject.tag == "Player")
        {
            Interact.enabled = true;//pop up appears if player is near
            NearButton = true;//allows for action to play
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Interact.enabled = false;
            NearButton = false;
        }
    }
}

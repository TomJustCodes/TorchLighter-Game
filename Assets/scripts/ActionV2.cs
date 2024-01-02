using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionV2 : MonoBehaviour
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
    public bool Press = false;
    public bool firstPressOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<AudioSource>();
        pressed = GetComponent<Animator>();
        Interact.enabled = false;
        SpawnPoint = transform.Find("SpawnPoint");

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && NearButton == true)
        {
            Debug.Log("f");
            GameManger.lastpoint = SpawnPoint;
            Door.SetActive(false);
            Press = true;
            pressed.SetBool("Clicked", true);
            click.Play();
        }
        else
        {
            pressed.SetBool("Clicked", false);
        }
        //vairation for updating game manger count
        if (Press == true && firstPressOnce == false)
        {
            GameManger.KeyButtonCounter += 1;
            firstPressOnce = true;//makes sure the count is only updated once as the button can be pressed multiple times
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("interact");
        if (other.gameObject.tag == "Player")
        {
            Interact.enabled = true;
            NearButton = true;
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

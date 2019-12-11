using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Handles display of dialogue from crew memebers
 */
public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Text Objects")]
    public Text playerTextObj;
    public Text weaponTextObj;
    public Text magazineTextObj;
    public Text galleyTextObj;
    public Text storageTextObj;
    public Text engineTextObj;

    private string[] encouragingMsg = {"Keep up the good work captain!", "Thanks for all you do!", "We know you'll bring us through", "Together we've got this covered!" };
    private string[] discouragedMsg = {"That could have gone better...", "What are we going to do now?", "Welp, back to work"};

    Queue<Message> messageQueue;

    public int displayTimeSec; // Duration in seconds that a messages should be displayed
    private float timer;
    private int seconds; // time elapsed in seconds

    private bool messageDisplayed;
    private Text lastText; // last text object with a message displayed

    // Struct - contains a message and the text object where it should be displayed
    struct Message
    {
        public Text room;
        public string message;

        public Message(Text rm, string msg)
        {
            room = rm;
            message = msg;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        messageQueue = new Queue<Message>();
        messageDisplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (messageDisplayed)
        {
            // Run the timer
            timer += Time.deltaTime;
            seconds = (int)timer % 60;
        }
        else if(messageDisplayed == false && messageQueue.Count > 0) // No message showing and messages are waiting
        {
            timer = 0;
            seconds = 0;

            // Get the next available message
            Message currentMsg = messageQueue.Dequeue();

            lastText = currentMsg.room;
            // Display the message
            currentMsg.room.text = currentMsg.message;

            messageDisplayed = true;
        }

        // After 15 seconds remove the message
        if(seconds >= displayTimeSec)
        {
            lastText = null;
            messageDisplayed = false;
        }
    }

    // Displays a random message to encourage the player
    public void EncouragingMessage(string room)
    {
        // Create message
        Message newMsg = new Message(SelectRoom(room), encouragingMsg[Random.Range(0, encouragingMsg.Length)]);
        // Add to queue
        messageQueue.Enqueue(newMsg);
    }

    // Displays a random message expressing discouragement
    public void DiscouragedMessage(string room)
    {
        // Create message
        Message newMsg = new Message(SelectRoom(room), discouragedMsg[Random.Range(0, discouragedMsg.Length)]);
        // Add to queue
        messageQueue.Enqueue(newMsg);
    }

    // Displays a custom message at 
    public void CustomMessage(string room, string message)
    {
        // Create message
        Message newMsg = new Message(SelectRoom(room), message);
        // Add to queue
        messageQueue.Enqueue(newMsg);
    }

    // Helper Method: Picks the appropriate text object based upon the given string
    private Text SelectRoom(string rm)
    {
        switch (rm)
        {
            case "Galley":
                return galleyTextObj;
            case "WeaponStation":
                return weaponTextObj;
            case "Storage":
                return storageTextObj;
            case "EngineRoom":
                return engineTextObj;
            case "Magazine":
                return magazineTextObj;
            default:
                return null;
        }
    }
}

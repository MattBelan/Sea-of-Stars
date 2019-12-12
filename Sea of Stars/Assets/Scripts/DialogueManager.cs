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

    private string[] encouragingMsg = {
        "Keep up the good work captain!",
        "Thanks for all you do!",
        "We know you'll bring us through.",
        "Together we've got this covered!",
        "We couldn't do this wihtout you!",
        "Great work!" };
    private string[] discouragedMsg = {
        "That could have gone better...",
        "What are we going to do now?",
        "Welp, back to work",
        "Setbacks are only temporary",
        "Let's find a way to fix this",
        "This is terrible!",
        "Don't worry, we'll get through this",
        "We just have to keep our heads up and press on",
        "This too shall pass."};

    private List<Text> roomNames;

    private Queue<Message> messageQueue;

    public int displayTimeSec; // Duration in seconds that a messages should be displayed
    private int delayTimeSec; // duration to wait before allowing a new message to be added to the queue

    private float timer;
    private float delayTimer;

    [Header("Timer Data")]
    [SerializeField]
    private int seconds;
    [SerializeField]
    private int delaySeconds;

    public bool allowMessage;

    [Header("Message Statuses")]
    public bool messageDisplayed;
    public Text lastText; // last text object with a message displayed
    public Text lastCustomText;

    // Struct - contains a message and the text object where it should be displayed
    private struct Message
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

        roomNames = new List<Text>();

        roomNames.Add(weaponTextObj);
        roomNames.Add(magazineTextObj);
        roomNames.Add(galleyTextObj);
        roomNames.Add(storageTextObj);
        roomNames.Add(engineTextObj);

        delayTimeSec = Random.Range(5, 12);
        allowMessage = true;

        lastText = null;
        lastCustomText = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (messageDisplayed)
        {
            // Run the timer
            timer += Time.deltaTime;
            seconds = (int)timer % 60;

            // After X seconds remove the message
            if (seconds >= displayTimeSec)
            {
                if(lastText != null) lastText.text = "";
                if(lastCustomText != null) lastCustomText.text = "";
                lastText = null;
                lastCustomText = null;
                messageDisplayed = false;

                timer = 0;
                seconds = 0;
            }
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

        // Delay timer
        delayTimer += Time.deltaTime;
        delaySeconds = (int)delayTimer % 60;

        // Reset the delay and allow a new message to be queued
        if(delaySeconds >= delayTimeSec)
        {
            allowMessage = true;
            // Set a new delay time
            delayTimeSec = Random.Range(5, 12);

            delayTimer = 0;
            delaySeconds = 0;
        }
    }

    // Displays a random message to encourage the player
    public void EncouragingMessage(string room)
    {
        // Create message
        Message newMsg = new Message(SelectRoom(room), encouragingMsg[Random.Range(0, encouragingMsg.Length)]);
        // Add to queue
        messageQueue.Enqueue(newMsg);

        allowMessage = false;
    }

    // Displays a random message expressing discouragement
    public void DiscouragedMessage(string room)
    {
        // Create message
        Message newMsg = new Message(SelectRoom(room), discouragedMsg[Random.Range(0, discouragedMsg.Length)]);
        // Add to queue
        messageQueue.Enqueue(newMsg);

        allowMessage = false;
    }

    // Displays a custom message at the given room without a delay
    public void CustomMessage(string room, string message)
    {
        lastCustomText = SelectRoom(room);
        lastCustomText.text = message;

        messageDisplayed = true;
    }

    // Helper Method: Picks the appropriate text object based upon the given string
    // Picks a random room if room is not given
    private Text SelectRoom(string rm)
    {
        switch (rm)
        {
            case "Galley":
                return galleyTextObj;
            case "WeaponStations":
                return weaponTextObj;
            case "Storage":
                return storageTextObj;
            case "EngineRoom":
                return engineTextObj;
            case "Magazine":
                return magazineTextObj;
            default:
                return roomNames[Random.Range(0, 4)];
        }
    }
}

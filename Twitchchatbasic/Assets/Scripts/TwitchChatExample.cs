using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

[RequireComponent(typeof(TwitchIRC))]
public class TwitchChatExample : MonoBehaviour
{
    public int maxMessages = 100; //we start deleting UI elements when the count is larger than this var.
    private LinkedList<GameObject> messages =
        new LinkedList<GameObject>();
    private TwitchIRC IRC;

    private GameObject _spawnObject;
    private GameObject _gamemanagerObj;
    private GameManager _gameManager;

    public GameObject spawnObject;

    //when message is recieved from IRC-server or our own message.
    void OnChatMsgRecieved(string msg)
    {
        //parse from buffer.
        int msgIndex = msg.IndexOf("PRIVMSG #");
        string msgString = msg.Substring(msgIndex + IRC.channelName.Length + 11);
        string user = msg.Substring(1, msg.IndexOf('!') - 1);

        //remove old messages for performance reasons.
        if (messages.Count > maxMessages)
        {
            Destroy(messages.First.Value);
            messages.RemoveFirst();
        }

        //add new message.
        UserMessage(user, msgString);
    }
    void UserMessage(string userName, string msgString)
    {
        Debug.Log(userName +  ":" + msgString);
        string msgToLower = msgString.ToLower();

        //An example of catching words 
        //if(msgToLower.Equals("spawn")){
        //    _spawnObject = (GameObject)Instantiate(spawnObject, new Vector3(0, 0, 0), Quaternion.identity);
        //    AgentAI ai = _spawnObject.GetComponent<AgentAI>();
        //    ai.setUser(userName);
        //    _gameManager.AddAgent(userName, ai);
        //}
    }

    // Use this for initialization
    void Start()
    {
        _gamemanagerObj = GameObject.FindGameObjectWithTag("GameManager");
        _gameManager = _gamemanagerObj.GetComponent<GameManager>();

        IRC = this.GetComponent<TwitchIRC>();
        //IRC.SendCommand("CAP REQ :twitch.tv/tags"); //register for additional data such as emote-ids, name color etc.
        IRC.messageRecievedEvent.AddListener(OnChatMsgRecieved);
    }
}
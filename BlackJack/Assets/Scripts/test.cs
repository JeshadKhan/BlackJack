using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class test : MonoBehaviour
{
    public GameObject[] Cards = new GameObject[52];
    public GameObject CardBack;
    public GameObject Split;
    public GameObject Hit, bet, Clear, Stand, Green_chip, Red_chip, Black_chip, btn_double, Rebet;
    public GameObject HitForExtraHandOne;
    public GameObject HitForExtraHandTwo;
    public GameObject StartGame, Option, ExitGame, Panel;
    public GameObject StandForHandOne;
    public GameObject StandForHandTwo;
    public GameObject MainMenu;
    public GameObject AboutMenu;
    public GameObject HowTo;
    public GameObject OptionMenu;
    public GameObject GameCanvas;
    public GameObject NewGame;
    public GameObject NewGameInOptionMenu;
    public GameObject HandOneCursor, HandTwoCursor;
    public GameObject Header;
    public AudioSource[] sounds;
    public AudioSource HitSound;
    public AudioSource ChipSound;
    public AudioSource WinSound;
    public AudioSource LoseSound;
    public Text playerHand;
    public Text enemyHand;
    public Text playerHandOne;
    public Text playerHandTwo;
    public Text Notification;
    public Text NotificationOne;
    public Text NotificationTwo;
    public Text PlayerMoney;
    public Text EnemyMoney;
    public Text TableMoney;
    public Text GameOverNoti;
    public Text SoundStat;

    public static int playerMoney = 800; // this is static and will not change
    public static int enemyMoney = 800; // same 

    public int tableMoney = 0;

    public float xVal = 0.0f;
    public float yVal = 0.0f;
    public float zVal = 0.0f;

    public float xValOne = 0.0f;
    public float yValOne = 0.0f;
    public float zValOne = 0.0f;

    public float xValTwo = 0.0f;
    public float yValTwo = 0.0f;
    public float zValTwo = 0.0f;

    public float xValEnemy = 0.0f;
    public float yValEnemy = 0.0f;
    public float zValEnemy = 0.0f;

    public List<int> CardInGame = new List<int>(); // total cards in one game
    public List<int> CardInHand = new List<int>(); // cards in player hand
    public List<int> CardInEnemyHand = new List<int>(); // cards in enemy hadn

    public List<int> CardInExtraHandOne = new List<int>(); // used in split hand one
    public List<int> CardInExtraHandTwo = new List<int>(); // used in split hand two

    public string[] str = new string[52];

    public int PlayerScore = 0;
    public int EnemyScore = 0;
    public int SplitScoreHandOne = 0;
    public int SplitScoreHandTwo = 0;
    public bool IsBust = false;
    static bool IsRebetPressed = false; // used in rebate and new game as flag
    bool NewGameInOptionMenuPressed = false;
    //public float delayTime;

    public bool PlayerIsBust = false;
    public bool EnemyIsBust = false;
    public bool HandOneIsBust = false;
    public bool HandTwoIsBust = false;

    private AudioSource[] allAudioSources;

    static bool SoundValue = true;

    void Start()
    {
        sounds = GetComponents<AudioSource>();
        HitSound = sounds[0];
        ChipSound = sounds[1];
        WinSound = sounds[2];
        LoseSound = sounds[3];

        if (SoundValue == true)
        {
            SoundStat.text = "Sound OFF";
        }
        else
        {
            SoundStat.text = "Sound ON";
        }

        bet.GetComponent<Button>().interactable = false;
        StartGame.SetActive(false);
        Header.SetActive(true);
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        if (IsRebetPressed == true)
        {
            MainMenu.SetActive(false);
            GameCanvas.SetActive(true);
            IsRebetPressed = false;
        }

        //StartCoroutine("EnemyAI");

        str[0] = "AC";
        str[1] = "AH";
        str[2] = "AS";
        str[3] = "AD";

        str[4] = "2C";
        str[5] = "2H";
        str[6] = "2S";
        str[7] = "2D";

        str[8] = "3C";
        str[9] = "3H";
        str[10] = "3S";
        str[11] = "3D";

        str[12] = "4C";
        str[13] = "4H";
        str[14] = "4S";
        str[15] = "4D";

        str[16] = "5C";
        str[17] = "5H";
        str[18] = "5S";
        str[19] = "5D";

        str[20] = "6C";
        str[21] = "6H";
        str[22] = "6S";
        str[23] = "6D";

        str[24] = "7C";
        str[25] = "7H";
        str[26] = "7S";
        str[27] = "7D";

        str[28] = "8C";
        str[29] = "8H";
        str[30] = "8S";
        str[31] = "8D";

        str[32] = "9C";
        str[33] = "9H";
        str[34] = "9S";
        str[35] = "9D";

        str[36] = "10C";
        str[37] = "10H";
        str[38] = "10S";
        str[39] = "10D";

        str[40] = "JC";
        str[41] = "JH";
        str[42] = "JS";
        str[43] = "JD";

        str[44] = "QC";
        str[45] = "QH";
        str[46] = "QS";
        str[47] = "QD";

        str[48] = "KC";
        str[49] = "KH";
        str[50] = "KS";
        str[51] = "KD";
    }

    void Update()
    {
        PlayerMoney.text = "Player $" + playerMoney.ToString();
        EnemyMoney.text = "Enemy $" + enemyMoney.ToString();
    }

    public void IsNewGameInMenuPressed() 
    {
        NewGameInOptionMenuPressed = true;
    }

    public void StartIsPressed()
    {
        GameCanvas.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void OptionIsPressed()
    {
        MainMenu.SetActive(false);
        GameCanvas.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void BackIsPressed()
    {
        OptionMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void AboutIsPressed() 
    {
        AboutMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    
    public void BackFromAboutIsPressd()
    {
        AboutMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void HowToPlayIsPressd()
    {
        OptionMenu.SetActive(false);
        HowTo.SetActive(true);
    }

    public void BackFromHowToPlayIsPressd()
    {
        OptionMenu.SetActive(true);
        HowTo.SetActive(false);
    }

    public void InGameOptionIsPressed()
    {
        GameCanvas.SetActive(false);
        MainMenu.SetActive(true);
        StartGame.SetActive(true);
        Header.SetActive(false);
    }

    public void ExitIsPressed()
    {
        Application.Quit();
    }

    public void NewGameIsPressed()
    {
        playerMoney = 800;
        enemyMoney = 800;
        Application.LoadLevel("Main");
        IsRebetPressed = true;
    }

    public void Disable_1()
    {
        bet.SetActive(false);
        Clear.SetActive(false);
        Green_chip.SetActive(false);
        Red_chip.SetActive(false);
        Black_chip.SetActive(false);
        Hit.SetActive(true);
        Stand.SetActive(true);
        HandOneCursor.SetActive(true);
    }

    public void tableClear()
    {
        playerMoney = playerMoney + tableMoney;
        enemyMoney = enemyMoney + tableMoney;
        tableMoney = 0;
        bet.GetComponent<Button>().interactable = false;
        TableMoney.text = "$" + tableMoney.ToString();
    }

    public void chip_cont()
    {
        bet.GetComponent<Button>().interactable = true;
    }

    public void redIsPressed()
    {
        ChipSound.Play();
        if ((playerMoney - 50) >= 0 && (enemyMoney - 50) >= 0)
        {
            playerMoney = playerMoney - 50;
            enemyMoney = enemyMoney - 50;
            tableMoney = tableMoney + 50;
            TableMoney.text = "$" + tableMoney.ToString();
        }
        else
        {
            Debug.Log("Not enough Player money");
        }
    }

    public void greenIsPressed()
    {
        ChipSound.Play();
        if ((playerMoney - 10) >= 0 && (enemyMoney - 10) >= 0)
        {
            playerMoney = playerMoney - 10;
            enemyMoney = enemyMoney - 10;
            tableMoney = tableMoney + 10;
            TableMoney.text = "$" + tableMoney.ToString();
        }
        else
        {
            Debug.Log("Not enough Player money");
        }
    }

    public void blackIsPressed()
    {
        ChipSound.Play();
        if ((playerMoney - 100) >= 0 && (enemyMoney - 100) >= 0)
        {
            playerMoney = playerMoney - 100;
            enemyMoney = enemyMoney - 100;
            tableMoney = tableMoney + 100;
            TableMoney.text = "$" + tableMoney.ToString();
        }
        else
        {
            Debug.Log("Not enough Player money");
        }
    }

    public void ScoreCount()
    {
        PlayerScore = 0;
        bool IsThereA = false;
        int IsThereASecure = 0; // this is security for 2nd ACE

        if (CardInHand.Count == 0)
            Debug.Log("Empty hand: " + CardInHand.Count);
        else
        {
            int i = 0;
            while (i < CardInHand.Count)
            {
                string temp = str[CardInHand[i]];

                if (temp[0] == '2') PlayerScore = PlayerScore + 2;
                if (temp[0] == '3') PlayerScore = PlayerScore + 3;
                if (temp[0] == '4') PlayerScore = PlayerScore + 4;
                if (temp[0] == '5') PlayerScore = PlayerScore + 5;
                if (temp[0] == '6') PlayerScore = PlayerScore + 6;
                if (temp[0] == '7') PlayerScore = PlayerScore + 7;
                if (temp[0] == '8') PlayerScore = PlayerScore + 8;
                if (temp[0] == '9') PlayerScore = PlayerScore + 9;

                if (temp[0] == '1' || temp[0] == 'K' || temp[0] == 'Q' || temp[0] == 'J') PlayerScore = PlayerScore + 10;

                if (temp[0] == 'A')
                {
                    IsThereASecure++;
                    if (IsThereA == false)
                    {
                        if (PlayerScore > 10) PlayerScore = PlayerScore + 1;
                        else
                        {
                            PlayerScore = PlayerScore + 11;
                            IsThereA = true;
                        }
                    }
                    else
                    {
                        PlayerScore = PlayerScore + 1;
                        IsThereA = true;
                    }
                    //IsThereA = true;
                }

                if (IsThereA == true && PlayerScore > 21 && IsThereASecure == 1)
                {
                    PlayerScore -= 10;
                    IsThereA = false;
                }
                i++;
            }
            Debug.Log("My hand: " + PlayerScore);
            playerHand.text = PlayerScore.ToString();
        }
    }

    public void ScoreCountExtraHandOne()
    {
        SplitScoreHandOne = 0;
        bool IsThereA = false;
        int IsThereASecure = 0; // this is security for 2nd ACE

        if (CardInExtraHandOne.Count == 0)
            Debug.Log("Empty hand: " + CardInExtraHandOne.Count);
        else
        {
            int i = 0;
            while (i < CardInExtraHandOne.Count)
            {
                string temp = str[CardInExtraHandOne[i]];

                if (temp[0] == '2') SplitScoreHandOne = SplitScoreHandOne + 2;
                if (temp[0] == '3') SplitScoreHandOne = SplitScoreHandOne + 3;
                if (temp[0] == '4') SplitScoreHandOne = SplitScoreHandOne + 4;
                if (temp[0] == '5') SplitScoreHandOne = SplitScoreHandOne + 5;
                if (temp[0] == '6') SplitScoreHandOne = SplitScoreHandOne + 6;
                if (temp[0] == '7') SplitScoreHandOne = SplitScoreHandOne + 7;
                if (temp[0] == '8') SplitScoreHandOne = SplitScoreHandOne + 8;
                if (temp[0] == '9') SplitScoreHandOne = SplitScoreHandOne + 9;

                if (temp[0] == '1' || temp[0] == 'K' || temp[0] == 'Q' || temp[0] == 'J') SplitScoreHandOne = SplitScoreHandOne + 10;

                if (temp[0] == 'A')
                {
                    IsThereASecure++;
                    if (IsThereA == false)
                    {
                        if (SplitScoreHandOne > 10) SplitScoreHandOne = SplitScoreHandOne + 1;
                        else
                        {
                            SplitScoreHandOne = SplitScoreHandOne + 11;
                            IsThereA = true;
                        }
                    }
                    else
                    {
                        SplitScoreHandOne = SplitScoreHandOne + 1;
                        IsThereA = true;
                    }
                    //IsThereA = true;
                }

                if (IsThereA == true && SplitScoreHandOne > 21 && IsThereASecure == 1)
                {
                    SplitScoreHandOne -= 10;
                    IsThereA = false;
                }
                i++;
            }
            Debug.Log("My Extra hand One: " + SplitScoreHandOne);
            playerHandOne.text = SplitScoreHandOne.ToString();
            //GUIText("My Extra hand One: " + SplitScoreHandOne);
        }
    }

    public void ScoreCountExtraHandTwo()
    {
        SplitScoreHandTwo = 0;
        bool IsThereA = false;
        int IsThereASecure = 0; // this is security for 2nd ACE

        if (CardInExtraHandTwo.Count == 0)
            Debug.Log("Empty hand: " + CardInExtraHandTwo.Count);
        else
        {
            int i = 0;
            while (i < CardInExtraHandTwo.Count)
            {
                string temp = str[CardInExtraHandTwo[i]];

                if (temp[0] == '2') SplitScoreHandTwo = SplitScoreHandTwo + 2;
                if (temp[0] == '3') SplitScoreHandTwo = SplitScoreHandTwo + 3;
                if (temp[0] == '4') SplitScoreHandTwo = SplitScoreHandTwo + 4;
                if (temp[0] == '5') SplitScoreHandTwo = SplitScoreHandTwo + 5;
                if (temp[0] == '6') SplitScoreHandTwo = SplitScoreHandTwo + 6;
                if (temp[0] == '7') SplitScoreHandTwo = SplitScoreHandTwo + 7;
                if (temp[0] == '8') SplitScoreHandTwo = SplitScoreHandTwo + 8;
                if (temp[0] == '9') SplitScoreHandTwo = SplitScoreHandTwo + 9;

                if (temp[0] == '1' || temp[0] == 'K' || temp[0] == 'Q' || temp[0] == 'J') SplitScoreHandTwo = SplitScoreHandTwo + 10;

                if (temp[0] == 'A')
                {
                    IsThereASecure++;
                    if (IsThereA == false)
                    {
                        if (SplitScoreHandTwo > 10) SplitScoreHandTwo = SplitScoreHandTwo + 1;
                        else
                        {
                            SplitScoreHandTwo = SplitScoreHandTwo + 11;
                            IsThereA = true;
                        }
                    }
                    else
                    {
                        SplitScoreHandTwo = SplitScoreHandTwo + 1;
                        IsThereA = true;
                    }
                    //IsThereA = true;
                }

                if (IsThereA == true && SplitScoreHandTwo > 21 && IsThereASecure == 1)
                {
                    SplitScoreHandTwo -= 10;
                    IsThereA = false;
                }
                i++;
            }
            Debug.Log("My Extra hand TWO: " + SplitScoreHandTwo);
            playerHandTwo.text = SplitScoreHandTwo.ToString();
        }
    }

    public void EnemyScoreCount()
    {
        EnemyScore = 0;
        bool IsThereA = false;
        int IsThereASecure = 0; // this is security for 2nd ACE

        if (CardInEnemyHand.Count == 0)
            Debug.Log("Empty hand: " + CardInEnemyHand.Count);
        else
        {
            int i = 0;
            while (i < CardInEnemyHand.Count)
            {
                string temp = str[CardInEnemyHand[i]];

                if (temp[0] == '2') EnemyScore = EnemyScore + 2;
                if (temp[0] == '3') EnemyScore = EnemyScore + 3;
                if (temp[0] == '4') EnemyScore = EnemyScore + 4;
                if (temp[0] == '5') EnemyScore = EnemyScore + 5;
                if (temp[0] == '6') EnemyScore = EnemyScore + 6;
                if (temp[0] == '7') EnemyScore = EnemyScore + 7;
                if (temp[0] == '8') EnemyScore = EnemyScore + 8;
                if (temp[0] == '9') EnemyScore = EnemyScore + 9;

                if (temp[0] == '1' || temp[0] == 'K' || temp[0] == 'Q' || temp[0] == 'J') EnemyScore = EnemyScore + 10;

                if (temp[0] == 'A')
                {
                    IsThereASecure++;
                    if (IsThereA == false)
                    {
                        if (EnemyScore > 10) EnemyScore = EnemyScore + 1;
                        else
                        {
                            EnemyScore = EnemyScore + 11;
                            IsThereA = true;
                        }
                    }
                    else
                    {
                        if (EnemyScore > 10 || IsThereA) EnemyScore = EnemyScore + 1;
                        else EnemyScore = EnemyScore + 11;
                        EnemyScore -= 10;
                    }
                }
                if (IsThereA == true && EnemyScore > 21 && IsThereASecure == 1)
                {
                    EnemyScore -= 10;
                    IsThereA = false;
                }
                i++;
            }
            Debug.Log("Enemy hand: " + EnemyScore);
            enemyHand.text = EnemyScore.ToString();
        }
    }

    public void IsSplitable()
    {
        string temp1 = str[CardInHand[0]];
        string temp2 = str[CardInHand[1]];
        //ScoreCount();
        if (temp1[0] == temp2[0] || (temp1[0] == 'J' && temp2[0] == 'Q')
            || (temp1[0] == 'J' && temp2[0] == 'K') || (temp1[0] == 'Q' && temp2[0] == 'J')
            || (temp1[0] == 'Q' && temp2[0] == 'K') || (temp1[0] == 'K' && temp2[0] == 'J')
            || (temp1[0] == 'K' && temp2[0] == 'Q') || (temp1[0] == '1' && temp2[0] == 'K')
            || (temp1[0] == '1' && temp2[0] == 'Q') || (temp1[0] == '1' && temp2[0] == 'J')
            || (temp1[0] == 'K' && temp2[0] == '1') || (temp1[0] == 'Q' && temp2[0] == '1')
            || (temp1[0] == 'J' && temp2[0] == '1'))
        {
            Split.SetActive(true);
        }
    }

    public void IsDouble()
    {
        if (PlayerScore >= 9 && PlayerScore <= 11)
        {
            if ((playerMoney - tableMoney) >= 0)
            {
                btn_double.SetActive(true);
            }
            else
            {
                Notification.text = "Not Enough Money For Double";
            }
        }
    }

    public void Bet()
    {
        Deal();
        Deal();
        EnemyDeal();
        int enemyScoreOne = EnemyScore;

        // to hide 2nd score of enemy 
        EnemyDeal();
        enemyHand.text = enemyScoreOne.ToString();

        CardBack.SetActive(true);

        if (PlayerScore == 21 || EnemyScore == 21) result(); // check if blackjack or not in first table

        IsDouble(); // is double check

        IsSplitable(); // is split check
    }

    public void Double() // edited tableMoney text
    {
        btn_double.SetActive(false);
        playerMoney = playerMoney - tableMoney;
        enemyMoney = enemyMoney - tableMoney;
        tableMoney = 2 * tableMoney;
        TableMoney.text = "$" + tableMoney.ToString(); // added  this
        Deal();
        stand();
    }

    public void Deal()
    {
        Notification.text = " ";
        Split.SetActive(false);
        btn_double.SetActive(false);
        int i = 0; // this is freaking "i"
        while (true)
        { // checking random "i" values in list
            i = Random.Range(0, 52);//i = ran.Next(0, 32); // create random values between 0-3
            //if(handOne == 0){handOne = i;}
            //else {handTwo = i;}
            if (CardInGame.Contains(i))
                continue; //goto to the starting of while loop
            else
            {
                CardInGame.Add(i);
                CardInHand.Add(i);
                break;
            }
        }
        Instantiate(Cards[i], new Vector3(xVal, yVal, zVal), transform.rotation);
        xVal = xVal + 2f;
        yVal = yVal + 0.1f;
        //Debug.Log(i+" R: "+ CardInHand.Count);

        HitSound.Play();

        ScoreCount();
        if (PlayerScore == 21)
        {
            Hit.SetActive(false);
            if (CardInHand.Count > 2) stand();
        }

        if (PlayerScore > 21)
        {
            Debug.Log("Hand BUST");
            //Notification.text = "Hand Bust";
            Hit.SetActive(false);
            Stand.SetActive(false);
            PlayerIsBust = true;
            stand();
        }
    }

    public void DealHandOne()
    {
        int i = 0; // this is freaking "i"
        while (true)
        { // checking random "i" values in list
            i = Random.Range(0, 52);
            if (CardInGame.Contains(i))
                continue; //goto to the starting of while loop
            else
            {
                CardInGame.Add(i);
                CardInExtraHandOne.Add(i);
                break;
            }
        }
        Instantiate(Cards[i], new Vector3(xValOne, yValOne, zValOne), transform.rotation);
        xValOne = xValOne + 2f;
        yValOne = yValOne + 0.1f;
        //Debug.Log(i+" R: "+ CardInHand.Count);

        ScoreCountExtraHandOne();
        if (SplitScoreHandOne == 21)
        {
            HandOneStand();
        }

        if (SplitScoreHandOne > 21)
        {
            Debug.Log("Hand BUST");
            //Notification.text = "Hand One Bust";
            //HitForExtraHandOne.SetActive(false);
            //HitForExtraHandTwo.SetActive(true);
            HandOneIsBust = true;
            HandOneStand();
            //DealHandTwo();
        }
    }

    public void DealHandTwo()
    {
        int i = 0; // this is freaking "i"
        while (true)
        { // checking random "i" values in list
            i = Random.Range(0, 52);//i = ran.Next(0, 32); // create random values between 0-3
            if (CardInGame.Contains(i))
                continue; //goto to the starting of while loop
            else
            {
                CardInGame.Add(i);
                CardInExtraHandTwo.Add(i);
                break;
            }
        }
        Instantiate(Cards[i], new Vector3(xValTwo, yValTwo, zValTwo), transform.rotation);
        xValTwo = xValTwo + 2f;
        yValTwo = yValTwo + 0.1f;
        //Debug.Log(i+" R: "+ CardInHand.Count);

        ScoreCountExtraHandTwo();
        if (SplitScoreHandTwo == 21)
        {
            HitForExtraHandTwo.SetActive(false);
            if (CardInExtraHandTwo.Count > 2) HandTwoStand();
        }

        if (SplitScoreHandTwo > 21)
        {
            Debug.Log("Hand BUST");
            //Notification.text = "Hand Two Bust";
            //IsExtraOne = true;
            HitForExtraHandTwo.SetActive(false);
            HandTwoIsBust = true;
            HandTwoStand();
        }
    }

    public void EnemyDeal()
    {
        int i = 0; // this is freaking "i"

        while (true) // checking random "i" values in list
        {
            i = Random.Range(0, 52);//i = ran.Next(0, 32); // create random values between 0-3
            if (CardInGame.Contains(i)) continue; //goto to the starting of while loop
            else
            {
                CardInGame.Add(i);
                CardInEnemyHand.Add(i);
                break;
            }
        }

        Instantiate(Cards[i], new Vector3(xValEnemy, yValEnemy, zValEnemy), transform.rotation);
        xValEnemy = xValEnemy + 2f;
        yValEnemy = yValEnemy + 0.1f;
        //Debug.Log(i+" R: "+ CardInEnemyHand.Count);

        EnemyScoreCount();

        if (EnemyScore == 21)
            Hit.SetActive(false);
        if (EnemyScore > 21)
        {
            Debug.Log("Enemy Hand BUST");
            //Notification.text = "Enemy Bust";
            EnemyIsBust = true;
        }
    }

    public void split() //edited this
    {
        if ((playerMoney - tableMoney) >= 0)
        {
            playerMoney = playerMoney - tableMoney;
            enemyMoney = enemyMoney - tableMoney;

            //tableMoney = 2 * tableMoney; // commented this line
            TableMoney.text = "$" + (2 * tableMoney).ToString();

            //IsSplit = true;
            //string DisOne = str[CardInHand[0]]+"(Clone)";
            string DisTwo = str[CardInHand[1]] + "(Clone)";
            CardInExtraHandOne.Add(CardInHand[0]);
            CardInExtraHandTwo.Add(CardInHand[1]);
            CardInHand.Clear();
            //Destroy (GameObject.Find(DisOne));
            GameObject.Find(DisTwo).transform.position += new Vector3(26.0f, -0.1f, 0f);
            DealHandOne();
            DealHandTwo();
            Split.SetActive(false);
            Hit.SetActive(false);
            HitForExtraHandOne.SetActive(true);
            playerHand.text = " ";
            Stand.SetActive(false);
            StandForHandOne.SetActive(true);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void EnemyAI()
    {
        //float respawnTimer;
        CardBack.SetActive(false);
        while (true)
        {
            if (EnemyScore < 17)
            {
                EnemyDeal();
            }
            else break;
            //yield return new WaitForSeconds(delay);
        }
    }

    public void stand()
    {
        Notification.text = " ";
        Hit.SetActive(false);
        Stand.SetActive(false);
        Split.SetActive(false);
        btn_double.SetActive(false);
        HandOneCursor.SetActive(false);
        EnemyAI();
        result();
    }

    public void result()
    {
        Stand.SetActive(false);
        Rebet.SetActive(true);
        CardBack.SetActive(false);
        if (PlayerScore == EnemyScore || (PlayerIsBust == true && EnemyIsBust == true))
        {
            Debug.Log("PUSH!!");
            Notification.text = "PUSH!!";
            playerMoney = playerMoney + tableMoney;
            enemyMoney = enemyMoney + tableMoney;
            enemyHand.text = EnemyScore.ToString(); // to update final enemy result
            btn_double.SetActive(false);
            Split.SetActive(false);
        }
        else if (EnemyScore == 21 && CardInEnemyHand.Count == 2)
        {
            Debug.Log("BlackJack. Enemy win");
            Notification.text = "BlackJack. Dealer win";
            enemyMoney = enemyMoney + (2 * tableMoney) + tableMoney;
            playerMoney = playerMoney - tableMoney;
            //playerMoney = playerMoney - tableMoney;
            enemyHand.text = EnemyScore.ToString(); // to update final enemy result
            btn_double.SetActive(false);
            Split.SetActive(false);
        }
        else if (PlayerScore == 21 && CardInHand.Count == 2)
        {
            Debug.Log("BlackJack. You win");
            Notification.text = "BlackJack. You win";
            playerMoney = playerMoney + (2 * tableMoney) + tableMoney;
            enemyMoney = enemyMoney - tableMoney;
            //enemyMoney = enemyMoney - tableMoney;
            enemyHand.text = EnemyScore.ToString(); // to update final enemy result
            btn_double.SetActive(false);
            Split.SetActive(false);
        }
        else if (PlayerIsBust == true)
        {
            Debug.Log("Enemy win");
            Notification.text = "Dealer win";
            enemyMoney = enemyMoney + (2 * tableMoney);
            //playerMoney = playerMoney - tableMoney;
            enemyHand.text = EnemyScore.ToString(); // to update final enemy result
            btn_double.SetActive(false);
            Split.SetActive(false);
        }
        else if (EnemyIsBust == true)
        {
            Debug.Log("You Win");
            Notification.text = "You Win";
            playerMoney = playerMoney + (2 * tableMoney);
            //enemyMoney = enemyMoney - tableMoney;
            enemyHand.text = EnemyScore.ToString(); // to update final enemy result
            btn_double.SetActive(false);
            Split.SetActive(false);
        }
        else if (PlayerScore < EnemyScore)
        {
            Debug.Log("Enemy win");
            Notification.text = "Dealer win";
            enemyMoney = enemyMoney + (2 * tableMoney);
            //playerMoney = playerMoney - tableMoney;
            enemyHand.text = EnemyScore.ToString(); // to update final enemy result
            btn_double.SetActive(false);
            Split.SetActive(false);
        }
        else if (PlayerScore > EnemyScore)
        {
            Debug.Log("You Win");
            Notification.text = "You Win";
            playerMoney = playerMoney + (2 * tableMoney);
            //enemyMoney = enemyMoney - tableMoney;
            enemyHand.text = EnemyScore.ToString(); // to update final enemy result
            btn_double.SetActive(false);
            Split.SetActive(false);
        }

        winCon();
    }

    public void winCon()
    {
        if (playerMoney <= 0)
        {
            GameOverNoti.text = "Game Over!!\nEnemy Win";
            NewGame.SetActive(true);
            LoseSound.Play();
        }
        else if (enemyMoney <= 0)
        {
            GameOverNoti.text = "Game Over!!\nPlayer Win";
            NewGame.SetActive(true);
            WinSound.Play();
        }
    }

    public void ResultForSplit() //edited this function 
    {
        Rebet.SetActive(true);
        Stand.SetActive(false);
        Debug.Log("For Hand One");

        if (SplitScoreHandOne == EnemyScore || (EnemyIsBust == true && HandOneIsBust == true))
        {
            Debug.Log("PUSH hand ONE!!");
            NotificationOne.text = "PUSH hand ONE!!";

            playerMoney = playerMoney + tableMoney;
            enemyMoney = enemyMoney + tableMoney;
        }
        else if (EnemyScore == 21 && CardInExtraHandOne.Count == 2)
        {
            Debug.Log("BlackJack. Enemy win");
            NotificationOne.text = "BlackJack. Dealer wins!!";

            enemyMoney = enemyMoney + (2 * tableMoney) + (tableMoney / 2); // this 
            playerMoney = playerMoney - (tableMoney / 2); //this
        }
        else if (SplitScoreHandOne == 21 && CardInExtraHandOne.Count == 2)
        {
            Debug.Log("BlackJack. Hand one wins!!");
            NotificationOne.text = "BlackJack. Hand one wins!!";

            playerMoney = playerMoney + (2 * tableMoney) + (tableMoney / 2); // this 
            enemyMoney = enemyMoney - (tableMoney / 2); // this
        }
        else if (HandOneIsBust == true)
        {
            Debug.Log("Enemy win");
            NotificationOne.text = "Dealer wins!!";

            enemyMoney = enemyMoney + (2 * tableMoney); // this
        }
        else if (EnemyIsBust == true)
        {
            Debug.Log("Hand one Wins!!");
            NotificationOne.text = "Hand one Wins!!";

            playerMoney = playerMoney + (2 * tableMoney); // this
        }
        else if (SplitScoreHandOne < EnemyScore)
        {
            Debug.Log("Dealer wins!!");
            NotificationOne.text = "Dealer wins!!";

            enemyMoney = enemyMoney + (2 * tableMoney); // this 
        }
        else if (SplitScoreHandOne > EnemyScore)
        {
            Debug.Log("Hand One Win");
            NotificationOne.text = "Hand One Win";

            playerMoney = playerMoney + (2 * tableMoney); //this 
        }

        Debug.Log("For Hand TWO");

        if (SplitScoreHandTwo == EnemyScore || (EnemyIsBust == true && HandTwoIsBust == true))
        {
            Debug.Log("PUSH hand TWO!!");
            NotificationTwo.text = "PUSH hand TWO!!";

            playerMoney = playerMoney + tableMoney;
            enemyMoney = enemyMoney + tableMoney;
        }
        else if (EnemyScore == 21 && CardInExtraHandTwo.Count == 2)
        {
            Debug.Log("BlackJack. Dealer wins!!");
            NotificationTwo.text = "BlackJack. Dealer wins!!";

            enemyMoney = enemyMoney + (2 * tableMoney) + (tableMoney / 2);
            playerMoney = playerMoney - (tableMoney / 2);
        }
        else if (SplitScoreHandTwo == 21 && CardInExtraHandTwo.Count == 2)
        {
            Debug.Log("BlackJack. Hand two win");
            NotificationTwo.text = "BlackJack. Hand two win!!";

            playerMoney = playerMoney + (2 * tableMoney) + (tableMoney / 2);
            enemyMoney = enemyMoney - (tableMoney / 2);
        }
        else if (HandTwoIsBust == true)
        {
            Debug.Log("Dealer win");
            NotificationTwo.text = "Dealer win";

            enemyMoney = enemyMoney + (2 * tableMoney);
        }
        else if (EnemyIsBust == true)
        {
            Debug.Log("Hand Two Win");
            NotificationTwo.text = "Hand Two Win";

            playerMoney = playerMoney + (2 * tableMoney);
        }
        else if (SplitScoreHandTwo < EnemyScore)
        {
            Debug.Log("Dealer wins!!");
            NotificationTwo.text = "Dealer wins!!";

            enemyMoney = enemyMoney + (2 * tableMoney);

        }
        else if (SplitScoreHandTwo > EnemyScore)
        {
            Debug.Log("Hand Two Win");
            NotificationTwo.text = "Hand Two Win";

            playerMoney = playerMoney + (2 * tableMoney);
        }

        winCon();
    }

    public void HandOneStand()
    {
        StandForHandOne.SetActive(false);
        StandForHandTwo.SetActive(true);
        HandOneCursor.SetActive(false);
        HitForExtraHandOne.SetActive(false);
        HitForExtraHandTwo.SetActive(true);
        HandTwoCursor.SetActive(true);
    }

    public void HandTwoStand()
    {
        HandTwoCursor.SetActive(false);
        StandForHandTwo.SetActive(false);
        HitForExtraHandTwo.SetActive(false);
        EnemyAI();
        ResultForSplit();
    }

    public void refresh()
    {
        IsRebetPressed = true;
        Application.LoadLevel("Main");
    }

    public void refil()
    {
        playerMoney = 500;
        enemyMoney = 500;
    }

    public void SoundToggle()
    {
        foreach (AudioSource audios in allAudioSources)
        {
            /*if (SoundValue == true) 
            {
                audios.mute = true;
                SoundValue = false;
            }*/
            if (SoundValue == false)
            {
                audios.mute = true;
                SoundStat.text = "Sound ON";
                SoundValue = true;
            }
            else
            {
                audios.mute = false;
                SoundStat.text = "Sound OFF";
                SoundValue = false;
            }
        }
    }
}
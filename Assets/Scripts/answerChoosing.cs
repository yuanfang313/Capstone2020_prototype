using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class answerChoosing : MonoBehaviour
{
    public GameObject duck;
    public GameObject penguin;
    public Transform duck_p;
    public Transform penguin_p;
    public Text prompt;
    public Text TimerCount;
    public AudioSource audioSource;
    public AudioClip audioClip_0;
    public AudioClip audioClip_1;
    public AudioClip audioClip_2;
    public AudioClip audioClip_3;
    public AudioClip audioClip_4;
    public AudioClip audioClip_5;
    public AudioClip audioClip_6;

    private float timer1 = 0;
    private float timer2 = 0;
    private float timer3 = 0;
    private float timer4 = 0;
    private float timer5 = 0;
    private float timer6 = 0;
    private float intervalTimer = 0;
    private int number;
    private int number2;
    private float speed = 0.1f;
    private bool answered = false;
    private bool generated = false;
    private bool answerCorrected;
    private bool rightIsCorrected;
    
    private bool hadStarted = false;
    private bool hadFinished = false;
    private bool roundHadFinished = false;
    private bool hadPlay0 = false;
    private bool hadPlay1 = false;
    private bool hadPlay2 = false;
    private bool hadPlay3 = false;
    private bool hadPlay4 = false;
    private bool hadPlay5 = false;
 

    private GameObject duckInScene;
    private GameObject penguinInScene;

    private void Start()
    {
        
    }
    void Update()
    {
       //timers
       promptTimer();
       rightAnswerTimer();
       wrongAnswerTimer();
        roundTimer();
       IntervalTimer();

       //prompts before answer
       SetupQuestion();
       AnswerIsRightEventHandler();
       AnserIsWrongEventHandler();
       TimeIsUp();

    if (answered == true && answerCorrected == true)
        {
            AnswerIsRight();
        } else if (answered == true && answerCorrected == false)
        {
            AnswerIsWrong();
        }
    }


    void SetupQuestion()
    {
    // play welcome
        if(timer1 >= 6)
        {
            Debug.Log("Start playing Clip_0!");
            PlayAudioClip_0();
        }

    // play touchHorse
        if (intervalTimer > 6 && roundHadFinished)
        {
            Debug.Log("Start playing Clip_1!");
            prompt.text = "Ready! Touch the horse!";
            PlayAudioClip_1();
        }

    // generate items ramdomly
        if(hadPlay1 && hadFinished && !generated)
        {
            GenerateItems();
            generated = true;
            roundHadFinished = false;
        }
    }

    void AnswerIsRightEventHandler()
    {
        if (Input.GetKey(KeyCode.LeftArrow) & rightIsCorrected == false
            || Input.GetKey(KeyCode.RightArrow) & rightIsCorrected == true)
        {
            answered = true;
            answerCorrected = true;
        }
    }

    void AnserIsWrongEventHandler()
    {
        if (Input.GetKey(KeyCode.RightArrow) & answered == false
            || Input.GetKey(KeyCode.LeftArrow) & answered == false)
        {
            answered = true;
            answerCorrected = false;
        }
    }

    void AnswerIsRight()
    {
        prompt.text = "Correct! Good job!";
        TimerCount.text = "";
        PlayAudioClip_2();

        if (30 - timer2 <= 10)
        {
            prompt.text = "Let's do another round!";
            PlayAudioClip_3();
            Destroy(duckInScene);
            Destroy(penguinInScene);
        }

        if (30 - timer2 <= 0)
        {
            timer1 = 0;
            timer2 = 0;
            timer3 = 0;
            hadPlay1 = false;
            hadPlay2 = false;
            hadPlay3 = false;
            answered = false;
            answerCorrected = false;
            generated = false;
            roundHadFinished = true;
            intervalTimer = 0;
        }
    }

    void AnswerIsWrong()
    {
        prompt.text = "Try again! You can do it!";
        PlayAudioClip_5();
        if (number >= 7)
        {
            prompt.text = "Let's do another round!";
            PlayAudioClip_3();
            TimerCount.text = "";
            Destroy(duckInScene);
            Destroy(penguinInScene);
        }

        if (15 - timer4 <= 0)
        {
            timer1 = 0;
            timer4 = 0;
            timer3 = 0;
            number = 0;
            hadPlay1 = false;
            hadPlay5 = false;
            hadPlay3 = false;
            answered = false;
            answerCorrected = false;
            generated = false;
            roundHadFinished = true;
            intervalTimer = 0;
        }
    }

    void TimeIsUp()
    { 
        if (number2 >= 8)
        {
            PlayAudioClip_4();
        }

        if (number2 >= 15)
        {
            prompt.text = "Let's do another round!";
            PlayAudioClip_3();
            TimerCount.text = "";
            Destroy(duckInScene);
            Destroy(penguinInScene);
        }

        if (15 - timer6 <= 0)
        {
            timer1 = 0;
            timer4 = 0;
            timer3 = 0;
            timer5 = 0;
            timer6 = 0;
            number = 0;
            number2 = 0;
            hadPlay1 = false;
            hadPlay5 = false;
            hadPlay3 = false;
            hadPlay4 = false;
            answered = false;
            answerCorrected = false;
            generated = false;
            roundHadFinished = true;
            intervalTimer = 0;
        }
    }


    void promptTimer()
    {
        if (hadPlay0)
        {
            timer1 = 0;
        }

        timer1 = timer1 + speed;
        Debug.Log("timer1:" + timer1);


    }

    void roundTimer()
    {
        if (generated && answered == false)
        {
            timer5 = timer5 + speed/6;
            number2 = (int)timer5;
            TimerCount.text = number2.ToString();
        }
        if(number2 >= 15)
        {
            timer6 = timer6 + speed;
        }
    }

    void rightAnswerTimer()
    {
        if (answerCorrected == true & answered == true)
        {
            timer2 = timer2 + speed;
        }
    }

    void wrongAnswerTimer()
    {
        if (answerCorrected == false & answered == true)
        {

            timer3 = timer3 + speed/6;
            number = (int)timer3;
            TimerCount.text = number.ToString();

            if (number >= 7)
            {
                timer4 = timer4 + speed;
            }
        }
    }

    void IntervalTimer()
    {
        if (!audioSource.isPlaying && roundHadFinished)
        {
            intervalTimer = intervalTimer + speed;
        }
    }


    void GenerateItems()
    {
        int positions = Random.Range(1, 3);
        if (positions == 1)
        {
            rightIsCorrected = true;
            duckInScene = Instantiate(duck, duck_p.position, Quaternion.AngleAxis(200, Vector3.up));
            penguinInScene = Instantiate(penguin, penguin_p.position, Quaternion.AngleAxis(160, Vector3.up));
        }
        else if (positions == 2)
        {
            rightIsCorrected = false;
            duckInScene = Instantiate(duck, penguin_p.position, Quaternion.AngleAxis(160, Vector3.up));
            penguinInScene = Instantiate(penguin, duck_p.position, Quaternion.AngleAxis(200, Vector3.up));
        }
    }


    void PlayAudioClip_0()
    {
        if (!hadPlay0 && !hadStarted && answered == false)
        {
            audioSource.PlayOneShot(audioClip_0);
            hadStarted = true;
            hadFinished = false;
            hadPlay0 = true;
            roundHadFinished = true;
        }
        else if (!audioSource.isPlaying)
        {
            hadFinished = true;
            hadStarted = false;
            
        }
    }

    void PlayAudioClip_1()
    {
        if (!hadPlay1 && !hadStarted && answered == false)
        {
            audioSource.PlayOneShot(audioClip_1);
            hadStarted = true;
            hadFinished = false;
            hadPlay1 = true;
        }
        else if (!audioSource.isPlaying)
        {
            hadFinished = true;
            hadStarted = false;

        }
    }

    void PlayAudioClip_2 ()
    {
        if (!hadPlay2 && !hadStarted && answered)
        {
            Debug.Log("Start playing Clip_2!");
            audioSource.PlayOneShot(audioClip_2);
            hadStarted = true;
            hadFinished = false;
            hadPlay2 = true;
            
        }
        else if (!audioSource.isPlaying)
        {
            hadFinished = true;
            hadStarted = false;
        }
    }

    void PlayAudioClip_3()
    {
        if (!hadPlay3 && !hadStarted)
        {
            Debug.Log("Start playing Clip_3!");
            audioSource.PlayOneShot(audioClip_3);
            hadStarted = true;
            hadFinished = false;
            hadPlay3 = true;
        }
        else if (!audioSource.isPlaying)
        {
            hadFinished = true;
            hadStarted = false;
        }
    }

    void PlayAudioClip_4()
    {
        if (!hadPlay4 && !hadStarted && !answered)
        {
            Debug.Log("Start playing Clip_4!");
            audioSource.PlayOneShot(audioClip_4);
            hadStarted = true;
            hadFinished = false;
            hadPlay4 = true;
        }
        else if (!audioSource.isPlaying)
        {
            hadFinished = true;
            hadStarted = false;
        }
    }

    void PlayAudioClip_5()
    {
        if (!hadPlay5 && !hadStarted && answered == true)
        {
            Debug.Log("Start playing Clip_5!");
            audioSource.PlayOneShot(audioClip_5);
            hadStarted = true;
            hadFinished = false;
            hadPlay5 = true;
        }
        else if (!audioSource.isPlaying)
        {
            hadFinished = true;
            hadStarted = false;
        }
    }

}

  


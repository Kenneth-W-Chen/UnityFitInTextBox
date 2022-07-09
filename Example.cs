using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//This was attached to two GameObjects where one had a Text component and the other a TextMesh Pro component
//Used a button linked to the ButtonPressed() method to start the script
public class StartButtonScript : MonoBehaviour
{
    private Text _text;

    private TextMeshProUGUI _textMeshPro;

    private bool _isTextMeshPro;
    //public TextFit TextFitScript;
    public Canvas canvas;
    
    public string TestMessage;

    private List<string> _toBeDisplayed;
    //for now, we are testing this system using the legacy text (because it originally worked[?] with it)
    void Start()
    {
        if (TryGetComponent(out _textMeshPro))
        {
            _isTextMeshPro = true;
        }
        else
        {
            _isTextMeshPro = false;
            _text = GetComponent<Text>();
        }

        _toBeDisplayed = new List<string>(5);
        
        TestMessage = "According to all known laws of aviation, there is no way a bee should be able to fly." +
                      " Its wings are too small to get its fat little body off the ground. The bee, of course," +
                      " flies anyway because bees don't care what humans think is impossible. Yellow, black. Yellow," +
                      " black. Yellow, black. Yellow, black. Ooh, black and yellow! Let's shake it up a little. Barry!" +
                      " Breakfast is ready! Coming! Hang on a second. Hello? Barry? Adam? Can you believe this is " +
                      "happening? I can't. I'll pick you up. Looking sharp. Use the stairs, Your father paid good money " +
                      "for those. Sorry. I'm excited. Here's the graduate. We're very proud of you, son. A perfect" +
                      " report card, all B's. Very proud. Ma! I got a thing going here. You got lint on your fuzz. Ow!" +
                      " That's me! Wave to us! We'll be in row 118,000. Bye! Barry, I told you, stop flying in the" +
                      " house! Hey, Adam. Hey, Barry. Is that fuzz gel? A little. Special day, graduation. Never thought I" +
                      "'d make it. Three days grade school, three days high school. Those were awkward. Three" +
                      " days college. I'm glad I took a day and hitchhiked around The Hive. You did come back different." +
                      " Hi, Barry. Artie, growing a mustache? Looks good. Hear about Frankie? Yeah. You going to the " +
                      "funeral? No, I'm not going. Everybody knows, sting someone, you die. Don't waste it on a " +
                      "squirrel. Such a hothead. I guess he could have just gotten out of the way. I love this" +
                      " incorporating an amusement park into our day. That's why we don't need vacations. Boy" +
                      ", quite a bit of pomp under the circumstances. Well, Adam, today we are men. We are! Bee-" +
                      "men. Amen! Hallelujah! Students, faculty, distinguished bees, please welcome Dean Buzzwell." +
                      " Welcome, New Hive City graduating class of 9:15. That concludes our ceremonies And" +
                      " begins your career at Honex Industries! Will we pick our job today? I heard it" +
                      "'s just orientation. Heads up! Here we go. Keep your hands and antennas inside the tram at all " +
                      "times. Wonder what it'll be like? A little scary. Welcome to Honex, a division of Honesco and" +
                      " a part of the Hexagon Group. This is it! Wow. Wow. We know that you, as a bee," +
                      " have worked your whole life to get to the point where you can work for your whole life. Honey " +
                      "begins when our valiant Pollen Jocks bring the nectar to The Hive. Our top-secret formula is au" +
                      "tomatically color-corrected, scent-adjusted and bubble-contoured into this soothing sweet syrup " +
                      "with its distinctive golden glow you know as... Honey! That girl was hot. She's my cousin! She i" +
                      "s? Yes, we're all cousins. Right. You're right. At Honex, we constantly strive to improve every " +
                      "aspect of bee existence. These bees are stress-testing a new helmet technology. What do you thin" +
                      "k he makes? Not enough. Here we have our latest advancement, the Krelman. What does that do? Cat" +
                      "ches that little strand of honey that hangs after you pour it. Saves us millions. Can anyone wor" +
                      "k on the Krelman? Of course. Most bee jobs are small ones. But bees know that every small job," +
                      " if it's done well, means a lot. But choose carefully because you'll stay in the job you pick " +
                      "for the rest of your life. The same job the rest of your life? I didn't know that. What's the d" +
                      "ifference? You'll be happy to know that bees, as a species, haven't had one day off in 27 mill" +
                      "ion years. So you'll just work us to death? We'll sure try. Wow! That blew my mind! What's the difference?" +
                      " How can you say that? One job forever? That's an insane choice to have to make. I'm relieved." +
                      " Now we only have to make one decision in life. But, Adam, how could they never have told us th" +
                      "at? Why would you question anything? We're bees. We're the most perfectly functioning society on" +
                      " Earth. You ever think maybe things work a little too well here? Like what? Give me one example." +
                      " I don't know. But you know what I'm talking about. Please clear the gate. Royal Nectar Force o" +
                      "n approach. Wait a second. Check it out. Hey, those are Pollen Jocks! Wow. I've never seen them " +
                      "this close. They know what it's like outside The Hive. Yeah, but some don't come back. Hey, " +
                      "Jocks! Hi, Jocks! You guys did great! You're monsters! You're sky freaks! I love it! I love it! I" +
                      " wonder where they were. I don't know. Their day's not planned. Outside The Hive, flying wh" +
                      "o knows where, doing who knows what. You can't just decide to be a Pollen Jock. You have to " +
                      "be bred for that. Right. Look. That's more pollen than you and I will see in a lifetime.";
    }
    

    public void ButtonPressed()
    {
        _toBeDisplayed = _isTextMeshPro ? TextMeshProFit.MaxVerticalTextDisplay(_textMeshPro, canvas, TestMessage) : TextFit.MaxVerticalTextDisplay(_text, canvas, TestMessage);
        

        StartCoroutine(DisplayDialogue());
    }

    private IEnumerator DisplayDialogue()
    {
        if (_isTextMeshPro)
        {
            foreach (string line in _toBeDisplayed)
            {
                _textMeshPro.text = line;
                while (!Input.GetMouseButtonDown(0))
                {
                    yield return null;
                }

                yield return null;
            }

            _textMeshPro.text = "";
        }
        else
        {
            foreach (string line in _toBeDisplayed)
            {
                _text.text = line;
                while (!Input.GetMouseButtonDown(0))
                {
                    yield return null;
                }

                yield return null;
            }

            _text.text = "";
        }

        yield break;
    }
}

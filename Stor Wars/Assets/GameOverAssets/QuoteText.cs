using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuoteText : MonoBehaviour
{
    private string[] QUOTES = {
        "Mesa called Jar Jar Binks, mesa your humble servant!",
        "Ex-squeeze me, but the mostest safest place would be Gunga City. 'Tis where I grew up. 'Tis a hidden city.",
        "Hmm... yousa point is well seen. Dis way, hurry!",
        "Uh-oh! Biiiiig Goober fish!",
        "Den BOOM! Getin very scared and grabin dat Jedi, den pah... mesa here.",
        "Icky, icky goo!",
        "Mesa hatin' crunchin'. Dat's the last thing mesa want.",
        "Monsters out dere, leakin in here, all sinkin an no power? When are yousa tinkin' wesa in trouble?!",
        "Oh, maxi big da Force...",
        "Count me outta dis one. Better dead here than deader in the Core-- Ye Gods, whatta mesa sayin'?!",
        "Yousa should follow me now, okeeday? My warning yous: Gungans no like outsiders. Don't 'spect a warm welcome.",
        "Wesa got a grand army. That's why you no liking us meesa thinks.",
        "Exsqueeze me...",
        "No again! No again! The beings hereabouts are kwazy! We shall be robbed and crunched!",
        "With no-nutten mula to trade.",
        "Uh, oh. Big problem...",
    };

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = $"\"{QUOTES[Random.Range(0, QUOTES.Length - 1)]}\" - Jar Jar Binks";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

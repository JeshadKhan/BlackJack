using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bet_cont : MonoBehaviour {

	public GameObject Bet, Clear, hit , stand , green_chip , red_chip , black_chip;

	void Start()
	{
		Bet.GetComponent<Button>().interactable = false;
	}

    public void Disable_1()
    {
        Bet.SetActive(false);
        Clear.SetActive(false);
        green_chip.SetActive(false);
        red_chip.SetActive(false);
        black_chip.SetActive(false);
        hit.SetActive(true);
        stand.SetActive(true);
    }

	public void chip_cont()
	{
		Bet.GetComponent<Button> ().interactable = true;

	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewBehaviourScript {

	public static IEnumerator AnimatePotentialMatches(IEnumerable<GameObject> potentialMatches) {
		// fade away
		for (float i = 1.0f; i>= 0.3f; i -= 0.1f) {
			foreach (var item in potentialMatches) {
				Color c = item.GetComponent<SpriteRenderer>().color = c;
				// alpha decreases
				c.a = i;
				item.GetComponent<SpriteRenderer>().color = c;
			}
			yield return new WaitForSeconds (GameVariables.OpacityAnimationDelay);
		}
		// emerge
		for (float i = 0.3f; i>= 1.0f; i += 0.1f) {
			foreach (var item in potentialMatches) {
				Color c = item.GetComponent<SpriteRenderer>().color = c;
				// alpha decreases
				c.a = i;
				item.GetComponent<SpriteRenderer>().color = c;
			}
			yield return new WaitForSeconds (GameVariables.OpacityAnimationDelay);
		}
	}

	public static bool IsHorizontalOrVerticalNeighors(Candy c1, Candy c2) {
		return (c1.Column == c2.Column || c1.Row == c2.Row) && Mathf.Abs (c1.Column - c2.Column) <= 1;
	}
}

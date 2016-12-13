using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class CandyArray {
	GameObject[,] candies = new GameObject[GameVariables.Rows, GameVariables.Columns];
	// can easily restart
	private GameObject backup1;
	private GameObject backup2;

	public GameObject this[int row, int col] {
		get {
			try {
				return candies[row, col];
			} catch(Exception e){
				throw;
			}
		}

		set {
			candies[row, col] = value;
		}
	}

	public void Swap(GameObject g1, GameObject g2) {
		backup1 = g1;
		backup2 = g2;

		var g1Candy = g1.GetComponent<Candy> ();
		var g2Candy = g2.GetComponent<Candy> ();

		int g1Row = g1Candy.Row;
		int g1Col = g1Candy.Column;
		int g2Row = g2Candy.Row;
		int g2Col = g2Candy.Column;

		var temp = candies[g1Row, g1Col];
		candies [g1Row, g1Col] = candies [g2Row, g2Col];
		candies [g2Row, g2Col] = temp;

		Candy.SwapRowColumn (g1Candy, g2Candy);
	}

	//
	public void UndoSwap() {
		Swap (backup1, backup2);
	}

	private IEnumerable<GameObject> GetMatchesHorizontally(GameObject go) {
		List<GameObject> matches = new List<GameObject> ();
		matches.Add (go);

		var candy = go.GetComponent<Candy> ();

		// search left 
		if (candy.Column != 0) {
			for (int col = candy.Column; col >= 0; col--) {
				if (candies [candy.Row, col].GetComponent<Candy> ().IsSameType (candy)) {
					matches.Add (candies [candy.Row, col]);
				} else {
					// no need to go forward if there's already no match
					break;
				}
			}
		}

		// search right
		if (candy.Column != GameVariables.Columns - 1) {
			for (int col = candy.Column+1; col < GameVariables.Columns; col++) {
				if (candies [candy.Row, col].GetComponent<Candy> ().IsSameType (candy)) {
					matches.Add (candies [candy.Row, col]);
				} else {
					// no need to go forward if there's already no match
					break;
				}
			}
		}

		if (matches.Count < GameVariables.MinimumMatches) {
			matches.Clear ();
		}
			
		// ignore duplicated objects
		return matches.Distinct ();
	}

	private IEnumerable<GameObject> GetMatchesVertically(GameObject go) {
		List<GameObject> matches = new List<GameObject> ();
		matches.Add (go);

		var candy = go.GetComponent<Candy> ();

		// search bottom 
		if (candy.Row != 0) {
			for (int row = candy.Row - 1 ; row >= 0; row--) {
				if (candies [row, candy.Column].GetComponent<Candy> ().IsSameType (candy)) {
					matches.Add (candies [row, candy.Column]);
				} else {
					// no need to go forward if there's already no match
					break;
				}
			}
		}

		// search top
		if (candy.Row != GameVariables.Rows - 1) {
			for (int row = candy.Row+1; row < GameVariables.Rows; row++) {
				if (candies [row, candy.Column].GetComponent<Candy> ().IsSameType (candy)) {
					matches.Add (candies [row, candy.Column]);
				} else {
					// no need to go forward if there's already no match
					break;
				}
			}
		}

		if (matches.Count < GameVariables.MinimumMatches) {
			matches.Clear ();
		}

		// ignore duplicated objects
		return matches.Distinct ();
	}
}

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

	}

}

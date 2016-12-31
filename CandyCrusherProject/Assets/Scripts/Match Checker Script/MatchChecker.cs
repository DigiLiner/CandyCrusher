using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MatchChecker {

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

	public static bool AreHorizontalOrVerticalNeighors(Candy c1, Candy c2) {
		return (c1.Column == c2.Column || c1.Row == c2.Row) && Mathf.Abs (c1.Column - c2.Column) <= 1 && Mathf.Abs (c1.Row - c2.Row) <= 1;
	}

	public static IEnumerable<GameObject> GetPotentialMatches(CandyArray candies){
		List<List<GameObject>> matches = new List<List<GameObject>>();
		return null;
	}

	public static List<GameObject> CheckHorizontal1(int row, int column, CandyArray candies){
		if(column <= GameVariables.Columns - 2){
			if(candies[row, column].GetComponent<Candy>.IsSameType(candies[row, column + 1].GetComponent<Candy>())){
				if(row >=1 && column >=1){
					if (candies [row, column].GetComponent<Candy>().IsSameType (candies [row - 1, column - 1].GetComponent<Candy> ())) {
						return new List<GameObject> () {
							candies [row, column], 
							candies [row, column + 1], 
							candies [row - 1, column - 1]
						};

						if(row <= GameVariables.Rows-2 && column >=1){
							if(candies[row,column].GetComponent<Candy>().IsSameType(candies[row+1,column-1].GetComponent<Candy>())){
								return new List<GameObject> () {
									candies [row, column], 
									candies [row, column + 1], 
									candies [row + 1, column - 1]
								};
							
							}
						}
					}
				}
			}
		}
		return null;
	}

	public static List<GameObject> CheckHorizontal2(int row, int column, CandyArray candies){

		if(column <= GameVariables.Columns -3){
			if(candies[row,column].GetComponent<Candy>().IsSameType(candies[row,column +1].GetComponent<Candy>())){
				if(row >=1&& column<= GameVariables.Columns -3){
					
				}

			}
		}
		return null;
	}
		
}
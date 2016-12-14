using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AlteredCandyInfo {
	private List<GameObject> newCandy;
	public int maxDistance{ get; set;}

	public AlteredCandyInfo() {
		newCandy = new List<GameObject>();

	}

	public IEnumerable<GameObject> AlteredCandy() {
		return newCandy.Distinct ();
	}

	public void AddCandy(GameObject go) {
		if (!newCandy.Contains (go)) {
			newCandy.Add (go);
		}
	}

	public AlteredCandyInfo Collapse(IEnumerable<int> columns) {
		AlteredCandyInfo collapseInfo = new AlteredCandyInfo ();

		foreach(var column in columns) {
			for(int row=0; row<GameVariables.Rows-1;row++) {
				if(candies
			}
		}
	}
}

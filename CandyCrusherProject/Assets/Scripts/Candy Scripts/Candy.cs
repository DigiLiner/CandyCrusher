using UnityEngine;
using System.Collections;

public class Candy : MonoBehaviour {

	public BonusType Bonus { get; set;}

	public int Row { get; set; }
	public int Column { get; set; }
	// Candy's color type
	public string Type { get; set; }

	public Candy() {
		// Default Bonus Type of a candy is none
		Bonus = BonusType.None;
	}

	public bool IsSameType(Candy otherCandy) {
		// when equal, is 0
		return string.Compare (this.Type, otherCandy.Type) == 0;
	}

	public void Initialize(string type, int row, int col) {
		Column = col;
		Row = row;
		Type = type;
	}

	public static void SwapRowColumn(Candy c1, Candy c2) {
		int temp = c1.Row;
		c1.Row = c2.Row;
		c2.Row = temp;

		temp = c1.Column;
		c1.Column = c2.Column;
		c2.Column = temp;
	}
}

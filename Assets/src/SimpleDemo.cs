using UnityEngine;
using System.Collections;

public class SimpleDemo : MonoBehaviour {
	private int size = 8;
	private bool[] columns;
	private bool[] slash;
	private bool[] backslash;

	private bool[,] blocks;

	private int solutions = 0;

	// Use this for initialization
	void Start () {
		this.columns = new bool[this.size];
		this.slash = new bool[2 * this.size + 1];
		this.backslash = new bool[2 * this.size + 1];
		this.blocks = new bool[this.size, this.size];

		this._solve (0);

		Debug.Log ("solutions: " + this.solutions);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void _solve(int row) {
		if (row < this.size) {
			for (int column = 0; column < this.size; column++) {
				if (!this.columns [column] && !this.slash [row + column] && !this.backslash [(this.size - 1 - row) + column]) {
					this.blocks [row, column] = true;
					this.columns [column] = true;
					this.slash [row + column] = true;
					this.backslash [(this.size - 1 - row) + column] = true;

					this._solve (row + 1);

					this.blocks [row, column] = false;
					this.columns [column] = false;
					this.slash [row + column] = false;
					this.backslash [(this.size - 1 - row) + column] = false;
				}
			}
		} else {
			string log = "";
			for(int r= 0; r < this.size ; r ++) {
				for(int c= 0; c < this.size ; c ++) {
					log += this.blocks[r,c]? "○": "×";
				}
				log += "\n";
			}
			Debug.Log (log);
			this.solutions++;
		}
	}
}

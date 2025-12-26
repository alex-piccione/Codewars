function rotate(matrix, direction) {
    let result = []
    const new_tot_rows = matrix[0].length
    const new_tot_cols = matrix.length

    if (direction == "clockwise")
        for(var new_row = 0; new_row < new_tot_rows; new_row++) {
            const line = []
            for(var new_col = new_tot_cols-1; new_col >= 0; new_col--) {
                line.push(matrix[new_col][new_row])
                if (new_col == 0)
                    result.push(line)
            }
        }
    else // counter-clockwise
        for(var new_row = new_tot_rows-1; new_row >= 0; new_row--) { 
            const line = []
            for (var new_col=0; new_col < new_tot_cols; new_col++) {
                line.push(matrix[new_col][new_row])
                if (new_col == new_tot_cols-1)
                    result.push(line)
            }
        }

    return result
}

const deepEqual = require('chai').assert.deepEqual;

describe("Tests suite", () => {
	it("sample tests", () => {
		// Test a matrix with equal numbers of rows/cols
		let matrix = [
			[1,2,3],
			[4,5,6],
			[7,8,9]
		];
		deepEqual(rotate(matrix, 'counter-clockwise'), [[3,6,9],[2,5,8],[1,4,7]] );
		deepEqual(rotate(matrix, 'clockwise'), [[7,4,1],[8,5,2],[9,6,3]] );
		deepEqual(rotate(rotate(matrix, 'counter-clockwise'), 'clockwise'), [[1,2,3],[4,5,6],[7,8,9]] );
		deepEqual(rotate(rotate(rotate(rotate(matrix, 'clockwise'), 'clockwise'), 'clockwise'), 'clockwise'), [[1,2,3],[4,5,6],[7,8,9]] );

		// Test a matrix with unequal number of rows/cols
		matrix = [
			[1,2,3],
			[4,5,6],
			[7,8,9],
			[10,11,12]
		];
		deepEqual(rotate(matrix, 'counter-clockwise'), [[3,6,9,12],[2,5,8,11],[1,4,7,10]] );
		deepEqual(rotate(matrix, 'clockwise'), [[10,7,4,1],[11,8,5,2],[12,9,6,3]] );

		// Test a matrix with only one row/col
		matrix = [
			[1,2,3]
		];
		deepEqual(rotate(matrix, 'counter-clockwise'), [[3],[2],[1]] );
		deepEqual(rotate(matrix, 'clockwise'), [[1],[2],[3]] );
		deepEqual(rotate(rotate(matrix, 'clockwise'), 'clockwise'), [[3,2,1]] );

		// Test a single cell matrix
		matrix = [
			[1]
		];
		deepEqual(rotate(matrix, 'counter-clockwise'), [[1]] );
	});
});
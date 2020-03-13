//Functions triggered on page load:
$(function () {

    // Buttons:
    $('#btnToggleStatus').click(function () {
        if ($(this).html() == 'Start') {
            $(this).html('Stop');
            pauseGame();
        }
        else {
            $(this).html('Start');
            startGame();
        }
    });
    $('#btnNext').click(function () {
        advanceGame();
    });

    $('#btnClear').click(function () {
        clearBoard();
    });

    // Generate Grid:
    $("#tableContainer").append(generateGrid(30, 30));

    // Handle clicks/mouse drag on grid:
    var isMouseDown = false;
    $("td")
        .mousedown(function () {
            isMouseDown = true;
            $(this).toggleClass("highlighted");

            var index = $("td").index(this);
            var row = Math.floor((index) / 30) + 1;
            var col = (index % 30) + 1;
            console.log("That was row " + row + " and col " + col);
            setCell(playerColor, row, col);

            return false; // prevent text selection
        })
        .mouseover(function () {
            if (isMouseDown) {
                $(this).toggleClass("highlighted");

                var index = $("td").index(this);
                var row = Math.floor((index) / 30) + 1;
                var col = (index % 30) + 1;
                console.log("That was row " + row + " and col " + col);
                setCell(playerColor, row, col);
            }
        })
        .bind("selectstart", function () {
            return false; // prevent text selection in IE
        });

    $(document)
        .mouseup(function () {
            isMouseDown = false;
        });
});

// Draw grid:
function generateGrid(rows, cols) {
    var grid = "<table>";
    for (row = 1; row <= rows; row++) {
        grid += "<tr id='row_" + row + "'>"; // e.g. row_3
        for (col = 1; col <= cols; col++) {
            grid += "<td id='x" + row + "y" + col + "'></td>"; // e.g. x3y5 meaning row 3, column 5
        }
        grid += "</tr>";
    }
    return grid;
}

// Color Picker:
var playerColor = "#BF2828"
function changeColor() {
    playerColor = document.getElementById("colorPicker").value;
    console.log(playerColor);
    document.documentElement.style
        .setProperty('--player-color', playerColor);
}

function updateGrid(jString) {
    // Turn json string into object:
    var gridObject = JSON.parse(JSON.stringify(jString));
    console.log(gridObject);

    // foreach element in gridObject, setCellColor(x, y)
}

function setColor(x, y) {
    var selectionStr = "#x" + x + "y" + y;
    $(selectionStr).css('background-color', playerColor);
}

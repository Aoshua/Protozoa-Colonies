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
        $('td').removeClass('highlighted');
    });

    $('#btnClear').click(function () {
        $('td').removeClass('highlighted');
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
            var row = Math.floor((index) / 30);
            var col = (index % 30);
            setCell(playerColor, row, col);

            return false; // prevent text selection
        })
        .mouseover(function () {
            if (isMouseDown) {
                $(this).toggleClass("highlighted");

                var index = $("td").index(this);
                var row = Math.floor((index) / 30);
                var col = (index % 30);
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
    if (document.getElementById("colorPicker").value != "#ffffff") {
        playerColor = document.getElementById("colorPicker").value;
        console.log(playerColor);
        document.documentElement.style
            .setProperty('--player-color', playerColor);
    } else {
        document.getElementById("colorPicker").value = "#BF2828";
        alert("Pick a color besides white.");
    }
}

function updateGrid(jString) {
    // Turn json string into object:
    var gridObject = JSON.parse(jString);
    console.log("Update Grid called.");

    for (i = 0; i < gridObject.length; i++) {
        //console.log("Cell x:" + gridObject[i].x + " y: " + gridObject[i].y);
        setCellColor(gridObject[i].x, gridObject[i].y, gridObject[i].color);
    }
}

function setCellColor(x, y, color) {
    console.log("Set Cell Color called.");
    var selectionStr = "#x" + x + "y" + y;
    //console.log("Redraw Grid: " + x + " " + y + " " + color);
    $(selectionStr).css('background-color', color);
}



//Functions triggered on page load:
$(function () {

    // Buttons:
    $('#btnToggleStatus').click(function () {
        if ($(this).html() == 'Start') {
            $(this).html('Stop');
            // Add start logic here
        }
        else {
            $(this).html('Start');
            // Add stop logic here
        }
    });
    $('#btnNext').click(function () {
        // Add next logic here
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
            console.log("That was row " + row + " and col " + col);

            return false; // prevent text selection
        })
        .mouseover(function () {
            if (isMouseDown) {
                $(this).toggleClass("highlighted");

                var index = $("td").index(this);
                var row = Math.floor((index) / 30);
                var col = (index % 30);
                console.log("That was row " + row + " and col " + col);
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
        grid += "<tr>";
        for (col = 1; col <= cols; col++) {
            grid += "<td></td>";
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

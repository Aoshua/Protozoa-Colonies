//Functions triggered on page load:
$(function () {

    // Title Animations:
    //$('#intro0').fadeIn(1500, function () {
    //    $('#intro1').fadeIn(1500, function () {
    //        $('#intro2').fadeIn(1500, function () {
    //            $('#intro0').fadeOut(1000);
    //            $('#intro1').fadeOut(1000, function () {
    //                $('#intro2').removeClass('display-2');
    //                $('#intro2').addClass('display-4');
    //                $('#gameContainer').fadeIn(1000);
    //                $('#gameContainer').css("display", "inline-grid");
    //            });
    //        });
    //    });
    //});

    // Generate Grid:
    $("#tableContainer").append(generateGrid(50, 50));

    // Handle clicks/mouse drag:
    var isMouseDown = false;
    $("td")
        .mousedown(function () {
            isMouseDown = true;
            $(this).toggleClass("highlighted");

            var index = $("td").index(this);
            var row = Math.floor((index) / 50);
            var col = (index % 50);
            console.log("That was row " + row + " and col " + col);

            return false; // prevent text selection
        })
        .mouseover(function () {
            if (isMouseDown) {
                $(this).toggleClass("highlighted");

                var index = $("td").index(this);
                var row = Math.floor((index) / 50);
                var col = (index % 50);
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
var playerColor = "#bf2828"
function changeColor() {
    playerColor = document.getElementById("colorPicker").value;
    console.log(playerColor);
    document.documentElement.style
        .setProperty('--player-color', playerColor);
}

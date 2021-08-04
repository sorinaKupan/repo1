// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                "teamMember": newcomerName
            },
            success: (result) => {
                $("#list").append(`<li>${newcomerName}</li>`);
                $("#nameField").val("");
            }
        })

    })
});
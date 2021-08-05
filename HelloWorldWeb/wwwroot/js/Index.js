// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $('#nameField').on('input change', function () {
        if ($(this).val() != '') {
            $('#createButton').prop('disabled', false);
        } else {
            $('#createButton').prop('disabled', true);
        }
    });

    $("#clearButton").click(function () {
        $("#nameField").val("");
        $('#createButton').prop('disabled', true);
    });

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                "teamMember": newcomerName
            },
            success: (result) => {
                $("#list").append(
                    `<li class="member">
                        <span class="memberName">${newcomerName}</span>
                        <span class="delete fa fa-remove"></span>
                        <span class="edit fa fa-pencil"></span>
                    </li>`);
                $("#nameField").val("");
                $('#createButton').prop('disabled', true);
            }
        })

    })
});
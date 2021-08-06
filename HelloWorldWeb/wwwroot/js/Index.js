// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    setDelete();

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
            method: "GET",
            url: "/Home/GetCount",

            success: (resultGet) => {
                $.ajax({
                    method: "POST",
                    url: "/Home/AddTeamMember",
                    data: {
                        "teamMember": newcomerName
                    },
                    success: (resultPost) => {
                        $("#list").append(
                            `<li class="member" id="${resultGet}">
                        <span class="memberName">${newcomerName}</span>
                        <span class="delete fa fa-remove" id="deleteMember"></span>
                        <span class="edit fa fa-pencil"></span>
                             </li>`);
                        $("#nameField").val("");
                        $('#createButton').prop('disabled', true);
                        setDelete();
                    }
                })
            }
        });
    })
    $("#list").on("click", ".pencil", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text();
        $('#editClassmate').attr("data-member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal('show');
    })

    $("#editClassmate").on("click", "#submit", function () {
        console.log('submit changes to server');
        var id = 5;
        var name = "Sorina";
        $.ajax({
            url: "/Home/EditTeamMemberName",
            method: "POST",
            data: {
            "id": id,
            "name": name
        },
            success: function (result) {
                console.log(`successful renamed ${id}`);
                location.reload();
            }
        })
    })


    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    })
});

function setDelete(){
    $(".delete").off("click").click(function () {
        var id = $("#deleteMember").parent().attr("id");
        $.ajax({
            method: "DELETE",
            url: "/Home/DeleteTeamMember",
            data: {
                "id": id
            },
            success: (result) => {
                console.log("delete:" + id);
                $(this).parent().remove();
            }
        })
    }
    );
}

// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    setDelete();
    setEdit();

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
                        <span class="pencil fa fa-pencil"></span>
                             </li>`);
                        $("#nameField").val("");
                        $('#createButton').prop('disabled', true);
                        setDelete();
                        setEdit();
                    }
                })
            }
        });
    })

    $("#editClassmate").on("click", "#submit", function () {
        var targetMemberTag = $(this).closest('li');
        var id = $('#editClassmate').attr("data-member-id");
        var name = $('#classmateName').val();
        $.ajax({
            url: "/Home/EditTeamMemberName",
            method: "POST",
            data: {
            "id": id,
            "name": name
        },
            success: function (result) {
                targetMemberTag.find("memberName").text(name);
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
        var id = $(this).parent().attr("data-member-id");
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

function setEdit() {
    $("#list").off("click").on("click", ".pencil", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('data-member-id');
        var currentName = targetMemberTag.find(".memberName").text();
        $('#editClassmate').attr("data-member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal('show');
    })
}

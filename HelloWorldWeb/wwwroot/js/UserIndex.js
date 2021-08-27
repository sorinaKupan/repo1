// This JS file now uses jQuery. Pls see here: https://jquery.com/

$(document).ready(function () {
    // see https://api.jquery.com/click/
    var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

    assignAdminRole();
    assignUsualUserRole();

    connection.on("AssignedUserRole", editUserRole);
    connection.on("AssignedAdminRole", editAdminRole);

    connection.start().then(function () {
    }).catch(function (err) {
        return console.error(err.toString());
    });
});
function assignAdminRole()
{
        (".assignAdminRole").click(function(){
            var id = $(this).attr("user-id");
            $.ajax({
                method: "POST",
                    url: "/Users/AssignAdminRole",
                    data:
                {
                    "id": id
                    },
                    success: (resultPost) => {}
                })
        })
    assignUsualUserRole();
}

function assignUsualUserRole()
{
        (".assignUsualRole").click(function(){
            var id = $(this).attr("user-id");
            $.ajax({
                method: "POST",
                    url: "/Users/AssignUsualRole",
                    data:
                {
                    "id": id
                    },
                    success: (resultPost) => {}
                })
        })
    assignAdminRole();
}

var editUserRole = (id) => {
    $(`button[link-id =${id}]`).remove();
    $(`td[td-id = ${id}]`).append(`<button user-id="${id}" id="assignUsualRole">Assign Usual User Role</button>`);
}

var editAdminRole = (id) => {
    $(`button[link-id =${id}]`).remove();
    $(`td[td-id = ${id}]`).append(`<button user-id="${id}" id="assignAdminRole">Assign Administrator Role</button>`);
}

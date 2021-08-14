function deleteToDo(idToDo) {
    $.ajax({
        url: 'remove-todo/' + idToDo,
        type: "delete",
        success: function (result) {
            location.reload();
        }
    });
}

function sendChange(idToDo) {
    $.ajax({
        url: 'update-status-todo/' + idToDo,
        type: "patch",
        success: function (result) {
            location.reload();
        }
    });
}
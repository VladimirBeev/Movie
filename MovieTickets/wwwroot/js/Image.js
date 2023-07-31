$(document).ready(function () {
    var output = document.getElementById('preview');
    output.src = $("#ImageUrl").val();
})
$("#ImageUrl").on("change", function () {
    var output = document.getElementById('preview');
    output.src = $(this).val();
})
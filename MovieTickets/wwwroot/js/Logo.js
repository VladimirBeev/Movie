$(document).ready(function () {
    var output = document.getElementById('preview');
    output.src = $("#LogoUrl").val();
})
$("#LogoUrl").on("change", function () {
    var output = document.getElementById('preview');
    output.src = $(this).val();
})
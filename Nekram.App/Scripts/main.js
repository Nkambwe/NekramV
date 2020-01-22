$(document).ready(function () {

    //general page loader
    $(".pageloader").fadeOut("slow");

    //modify default jquery validation plugin
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest(".form-group").addClass("error");
        },

        unhighlight: function (element) {
            $(element).closest(".form-group").removeClass("error");
        }
    });

    //upload image
    $(".btn-browse").click(function (e) {
        e.preventDefault();
        const file = $(this).parents().find(".file-input");
        file.trigger("click");
    });

    $('input[type="file"]').change(function (e) {

        e.preventDefault();
        const fileName = e.target.files[0].name;
        $("#flogo").val(fileName);

        const reader = new FileReader();
        reader.onload = function (et) {
            // get loaded data and render thumbnail.
            document.getElementById("preview").src = et.target.result;
        };

        // read the image file as a data URL.
        reader.readAsDataURL(this.files[0]);

        const data = new FormData();
        const files = $('input[type="file"]').get(0).files;

        if (files.length > 0) {
            data.append("companylogo", files[0]);

        }

        $.ajax({
            url: "Areas/Branches/Companyhome/GetLogofile",
            type: "POST",
            processData: false,
            contentType: false,
            data: data,
            success: function (success) {
                success.filename = fileName;
                //successful image load
                $("#flogo").val(filename);
            },
            error: function (er) {
                $("#lbllogoerr").html(`${er}: Invalid Image type.`).show().fadeOut("slow");
            }
        });

    });
});
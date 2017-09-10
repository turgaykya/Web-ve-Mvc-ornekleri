$(function () {

    var flag = true


    $("button[type=button]").click(function () {

        $(".control").each(function () {

            if ($(this).val() == "") {
                $(this).addClass("borderRed")
            } else {
                $(this).removeClass("borderRed")
            }
        })

        if ($("#checkboxM").prop("checked") != true) {

            if (flag == true) {
                $(".checkbox").before("<span class='error'>Lütfen Kullanım Sözleşmesini Onaylayınız!<span>")
                flag = false
            }
 
        } else {

            flag = true;
            $(".error").remove();
        }

        if ($("select").val() == null) {
          
          $("select").addClass("borderRed");

        }else{
             $("select").removeClass("borderRed");
        }

    })
    
    $("#checkboxM").change(function(){
            flag = true;
            $(".error").remove();
    })


    $(".control").keypress(function () {
        $(this).removeClass("borderRed")
    })




})
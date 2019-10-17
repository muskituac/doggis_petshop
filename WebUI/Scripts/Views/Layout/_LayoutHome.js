var _LayoutHome = {

    API_URL: "",
    UsuarioID: "",

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;

        that.LoginValidation();
    },

    //Método para realizar login
    LoginValidation: function () {
        var that = this;

        that.PreProcees();

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Usuario/GetUsuario?usuario_id=" + that.UsuarioID,
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);


            var usuario = response_done;

            if (usuario.id != "" && usuario.id != "undefined") {

                if (usuario.usuario_tipo == "1") {
                    window.location = "IndexAdministrador?usuario_id=" + usuario.id;
                } else if (usuario.usuario_tipo == "2") {
                    window.location = "IndexAtendente?usuario_id=" + usuario.id;
                } else if (usuario.usuario_tipo == "3") {
                    window.location = "IndexCliente?usuario_id=" + usuario.id;
                }
            } else {
                $("#alert_error").removeClass("d-none");
            }

            that.PosProcess();

        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);

        });

    },

    PreProcees: function () {
        $("#content_modal").modal({ backdrop: "static", keyboard: false });
        $("#content_modal").modal("show");
    },

    PosProcess: function () {
        $("#content_modal").modal("hide");
    }


}
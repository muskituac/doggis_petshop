var IndexAdministrador = {

    API_URL: "",
    UsuarioID: "",

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;

        that.GetUsuario();
    },

    //Método para realizar login
    GetUsuario: function () {
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

                $("#usuario_nome").html(usuario.nome);

            } else {
                window.location = "Error";
            }

            that.PosProcess();

        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });

    },

    PreProcees: function () {

    },

    PosProcess: function () {

    }


}